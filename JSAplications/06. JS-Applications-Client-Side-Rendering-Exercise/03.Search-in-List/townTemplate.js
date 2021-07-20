import { html } from './node_modules/lit-html/lit-html.js';

export function townTemplateFunc(towns) {
    return html`
        <ul>
            ${towns.map((town) => html`<li>${town}</li>`)}
        </ul>
    `;
}
