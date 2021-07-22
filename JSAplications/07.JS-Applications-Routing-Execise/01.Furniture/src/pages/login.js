import { render } from '../../node_modules/lit-html/lit-html.js';

import { loginTemplate } from '../templates/templates.js';

const containerDiv = document.querySelector('#root');

export function initializeLogin(context) {
    renderLoginPage();
}

function renderLoginPage() {
    render(loginTemplate(), containerDiv);
}
