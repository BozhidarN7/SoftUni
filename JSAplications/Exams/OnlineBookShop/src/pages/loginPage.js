import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';

const loginTemplate = (formInfo) => html`
    <section id="login-page" class="login">
        <form
            @submit=${formInfo.submitHandler}
            id="login-form"
            action=""
            method=""
        >
            <fieldset>
                <legend>Login Form</legend>
                <p class="field">
                    <label for="email">Email</label>
                    <span class="input">
                        <input
                            type="text"
                            name="email"
                            id="email"
                            placeholder="Email"
                        />
                    </span>
                </p>
                <p class="field">
                    <label for="password">Password</label>
                    <span class="input">
                        <input
                            type="password"
                            name="password"
                            id="password"
                            placeholder="Password"
                        />
                    </span>
                </p>
                <input class="button submit" type="submit" value="Login" />
            </fieldset>
        </form>
    </section>
`;

async function submitHandler(context, e) {
    e.preventDefault();

    const data = new FormData(e.currentTarget);
    const email = data.get('email');
    const password = data.get('password');

    if (!email || !password) {
        alert('All fields are required!');
        return;
    }

    try {
        await authService.login({ email, password });
        context.page.redirect('/dashboard');
    } catch (err) {
        e.target.reset();
        alert('Login failed');
        console.log(err);
    }
}

export function getLoginPage(context) {
    const formInfo = {
        submitHandler: submitHandler.bind(null, context),
    };
    const templateResult = loginTemplate(formInfo);
    context.renderView(templateResult);
}
