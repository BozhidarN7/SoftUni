import { html } from '../../node_modules/lit-html/lit-html.js';
import bookService from '../services/bookService.js';

const bookTemplate = (book) => html`
    <li class="otherBooks">
        <h3>${book.title}</h3>
        <p>Type: ${book.type}</p>
        <p class="img"><img src="${book.imageUrl}" /></p>
        <a class="button" href="/details/${book._id}">Details</a>
    </li>
`;

const dashboardTemplate = (books) => html`<section
    id="dashboard-page"
    class="dashboard"
>
    <h1>Dashboard</h1>
    <!-- Display ul: with list-items for All books (If any) -->
    ${books.length > 0
        ? html`<ul class="other-books-list">
              ${books.map((b) => bookTemplate(b))}
          </ul>`
        : html`<p class="no-books">No books in database!</p>`}
</section>`;

export async function getDashboardPage(context) {
    const books = await bookService.getAllOrderByCreation();
    const templateResult = dashboardTemplate(books);
    context.renderView(templateResult);
}
