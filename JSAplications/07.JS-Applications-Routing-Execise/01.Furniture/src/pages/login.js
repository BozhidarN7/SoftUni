import { render } from '../../node_modules/lit-html/lit-html.js';
import auth from '../services/authService.js';

import { loginTemplate } from '../templates/templates.js';

const containerDiv = document.querySelector('#root');

export function initializeLogin(context) {
    renderLoginPage();
    const form = document.querySelector('form');
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        auth.login.call(e, context);
    });
}

function renderLoginPage() {
    render(loginTemplate(), containerDiv);
}
