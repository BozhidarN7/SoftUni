import { render } from '../../node_modules/lit-html/lit-html.js';
import furnitureService from '../services/furnitureService.js';

import { createTemplate, furnitureTemplate } from '../templates/templates.js';
import { editHandler } from './edit.js';

const containerDiv = document.querySelector('#root');

export function initializeCreate(context) {
    renderCreatePage();
    const form = document.querySelector('form');
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        createFurnitureHandler.call(e, context);
    });
}

async function createFurnitureHandler(context) {
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
        await furnitureService.create({
            make,
            model,
            year,
            description,
            price,
            img,
            material,
        });
        context.page.redirect('/home');
    } catch (err) {
        this.target.reset();
        context.page.redirect('/create');
        console.log(err);
    }
}

function renderCreatePage() {
    render(createTemplate(undefined, false), containerDiv);
}
