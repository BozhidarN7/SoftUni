import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import bookService from '../services/bookService.js';
import likeService from '../services/likeService.js';

const detailsTemplate = (info) => html`
    <section id="details-page" class="details">
        <div class="book-information">
            <h3>${info.book.title}</h3>
            <p class="type">Type: ${info.book.type}</p>
            <p class="img"><img src="${info.book.imageUrl}" /></p>
            <div class="actions">
                ${info.loggedUserId === info.book._ownerId
                    ? html`<a class="button" href="/edit/${info.book._id}"
                              >Edit</a
                          >
                          <a
                              class="button"
                              href="javascript:void(0)"
                              @click=${info.deleteHandler}
                              >Delete</a
                          >`
                    : ''}
                ${info.loggedUserId === info.book._ownerId ||
                !info.isLoggedIn ||
                info.userhasLiked
                    ? ''
                    : html`<a
                          class="button"
                          href="javascript:void(0)"
                          @click=${info.likeHandler}
                          >Like</a
                      >`}
                <div class="likes">
                    <img class="hearts" src="/images/heart.png" />
                    <span id="total-likes">Likes: ${info.book.likes}</span>
                </div>
            </div>
        </div>
        <div class="book-description">
            <h3>Description:</h3>
            <p>${info.book.description}</p>
        </div>
    </section>
`;

async function deleteHandler(context, e) {
    e.preventDefault();

    if (confirm('Are you sure you want to delete this car ad')) {
        try {
            await bookService.del(context.params.id);
            context.page.redirect('/dashboard');
        } catch (err) {
            alert(err);
            console.log(err);
        }
    }
}

async function likeHandler(context, bookId, e) {
    e.preventDefault();

    try {
        const like = await likeService.create({ bookId });
        const book = await bookService.getById(like.bookId);
        const totalBooksLikes = await likeService.getAllBookLikes(like.bookId);
        const userhasLiked = await likeService.getIfUserHasLikedTheBook(
            book._id,
            authService.getUserId()
        );
        book.likes = totalBooksLikes;
        const info = {
            deleteHandler: deleteHandler.bind(null, context),
            likeHandler: likeHandler.bind(null, context, book._id),
            book,
            loggedUserId: authService.getUserId(),
            isLoggedIn: authService.isLoggeddIn(),
            userhasLiked,
        };
        const templateResult = detailsTemplate(info);
        context.renderView(templateResult);
    } catch (err) {
        alert('Smth went wrong!');
        console.log(err);
    }
}

export async function getDetailsPage(context) {
    const book = await bookService.getById(context.params.id);
    const totalBooksLikes = await likeService.getAllBookLikes(book._id);
    const userhasLiked = await likeService.getIfUserHasLikedTheBook(
        book._id,
        authService.getUserId()
    );
    book.likes = totalBooksLikes;
    const info = {
        deleteHandler: deleteHandler.bind(null, context),
        likeHandler: likeHandler.bind(null, context, book._id),
        book,
        loggedUserId: authService.getUserId(),
        isLoggedIn: authService.isLoggeddIn(),
        userhasLiked,
    };
    const templateResult = detailsTemplate(info);
    context.renderView(templateResult);
}
