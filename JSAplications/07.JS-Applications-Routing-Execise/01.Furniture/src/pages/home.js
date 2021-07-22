import { render } from '../../node_modules/lit-html/lit-html.js';

import { homeTemplate } from '../templates/templates.js';

const containerDiv = document.querySelector('#root');

export function initializeHome(context) {
    renderHomePage();
}

function renderHomePage() {
    render(homeTemplate(), containerDiv);
}
