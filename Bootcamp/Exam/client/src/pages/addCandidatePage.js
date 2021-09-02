import { html } from '../../node_modules/lit-html/lit-html.js';
import candidateService from '../services/candidateService.js';
const addCandidateTemplate = (formInfo) => html`
    <section id="register">
        <article class="narrow">
            <header class="pad-med">
                <h1>Add Candidate</h1>
            </header>
            <form
                @submit=${formInfo.submitHandler}
                id="register-form"
                class="main-form pad-large"
            >
                <div class="error ${formInfo.message ? '' : 'hidden'}">
                    ${formInfo.message}
                </div>
                <label>E-mail: <input type="text" name="email" /></label>
                <label
                    >First name: <input type="text" name="firstName"
                /></label>
                <label>Last name: <input type="text" name="lastName" /></label>
                <input class="action cta" type="submit" value="Add Candidate" />
            </form>
        </article>
    </section>
`;

function showError(context, message) {
    const formInfo = {
        submitHandler: submitHandler.bind(null, context),
        message,
    };
    const templateResult = addCandidateTemplate(formInfo);
    context.renderView(templateResult);
}

async function submitHandler(context, e) {
    e.preventDefault();

    const data = new FormData(e.currentTarget);
    const email = data.get('email');
    const firstName = data.get('firstName');
    const lastName = data.get('lastName');

    try {
        const candidate = await candidateService.create({
            email,
            firstName,
            lastName,
        });
        console.log(candidate);
        context.page.redirect('/jobs');
    } catch (err) {
        showError(context, 'Adding Candidate failed!');
        return;
    }
}

export function getAddCandidatePage(context) {
    const formInfo = {
        submitHandler: submitHandler.bind(null, context),
        message: undefined,
    };
    const templateResult = addCandidateTemplate(formInfo);
    context.renderView(templateResult);
}
