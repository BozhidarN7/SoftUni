const { chromium } = require('playwright-chromium');
const { expect } = require('chai');
const { test } = require('mocha');

let browser, page;
const clientUrl = 'http://127.0.0.1:5500/02.Book-Library/';

function fakeResponse(data) {
    return {
        status: 200,
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
    };
}

const testBooks = {
    1: {
        title: 'My Book 1',
        author: 'Me 1',
    },
    2: {
        title: 'My Book 2',
        author: 'Me 2',
    },
};

describe('E2E', () => {
    before(async () => {
        browser = await chromium.launch();
    });
    after(async () => {
        await browser.close();
    });
    beforeEach(async () => {
        page = await browser.newPage();
    });
    afterEach(async () => {
        await page.close();
    });

    describe('load books', () => {
        it('should call server', async () => {
            await page.route('**/jsonstore/collections/books', (route) => {
                route.fulfill(fakeResponse(testBooks));
            });
            await page.goto(clientUrl);
            const [response] = await Promise.all([
                page.waitForResponse('**/jsonstore/collections/books'),
                page.click('#loadBooks'),
            ]);
            const result = await response.json();
            expect(result).to.eql(testBooks);
        });
        it('should show data in table', async () => {
            await page.route('**/jsonstore/collections/books', (route) => {
                route.fulfill(fakeResponse(testBooks));
            });
            await page.goto(clientUrl);
            const [response] = await Promise.all([
                page.waitForResponse('**/jsonstore/collections/books'),
                page.click('#loadBooks'),
            ]);

            const result = await page.$$eval('tbody tr', (trs) => {
                let res = '';
                trs.forEach(
                    (tr) =>
                        (res += `${tr.children[0].textContent}: ${tr.children[1].textContent}\n`)
                );
                return res;
            });
            const expected = Object.values(testBooks)
                .map((v) => `${v.title}: ${v.author}`)
                .join('\n');

            expect(result.trim()).to.eql(expected.trim());
        });
    });
    describe('test add book', () => {
        it('should stop if fields are empty', async () => {
            const mockBook = { title: '', author: '' };

            await page.route('**/jsonstore/collections/books', (route) => {
                route.fulfill(fakeResponse(mockBook));
            });

            await page.goto(clientUrl);

            await page.fill('input[name="title"]', mockBook.title);
            await page.fill('input[name="author"]', mockBook.author);

            page.on('dialog', async (dialog) => {
                expect(dialog.message()).to.eql('All fields are required!');
                await dialog.dismiss();
            });
            await page.click('#createForm > button');
        });
        it('should test if the right request with correct params is send', async () => {
            const mockBook = { title: 'Book 1', author: 'Author 1' };

            await page.route('**/jsonstore/collections/books', (route) => {
                const sent = route.request().postData();
                expect(sent).to.deep.equal(mockBook);
                route.fulfill(fakeResponse(mockBook));
            });
        });
        it('should add book', async () => {
            const mockBook = { title: 'Book1', author: 'Author1' };

            await page.route('**/jsonstore/collections/books', (route) => {
                route.fulfill(fakeResponse(mockBook));
            });

            page.goto(clientUrl);

            await page.fill('input[name="title"]', mockBook.title);
            await page.fill('input[name="author"]', mockBook.author);

            const [response] = await Promise.all([
                page.waitForResponse('**/jsonstore/collections/books'),
                page.click('#createForm > button'),
            ]);

            const data = await response.json();
            expect(data).to.eql(mockBook);
        });
    });
    describe('test edit button', () => {
        it('should show edit form with correct data and save changes', async () => {
            const bookList = {
                original: {
                    id: '1',
                    book: { author: 'Me 1', title: 'My Book 1' },
                },
                edited: { author: 'Me 1 Edited', title: 'My Book 1 Edited' },
            };

            const respList = {
                fillTable: {
                    status: 200,
                    headers: {
                        'Access-Control-Allow-Origin': '*',
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(testBooks),
                },
                edit: {
                    status: 200,
                    headers: {
                        'Access-Control-Allow-Origin': '*',
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(bookList.edited),
                },
                original: {
                    status: 200,
                    headers: {
                        'Access-Control-Allow-Origin': '*',
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(testBooks[1]),
                },
            };

            await page.route('**/jsonstore/collections/books', (route) =>
                route.fulfill(respList.fillTable)
            );

            await Promise.all([
                page.waitForResponse('**/jsonstore/collections/books'),
                page.click('#loadBooks'),
            ]);

            await page.route('**/jsonstore/collections/books/**', (route) => {
                const replies = {
                    get: respList.original,
                    put: respList.edit,
                    delete: respList.del,
                };

                const method = route.request().method();
                route.fulfill(replies[method.toLowerCase()]);
            });

            let [create, edit] = await Promise.all([
                page.isVisible('form#createForm'),
                page.isVisible('form#editForm'),
            ]);

            expect(create).to.equal(true);
            expect(edit).to.equal(false);

            await page.click('tr[data-id="3"] button.editBtn');

            [create, edit] = await Promise.all([
                page.isVisible('form#createForm'),
                page.isVisible('form#editForm'),
            ]);

            expect(create).to.equal(false);
            expect(edit).to.equal(true);

            let [tit, auth] = await Promise.all([
                page.$eval('#editForm > input[name="title"]', (el) => el.value),
                page.$eval(
                    '#editForm > input[name="author"]',
                    (el) => el.value
                ),
            ]);

            expect(tit).to.equal('');
            expect(auth).to.equal('');

            await page.fill(
                '#editForm > input[name="title"]',
                bookList.edited.title
            );
            await page.fill(
                '#editForm > input[name="author"]',
                bookList.edited.author
            );

            await page.click('#editForm > button');

            [tit, auth] = await Promise.all([
                page.$eval('#editForm > input[name="title"]', (el) => el.value),
                page.$eval(
                    '#editForm > input[name="author"]',
                    (el) => el.value
                ),
            ]);

            expect(tit).to.equal('');
            expect(auth).to.equal('');
        });
    });
    describe('test delete btn', () => {
        it.only('should delete book', async () => {
            const bookList = {
                original: {
                    id: '1',
                    book: { author: 'Me 1', title: 'My Book 1' },
                },
                deleted: { author: 'Me 1', title: 'My Book 1' },
            };

            const respList = {
                fillTable: {
                    status: 200,
                    headers: {
                        'Access-Control-Allow-Origin': '*',
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(testBooks),
                },
                del: {
                    status: 200,
                    headers: {
                        'Access-Control-Allow-Origin': '*',
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(bookList.deleted),
                },
                original: {
                    status: 200,
                    headers: {
                        'Access-Control-Allow-Origin': '*',
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(testBooks[1]),
                },
            };

            await page.route('**/jsonstore/collections/books', (route) => {
                const replies = {
                    get: respList.fillTable,
                    delete: replies.del,
                };
                const method = route.request().method();
                route.fulfill(replies[method.toLowerCase()]);
            });
            await Promise.all([
                page.waitForResponse('**/jsonstore/collections/books*'),
                page.click('#loadBooks'),
            ]);

            page.on('dialog', (dialog) => {
                dialog.accept();
            });
            await page.route('**/jsonstore/collections/books/1', (route) => {
                expect(route.request().method()).to.equal('DELETE');
                route.fulfill(respList.del);
            });
            await page.click('tr[data-id="3"] button.deleteBtn');
        });
    });
});
