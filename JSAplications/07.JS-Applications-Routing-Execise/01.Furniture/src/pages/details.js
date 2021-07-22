import { render } from '../../node_modules/lit-html/lit-html.js';
import furnitureService from '../services/furnitureService.js';
import { detailsTemplate, furnitureTemplate } from '../templates/templates.js';

export function initializeDetails(context) {
    furnitureService
        .getOne(context.params.id)
        .then((furniture) => renderDetailsPage(furniture));
}

function renderDetailsPage(furniture) {
    console.log(furniture);
    render(detailsTemplate(furniture), document.querySelector('#root'));
}
