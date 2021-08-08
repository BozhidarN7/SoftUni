import { html } from '../../node_modules/lit-html/lit-html.js';
import bookService from '../services/bookService.js';

const editTemplate = (formInfo) => html`
    <section id="edit-page" class="edit">
        <form
            @submit=${formInfo.submitHandler}
            id="edit-form"
            action="#"
            method=""
        >
            <fieldset>
                <legend>Edit my Book</legend>
                <p class="field">
                    <label for="title">Title</label>
                    <span class="input">
                        <input
                            type="text"
                            name="title"
                            id="title"
                            .value=${formInfo.book.title}
                        />
                    </span>
                </p>
                <p class="field">
                    <label for="description">Description</label>
                    <span class="input">
                        <textarea
                            name="description"
                            id="description"
                            .value=${formInfo.book.description}
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
                            .value=${formInfo.book.imageUrl}
                        />
                    </span>
                </p>
                <p class="field">
                    <label for="type">Type</label>
                    <span class="input">
                        <select
                            id="type"
                            name="type"
                            .value=${formInfo.book.type}
                        >
                            <option value="Fiction" selected>Fiction</option>
                            <option value="Romance">Romance</option>
                            <option value="Mistery">Mistery</option>
                            <option value="Classic">Clasic</option>
                            <option value="Other">Other</option>
                        </select>
                    </span>
                </p>
                <input class="button submit" type="submit" value="Save" />
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
        await bookService.edit(context.params.id, {
            title,
            description,
            imageUrl,
            type,
        });
        context.page.redirect(`/details/${context.params.id}`);
    } catch (err) {
        alert('Edit failed');
        console.log(err);
    }
}

export async function getEditPage(context) {
    const id = context.params.id;
    const book = await bookService.getById(id);
    const formInfo = {
        submitHandler: submitHandler.bind(null, context),
        book,
    };
    const templateResult = editTemplate(formInfo);
    context.renderView(templateResult);
}
