import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import bookService from '../services/bookService.js';

const myBooksTemplate = (books) => html`
    <section id="my-books-page" class="my-books">
        <h1>My Books</h1>
        <!-- Display ul: with list-items for every user's books (if any) -->
        ${books.length > 0
            ? html` <ul class="my-books-list">
                  ${books.map((b) => bookTemplate(b))}
              </ul>`
            : html`<p class="no-books">No books in database!</p>`}
    </section>
`;

const bookTemplate = (book) => html`
    <li class="otherBooks">
        <h3>${book.title}</h3>
        <p>Type: ${book.type}</p>
        <p class="img"><img src="${book.imageUrl}" /></p>
        <a class="button" href="/details/${book._id}">Details</a>
    </li>
`;

export async function getMyBooksPage(context) {
    const books = await bookService.getMine(authService.getUserId());
    const templateResult = myBooksTemplate(books);
    context.renderView(templateResult);
}
