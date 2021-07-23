import { render } from '../../node_modules/lit-html/lit-html.js';
import auth from '../services/authService.js';
import furnitureService from '../services/furnitureService.js';

import { myFurnitureTemplate } from '../templates/templates.js';

const containerDiv = document.querySelector('#root');

export function initializeMyList(context) {
    furnitureService
        .getMyFurniture(auth.getUserId())
        .then((furnitures) => renderMyList(furnitures));
}

function renderMyList(furnitures) {
    render(myFurnitureTemplate(furnitures), containerDiv);
}
