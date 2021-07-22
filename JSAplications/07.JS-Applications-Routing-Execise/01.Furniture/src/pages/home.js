import { render } from '../../node_modules/lit-html/lit-html.js';
import furnitureService from '../services/furnitureService.js';

import { homeTemplate } from '../templates/templates.js';

const containerDiv = document.querySelector('#root');

export function initializeHome(context) {
    furnitureService.getAll().then((furnitures) => renderHomePage(furnitures));
}

function renderHomePage(furnitures) {
    render(homeTemplate(furnitures), containerDiv);
}
