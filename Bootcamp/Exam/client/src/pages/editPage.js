import { html } from '../../node_modules/lit-html/lit-html.js';
import { ifDefined } from '../../node_modules/lit-html/directives/if-defined.js';
import jobService from '../services/jobService.js';

const editTemplate = (formInfo) => html`
    <section id="edit">
        <article class="narrow">
            <header class="pad-med">
                <h1>Edit Job</h1>
            </header>
            <form
                @submit=${ifDefined(formInfo.submitHandler)}
                id="edit-form"
                class="main-form pad-large"
            >
                <div class="error ${formInfo.message ? '' : 'hidden'}">
                    ${formInfo.message}
                </div>
                <label
                    >Job title:
                    <input
                        type="text"
                        name="title"
                        .value=${ifDefined(formInfo.job?.title)}
                /></label>
                <label
                    >Image URL:
                    <input
                        type="text"
                        name="imageUrl"
                        .value=${ifDefined(formInfo.job?.imageUrl)}
                /></label>
                <label
                    >Description:
                    <textarea
                        name="description"
                        .value=${formInfo.job?.description}
                    ></textarea>
                </label>
                <input class="action cta" type="submit" value="Save Changes" />
            </form>
        </article>
    </section>
`;

function showError(context, message) {
    const formInfo = {
        submitHandler: submitHandler.bind(null, context),
        message,
        job: undefined,
    };
    const templateResult = editTemplate(formInfo);
    context.renderView(templateResult);
}

async function submitHandler(context, e) {
    e.preventDefault();

    const data = new FormData(e.currentTarget);
    const title = data.get('title');
    const imageUrl = data.get('imageUrl');
    const description = data.get('description');

    try {
        const job = await jobService.edit(context.params.id, {
            title,
            description,
            imageUrl,
        });
        console.log(job);
        context.page.redirect(`/details/${job._id}`);
    } catch (err) {
        showError(context, 'Error');
        return;
    }
}

export async function getEditPage(context) {
    const job = await jobService.getById(context.params.id);
    const formInfo = {
        submitHandler: submitHandler.bind(null, context),
        message: undefined,
        job,
    };
    const templateResult = editTemplate(formInfo);
    context.renderView(templateResult);
}
