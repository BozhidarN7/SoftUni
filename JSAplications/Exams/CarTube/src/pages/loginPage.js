import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';

const loginTemplate = (formInfo) => html` <section id="login">
    <div class="container">
        <form
            @submit=${formInfo.submitHandler}
            id="login-form"
            action="#"
            method="post"
        >
            <h1>Login</h1>
            <p>Please enter your credentials.</p>
            <hr />

            <p>Username</p>
            <input placeholder="Enter Username" name="username" type="text" />

            <p>Password</p>
            <input
                type="password"
                placeholder="Enter Password"
                name="password"
            />
            <input type="submit" class="registerbtn" value="Login" />
        </form>
        <div class="signin">
            <p>Dont have an account? <a href="/register">Sign up</a>.</p>
        </div>
    </div>
</section>`;

async function submitHandler(context, e) {
    e.preventDefault();

    const data = new FormData(e.currentTarget);
    const username = data.get('username');
    const password = data.get('password');

    if (!username || !password) {
        alert('All fields are required!');
        return;
    }

    try {
        await authService.login({ username, password });
        context.page.redirect('/allListings');
    } catch (err) {
        alert(err);
        e.target.reset();
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
