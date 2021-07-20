import { render } from './node_modules/lit-html/lit-html.js';
import { towns } from './towns.js';
import { townTemplateFunc } from './townTemplate.js';

render(townTemplateFunc(towns), document.querySelector('#towns'));

function search() {
    const searchField = document.querySelector('#searchText');
    const searchBtn = document.querySelector('button');

    searchBtn.addEventListener('click', () => {
        const searchValue = searchField.value;
        let matches = 0;
        [...document.querySelector('#towns ul').children].forEach((li) => {
            if (
                li.textContent.toLowerCase().includes(searchValue.toLowerCase())
            ) {
                li.classList.add('active');
                matches++;
            }
        });
        document.querySelector('#result').textContent = matches;
    });
}

search();
