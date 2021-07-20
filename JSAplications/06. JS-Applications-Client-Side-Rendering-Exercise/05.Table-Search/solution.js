import { html, render } from './node_modules/lit-html/lit-html.js';

const baseUrl = 'http://localhost:3030/jsonstore/advanced/table';

window.addEventListener('load', async () => {
    try {
        const res = await fetch(baseUrl);

        if (!res.ok) {
            throw new Error('Smth went wrong');
        }

        const rows = await res.json();
        const arrRows = Object.values(rows).map((row) => tableRowTemplate(row));
        render(arrRows, document.querySelector('table tbody'));
    } catch (err) {
        console.log(err);
    }
    solve();
});

const tableRowTemplate = (row) => html`
    <tr>
        <td>${row.firstName} ${row.lastName}</td>
        <td>${row.email}</td>
        <td>${row.course}</td>
    </tr>
`;

function solve() {
    document.querySelector('#searchBtn').addEventListener('click', onClick);
    const searchField = document.querySelector('#searchField');
    const rowEls = document.querySelectorAll('tbody > tr');
    function onClick() {
        Array.from(rowEls).forEach((row) => row.classList.remove('select'));
        Array.from(rowEls).forEach((row) => {
            if (row.textContent.includes(searchField.value)) {
                row.classList.add('select');
            }
        });
        searchField.value = '';
    }
}
