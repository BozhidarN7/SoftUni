import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';

const registerTemplate = (formInfo) => html` <section id="register">
    <div class="container">
        <form @submit=${formInfo.submitHandler} id="register-form">
            <h1>Register</h1>
            <p>Please fill in this form to create an account.</p>
            <hr />

            <p>Username</p>
            <input
                type="text"
                placeholder="Enter Username"
                name="username"
                required
            />

            <p>Password</p>
            <input
                type="password"
                placeholder="Enter Password"
                name="password"
                required
            />

            <p>Repeat Password</p>
            <input
                type="password"
                placeholder="Repeat Password"
                name="repeatPass"
                required
            />
            <hr />

            <input type="submit" class="registerbtn" value="Register" />
        </form>
        <div class="signin">
            <p>Already have an account? <a href="/login">Sign in</a>.</p>
        </div>
    </div>
</section>`;

async function submitHandler(context, e) {
    e.preventDefault();
    const data = new FormData(e.currentTarget);
    const username = data.get('username');
    const password = data.get('password');
    const repeatPass = data.get('repeatPass');

    if (!username || !password || !repeatPass) {
        alert('All fields are required!');
        return;
    }

    if (password !== repeatPass) {
        alert('Password mismatch!');
        return;
    }

    try {
        await authService.register({ username, password });
        context.page.redirect('/allListings');
    } catch (err) {
        alert(err);
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
