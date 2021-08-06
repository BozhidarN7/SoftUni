import { html } from '../../node_modules/lit-html/lit-html.js';
import { ifDefined } from '../../node_modules/lit-html/directives/if-defined.js';
import authService from '../services/authService.js';
const registerTemplate = (formInfo) => html`
    <section id="register">
        <article class="narrow">
            <header class="pad-med">
                <h1>Register</h1>
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
                <label>Username: <input type="text" name="username" /></label>
                <label
                    >Password: <input type="password" name="password"
                /></label>
                <label>Repeat: <input type="password" name="repass" /></label>
                <input
                    class="action cta"
                    type="submit"
                    value="Create Account"
                />
            </form>
            <footer class="pad-small">
                Already have an account?
                <a href="/login" class="invert">Sign in here</a>
            </footer>
        </article>
    </section>
`;

function showError(context, message) {
    const formInfo = {
        submitHandler: submitHandler.bind(null, context),
        message: 'Email is invalid',
    };
    const templateResult = registerTemplate(formInfo);
    context.renderView(templateResult);
}

async function submitHandler(context, e) {
    e.preventDefault();

    const data = new FormData(e.currentTarget);
    const email = data.get('email');
    const username = data.get('username');
    const password = data.get('password');
    const repass = data.get('repass');

    if (!email.trim()) {
        showError(context, 'Invalid email');
        return;
    }
    if (username.length < 3) {
        showError(context, 'Username must be at least 3 characters long');
        return;
    }
    if (!password || password !== repass) {
        showError(context, 'Passowrd mismatch!');
        return;
    }

    try {
        await authService.register({ email, username, password });
        context.page.redirect('/myTeams');
    } catch (err) {
        showError('Registration failed!');
        return;
    }
}

export function getRegisterPage(context) {
    const formInfo = {
        submitHandler: submitHandler.bind(null, context),
        message: undefined,
    };
    const templateResult = registerTemplate(formInfo);
    context.renderView(templateResult);
}
