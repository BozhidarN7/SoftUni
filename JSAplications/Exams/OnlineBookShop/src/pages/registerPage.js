import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';

const registerTemplate = (formInfo) => html`
    <section id="register-page" class="register">
        <form
            @submit=${formInfo.submitHandler}
            id="register-form"
            action=""
            method=""
        >
            <fieldset>
                <legend>Register Form</legend>
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
                <p class="field">
                    <label for="repeat-pass">Repeat Password</label>
                    <span class="input">
                        <input
                            type="password"
                            name="confirm-pass"
                            id="repeat-pass"
                            placeholder="Repeat Password"
                        />
                    </span>
                </p>
                <input class="button submit" type="submit" value="Register" />
            </fieldset>
        </form>
    </section>
`;

async function submitHandler(context, e) {
    e.preventDefault();
    const data = new FormData(e.currentTarget);
    const email = data.get('email');
    const password = data.get('password');
    const repeatPass = data.get('confirm-pass');

    if (!email || !password || !repeatPass) {
        alert('All fields are required!');
        return;
    }

    if (password !== repeatPass) {
        alert('Password mismatch!');
        return;
    }

    try {
        await authService.register({ email, password });
        context.page.redirect('/dashboard');
    } catch (err) {
        alert('Registration failed!');
        console.log(err);
    }
}

export function getRegisterPage(context) {
    const formInfo = {
        submitHandler: submitHandler.bind(null, context),
    };
    const templateResult = registerTemplate(formInfo);
    context.renderView(templateResult);
}
