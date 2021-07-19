import { html } from './node_modules/lit-html/lit-html.js';

const contactTemplate = (contact) => html`
    <div class="contact card">
        <div>
            <i class="far fa-user-circle gravatar"></i>
        </div>
        <div class="info">
            <h2>Name: ${contact.name}</h2>
            <button @click=${showDetails} class="detailsBtn">Details</button>
            <div class="details" id="1">
                <p>Phone number: ${contact.phoneNumber}</p>
                <p>Email: ${contact.email}</p>
            </div>
        </div>
    </div>
`;

function showDetails(e) {
    if (
        !e.target.nextElementSibling.style.display ||
        e.target.nextElementSibling.style.display === 'none'
    )
        e.target.nextElementSibling.style.display = 'block';
    else e.target.nextElementSibling.style.display = 'none';
}

export default {
    contactTemplate,
};
