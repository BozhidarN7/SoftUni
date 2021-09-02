import { html } from '../../node_modules/lit-html/lit-html.js';

import jobService from '../services/jobService.js';

const createTemplate = (formInfo) => html`
    <section id="create">
        <article class="narrow">
            <header class="pad-med">
                <h1>New Job</h1>
            </header>
            <form
                @submit=${formInfo.submitHandler}
                id="create-form"
                class="main-form pad-large"
            >
                <div class="error ${formInfo.message ? '' : 'hidden'}">
                    Error message.
                </div>
                <label>Job title: <input type="text" name="title" /></label>
                <label>Image URl: <input type="text" name="imageUrl" /></label>
                <label
                    >Description:
                    <textarea name="description"></textarea>
                </label>
                <input class="action cta" type="submit" value="Create Job" />
            </form>
        </article>
    </section>
`;

function showError(context, message) {
    const formInfo = {
        submitHandler: submitHandler.bind(null, context),
        message,
    };
    const templateResult = createTemplate(formInfo);
    context.renderView(templateResult);
}

async function submitHandler(context, e) {
    e.preventDefault();

    const data = new FormData(e.currentTarget);
    const title = data.get('title');
    const imageUrl = data.get('imageUrl');
    const description = data.get('description');

    try {
        const job = await jobService.create({ title, description, imageUrl });
        context.page.redirect(`/jobs`);
    } catch (err) {
        showError(context, 'Creation failed!');
        return;
    }
}

export function getCreatePage(context) {
    const formInfo = {
        submitHandler: submitHandler.bind(null, context),
        message: undefined,
    };
    const templateResult = createTemplate(formInfo);
    context.renderView(templateResult);
}
