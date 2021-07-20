import { html, render } from './node_modules/lit-html/lit-html.js';

const townField = document.querySelector('#towns');
const loadTownsBtn = document.querySelector('#btnLoadTowns');

loadTownsBtn.addEventListener('click', (e) => {
    e.preventDefault();
    const townsArr = townField.value.split(', ');
    console.log(townsArr);
    render(townListTemplate(townsArr), document.querySelector('#root'));
});

const townListTemplate = (towns) => html`
    <ul>
        ${towns.map((town) => html`<li>${town}</li>`)}
    </ul>
`;
