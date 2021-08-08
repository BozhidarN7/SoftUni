import { html } from '../../node_modules/lit-html/lit-html.js';
import bookService from '../services/bookService.js';

const createTemplate = (formInfo) => html`
    <section id="create-page" class="create">
        <form
            @submit=${formInfo.submitHandler}
            id="create-form"
            action=""
            method=""
        >
            <fieldset>
                <legend>Add new Book</legend>
                <p class="field">
                    <label for="title">Title</label>
                    <span class="input">
                        <input
                            type="text"
                            name="title"
                            id="title"
                            placeholder="Title"
                        />
                    </span>
                </p>
                <p class="field">
                    <label for="description">Description</label>
                    <span class="input">
                        <textarea
                            name="description"
                            id="description"
                            placeholder="Description"
                        ></textarea>
                    </span>
                </p>
                <p class="field">
                    <label for="image">Image</label>
                    <span class="input">
                        <input
                            type="text"
                            name="imageUrl"
                            id="image"
                            placeholder="Image"
                        />
                    </span>
                </p>
                <p class="field">
                    <label for="type">Type</label>
                    <span class="input">
                        <select id="type" name="type">
                            <option value="Fiction">Fiction</option>
                            <option value="Romance">Romance</option>
                            <option value="Mistery">Mistery</option>
                            <option value="Classic">Clasic</option>
                            <option value="Other">Other</option>
                        </select>
                    </span>
                </p>
                <input class="button submit" type="submit" value="Add Book" />
            </fieldset>
        </form>
    </section>
`;

async function submitHandler(context, e) {
    e.preventDefault();

    const data = new FormData(e.currentTarget);
    const title = data.get('title');
    const description = data.get('description');
    const imageUrl = data.get('imageUrl');
    const type = data.get('type');

    if (!title || !description || !imageUrl || !type) {
        alert('All fields are required!');
        return;
    }

    try {
        await bookService.create({ title, description, imageUrl, type });
        context.page.redirect('/dashboard');
    } catch (err) {
        alert('Unssuccessful creation!');
        console.log(err);
    }
}

export function getCreatePage(context) {
    const formInfo = {
        submitHandler: submitHandler.bind(null, context),
    };
    const templateResult = createTemplate(formInfo);
    context.renderView(templateResult);
}
