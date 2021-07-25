import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import memeService from '../services/memeService.js';

const detailsTemplate = (meme, deleteHandler) => html`<section
    id="meme-details"
>
    <h1>${meme.title}</h1>
    <div class="meme-details">
        <div class="meme-img">
            <img
                alt="meme-alt"
                src="${meme.imageUrl.startsWith('/')
                    ? `../../${meme.imageUrl}`
                    : `${meme.imageUrl}`}"
            />
        </div>
        <div class="meme-description">
            <h2>Meme Description</h2>
            <p>${meme.description}</p>
            ${meme._ownerId === authService.getUserId()
                ? html`<a class="button warning" href="/edit/${meme._id}"
                          >Edit</a
                      >
                      <button @click=${deleteHandler} class="button danger">
                          Delete
                      </button>`
                : ''}
        </div>
    </div>
</section>`;

async function deleteHandler(context, e) {
    e.preventDefault();

    const confirmed = confirm('Are you sure you want to delete this meme!');

    if (!confirmed) {
        return;
    }
    try {
        await memeService.del(context.params.id);
        context.page.redirect('/all');
    } catch (err) {
        alert(err);
        console.log(err);
    }
}

export async function getDetailsPage(context) {
    const meme = await memeService.getById(context.params.id);
    const boundDeleteHandler = deleteHandler.bind(null, context);
    const templateResult = detailsTemplate(meme, boundDeleteHandler);
    context.renderView(templateResult);
}
