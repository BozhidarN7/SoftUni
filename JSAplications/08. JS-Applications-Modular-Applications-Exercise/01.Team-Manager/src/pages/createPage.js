import { html } from '../../node_modules/lit-html/lit-html.js';
import teamService from '../services/teamService.js';

const createTemplate = (formInfo) => html`
    <section id="create">
        <article class="narrow">
            <header class="pad-med">
                <h1>New Team</h1>
            </header>
            <form
                @submit=${formInfo.submitHandler}
                id="create-form"
                class="main-form pad-large"
            >
                <div class="error ${formInfo.message ? '' : 'hidden'}">
                    Error message.
                </div>
                <label>Team name: <input type="text" name="name" /></label>
                <label>Logo URL: <input type="text" name="logoUrl" /></label>
                <label
                    >Description:
                    <textarea name="description"></textarea>
                </label>
                <input class="action cta" type="submit" value="Create Team" />
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
    const name = data.get('name');
    const logoUrl = data.get('logoUrl');
    const description = data.get('description');

    if (name.length < 4) {
        showError(context, 'Name must be at least 4 characters long!');
        return;
    }

    try {
        const team = await teamService.create({ name, logoUrl, description });
        console.log(team);
        context.page.redirect(`/details/${team._id}`);
    } catch (err) {
        showError('Registration failed!');
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
