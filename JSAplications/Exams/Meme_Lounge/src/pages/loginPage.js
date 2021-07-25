import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';

const loginTemplate = (formInfo) => html`
    <section id="login">
        <form @submit=${formInfo.submitHandler} id="login-form">
            <div class="container">
                <h1>Login</h1>
                <label for="email">Email</label>
                <input
                    id="email"
                    placeholder="Enter Email"
                    name="email"
                    type="text"
                />
                <label for="password">Password</label>
                <input
                    id="password"
                    type="password"
                    placeholder="Enter Password"
                    name="password"
                />
                <input type="submit" class="registerbtn button" value="Login" />
                <div class="container signin">
                    <p>Dont have an account?<a href="/register">Sign up</a>.</p>
                </div>
            </div>
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
        context.page.redirect('/all');
    } catch (err) {
        alert(err);
        e.target.reset();
        console.log(err);
    }
}

export function getLoginView(context) {
    const formInfo = {
        submitHandler: submitHandler.bind(null, context),
    };
    const templateResult = loginTemplate(formInfo);
    context.renderView(templateResult);
}
