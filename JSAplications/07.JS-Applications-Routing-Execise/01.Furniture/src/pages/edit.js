import { render } from '../../node_modules/lit-html/lit-html.js';
import furnitureService from '../services/furnitureService.js';

import { createTemplate } from '../templates/templates.js';

export async function initializeEdit(context) {
    // furnitureService
    //     .getOne(context.params.id)
    //     .then((furniture) => renderEditPage(furniture));
    const furniture = await furnitureService.getOne(context.params.id);
    renderEditPage(furniture);
    const form = document.querySelector('form');
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        editHandler.call(e, context);
    });
}

export async function editHandler(context) {
    this.preventDefault();

    const data = new FormData(this.currentTarget);
    const make = data.get('make');
    const model = data.get('model');
    const year = data.get('year');
    const description = data.get('description');
    const price = data.get('price');
    const img = data.get('img');
    const material = data.get('material');
    try {
        await furnitureService.edit(
            {
                make,
                model,
                year,
                description,
                price,
                img,
                material,
            },
            context.params.id
        );
        context.page.redirect('/home');
    } catch (err) {
        context.page.redirect('/edit');
        console.log(err);
    }
}

function renderEditPage(furniture) {
    render(createTemplate(furniture, true), document.querySelector('#root'));
}
