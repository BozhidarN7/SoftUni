import { render, html } from './node_modules/lit-html/lit-html.js';

const inputField = document.querySelector('#itemText');
const submitBtn = document.querySelector('input[type="submit"]');

const baseUrl = 'http://localhost:3030/jsonstore/advanced/dropdown';

let optionsArr = undefined;

window.addEventListener('load', async () => {
    try {
        const data = await (await fetch(baseUrl)).json();
        optionsArr = Object.values(data).map((option) =>
            optionTemplate(option)
        );
        render(optionsArr, document.querySelector('#menu'));
    } catch (err) {
        console.log(err);
    }
});

const optionTemplate = (option) =>
    html`<option value=${option._id}>${option.text}</option>`;

async function addItem(e) {
    e.preventDefault();
    const town = inputField.value;
    try {
        const res = await fetch(baseUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/josn',
            },
            body: JSON.stringify({
                text: town,
            }),
        });

        if (!res.ok) {
            throw new Error('Smth went wrong');
        }

        const newTown = await res.json();
        optionsArr.push(optionTemplate(newTown));
        render(optionsArr, document.querySelector('#menu'));
        inputField.value = '';
    } catch (err) {
        console.log(err);
    }
}

submitBtn.addEventListener('click', addItem);
