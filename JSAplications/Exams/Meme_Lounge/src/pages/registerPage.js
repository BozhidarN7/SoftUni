import { html } from '../../node_modules/lit-html/lit-html.js';
import { showNotification } from '../helpers/showNotification.js';
import authService from '../services/authService.js';

const registerTemplate = (formInfo) => html`
    <section id="register">
        <form @submit=${formInfo.submitHandler} id="register-form">
            <div class="container">
                <h1>Register</h1>
                <label for="username">Username</label>
                <input
                    id="username"
                    type="text"
                    placeholder="Enter Username"
                    name="username"
                />
                <label for="email">Email</label>
                <input
                    id="email"
                    type="text"
                    placeholder="Enter Email"
                    name="email"
                />
                <label for="password">Password</label>
                <input
                    id="password"
                    type="password"
                    placeholder="Enter Password"
                    name="password"
                />
                <label for="repeatPass">Repeat Password</label>
                <input
                    id="repeatPass"
                    type="password"
                    placeholder="Repeat Password"
                    name="repeatPass"
                />
                <div class="gender">
                    <input
                        type="radio"
                        name="gender"
                        id="female"
                        value="female"
                    />
                    <label for="female">Female</label>
                    <input
                        type="radio"
                        name="gender"
                        id="male"
                        value="male"
                        checked
                    />
                    <label for="male">Male</label>
                </div>
                <input
                    type="submit"
                    class="registerbtn button"
                    value="Register"
                />
                <div class="container signin">
                    <p>Already have an account?<a href="/login">Sign in</a>.</p>
                </div>
            </div>
        </form>
    </section>
`;

async function submitHandler(context, e) {
    e.preventDefault();
    const data = new FormData(e.currentTarget);
    const username = data.get('username');
    const email = data.get('email');
    const password = data.get('password');
    const repeatPass = data.get('repeatPass');
    const gender = data.get('gender');

    if (!username || !email || !password || !repeatPass || !gender) {
        showNotification(`All fields are required!`);
        return;
    }
    if (password !== repeatPass) {
        showNotification(`Password mismatch!`);
        return;
    }

    try {
        await authService.register({ username, email, password, gender });
        context.page.redirect('/all');
    } catch (err) {
        showNotification(`Unsuccessful registration`);
        console.log(err);
    }
}

export function getRegisterView(context) {
    const formInfo = {
        submitHandler: submitHandler.bind(null, context),
    };
    const templateResult = registerTemplate(formInfo);
    context.renderView(templateResult);
}
