import { html } from '../../node_modules/lit-html/lit-html.js';
import { showNotification } from '../helpers/showNotification.js';
import memeService from '../services/memeService.js';

const createTemplate = (formInfo) => html`
    <section id="create-meme">
        <form @submit=${formInfo.submitHandler} id="create-form">
            <div class="container">
                <h1>Create Meme</h1>
                <label for="title">Title</label>
                <input
                    id="title"
                    type="text"
                    placeholder="Enter Title"
                    name="title"
                />
                <label for="description">Description</label>
                <textarea
                    id="description"
                    placeholder="Enter Description"
                    name="description"
                ></textarea>
                <label for="imageUrl">Meme Image</label>
                <input
                    id="imageUrl"
                    type="text"
                    placeholder="Enter meme ImageUrl"
                    name="imageUrl"
                />
                <input
                    type="submit"
                    class="registerbtn button"
                    value="Create Meme"
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
        showNotification(`All fields are required!`);

        return;
    }

    try {
        await memeService.create({ title, description, imageUrl });
        context.page.redirect('/all');
    } catch (err) {
        showNotification(`Unsuccessful edit`);
        console.log(err);
    }
}

export function getCreateView(context) {
    const formInfo = {
        submitHandler: submitHandler.bind(null, context),
    };
    const templateResult = createTemplate(formInfo);
    context.renderView(templateResult);
}
