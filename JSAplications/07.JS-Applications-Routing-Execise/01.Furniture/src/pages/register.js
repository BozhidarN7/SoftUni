import { render } from '../../node_modules/lit-html/lit-html.js';
import auth from '../services/authService.js';

import { registerTemplate } from '../templates/templates.js';

const containerDiv = document.querySelector('#root');

export const initializeRegister = (context) => {
    renderRegisterPage();
    const form = document.querySelector('form');
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        auth.register.call(e, context);
    });
};

function renderRegisterPage() {
    render(registerTemplate(), containerDiv);
}
