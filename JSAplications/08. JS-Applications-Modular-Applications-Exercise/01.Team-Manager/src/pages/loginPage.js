import { html } from '../../node_modules/lit-html/lit-html.js';
import { ifDefined } from '../../node_modules/lit-html/directives/if-defined.js';
import authService from '../services/authService.js';
const registerTemplate = (formInfo) => html`
    <section id="login">
        <article class="narrow">
            <header class="pad-med">
                <h1>Login</h1>
            </header>
            <form
                @submit=${formInfo.submitHandler}
                id="login-form"
                class="main-form pad-large"
            >
                <div class="error ${formInfo.message ? '' : 'hidden'}">
                    Error message.
                </div>
                <label>E-mail: <input type="text" name="email" /></label>
                <label
                    >Password: <input type="password" name="password"
                /></label>
                <input class="action cta" type="submit" value="Sign In" />
            </form>
            <footer class="pad-small">
                Don't have an account?
                <a href="/register" class="invert">Sign up here</a>
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
    const password = data.get('password');

    if (!email.trim()) {
        showError(context, 'Invalid email');
        return;
    }

    try {
        await authService.login({ email, password });
        context.page.redirect('/myTeams');
    } catch (err) {
        showError('Registration failed!');
        return;
    }
}

export function getLoginPage(context) {
    const formInfo = {
        submitHandler: submitHandler.bind(null, context),
        message: undefined,
    };
    const templateResult = registerTemplate(formInfo);
    context.renderView(templateResult);
}
