import { html } from '../../node_modules/lit-html/lit-html.js';
import memeService from '../services/memeService.js';

const editTemplate = (formInfo) => html`
    <section id="edit-meme">
        <form @submit=${formInfo.submitHandler} id="edit-form">
            <h1>Edit Meme</h1>
            <div class="container">
                <label for="title">Title</label>
                <input
                    id="title"
                    type="text"
                    placeholder="Enter Title"
                    name="title"
                    .value=${formInfo.meme.title}
                />
                <label for="description">Description</label>
                <textarea
                    id="description"
                    placeholder="Enter Description"
                    name="description"
                >
${formInfo.meme.description}</textarea
                >
                <label for="imageUrl">Image Url</label>
                <input
                    id="imageUrl"
                    type="text"
                    placeholder="Enter Meme ImageUrl"
                    name="imageUrl"
                    .value=${formInfo.meme.imageUrl}
                />
                <input
                    type="submit"
                    class="registerbtn button"
                    value="Edit Meme"
                />
            </div>
        </form>
    </section>
`;

async function submitHandler(context, e) {
    e.preventDefault();

    const data = new FormData(e.currentTarget);
    const title = data.get('title');
    const description = data.get('description');
    const imageUrl = data.get('imageUrl');

    if (!title || !description || !imageUrl) {
        alert('All fields are required!');
        return;
    }

    try {
        await memeService.edit(context.params.id, {
            title,
            description,
            imageUrl,
        });
        context.page.redirect(`/details/${context.params.id}`);
    } catch (err) {
        alert(err);
        console.log(err);
    }
}

export async function getEditView(context) {
    const id = context.params.id;
    const meme = await memeService.getById(id);
    const formInfo = {
        submitHandler: submitHandler.bind(null, context),
        meme: meme,
    };
    const templateResult = editTemplate(formInfo);
    context.renderView(templateResult);
}
