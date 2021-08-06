import { html } from '../../node_modules/lit-html/lit-html.js';
import { ifDefined } from '../../node_modules/lit-html/directives/if-defined.js';
import teamService from '../services/teamService.js';

const editTemplate = (formInfo) => html`
    <section id="edit">
        <article class="narrow">
            <header class="pad-med">
                <h1>Edit Team</h1>
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
                    >Team name:
                    <input
                        type="text"
                        name="name"
                        .value=${ifDefined(formInfo.team?.name)}
                /></label>
                <label
                    >Logo URL:
                    <input
                        type="text"
                        name="logoUrl"
                        .value=${ifDefined(formInfo.team?.logoUrl)}
                /></label>
                <label
                    >Description:
                    <textarea
                        name="description"
                        .value=${formInfo.team?.description}
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
        team: undefined,
    };
    const templateResult = editTemplate(formInfo);
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
        const team = await teamService.edit(context.params.id, {
            name,
            logoUrl,
            description,
        });
        console.log(team);
        context.page.redirect(`/details/${team._id}`);
    } catch (err) {
        showError(context, 'Error');
        return;
    }
}

export async function getEditPage(context) {
    const team = await teamService.getById(context.params.id);
    const formInfo = {
        submitHandler: submitHandler.bind(null, context),
        message: undefined,
        team,
    };
    const templateResult = editTemplate(formInfo);
    context.renderView(templateResult);
}
