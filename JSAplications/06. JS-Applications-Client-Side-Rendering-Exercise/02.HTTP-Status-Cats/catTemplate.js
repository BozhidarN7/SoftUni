import { html } from './node_modules/lit-html/lit-html.js';

export function catTemplateFunc(cats) {
    return html`
        <ul>
            ${cats.map(
                (cat) => html`
                    <li>
                        <img
                            src="./images/${cat.imageLocation}.jpg"
                            width="250"
                            height="250"
                            alt="Card image cap"
                        />
                        <div class="info">
                            <button @click=${showInfo} class="showBtn">
                                Show status code
                            </button>
                            <div class="status" style="display: none" id="100">
                                <h4>Status Code: ${cat.statusCode}</h4>
                                <p>${cat.statusMessage}</p>
                            </div>
                        </div>
                    </li>
                `
            )}
        </ul>
    `;
}

function showInfo(e) {
    if (
        !e.target.nextElementSibling.style.display ||
        e.target.nextElementSibling.style.display === 'none'
    ) {
        e.target.textContent = 'Hide status code';
        e.target.nextElementSibling.style.display = 'block';
    } else {
        e.target.nextElementSibling.style.display = 'none';
        e.target.textContent = 'Show status code';
    }
}
