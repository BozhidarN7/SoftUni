import { render } from '../../node_modules/lit-html/lit-html.js';

import { registerTemplate } from '../templates/templates.js';

const containerDiv = document.querySelector('#root');

export const initializeRegister = (context) => {
    renderRegisterPage();
    const form = document.querySelector('form');
    o;
};

function renderRegisterPage(context) {
    render(registerTemplate(), containerDiv);
}
