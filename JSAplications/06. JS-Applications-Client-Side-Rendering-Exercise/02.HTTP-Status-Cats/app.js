import { render } from './node_modules/lit-html/lit-html.js';
import { catTemplateFunc } from './catTemplate.js';
import { cats } from './catSeeder.js';

window.addEventListener('load', () => {
    render(catTemplateFunc(cats), document.querySelector('#allCats'));
});
