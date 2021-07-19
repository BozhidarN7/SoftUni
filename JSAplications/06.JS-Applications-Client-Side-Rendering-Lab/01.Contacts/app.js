import { render } from './node_modules/lit-html/lit-html.js';
import { contacts } from './contacts.js';
import contactsView from './contactView.js';
import contactView from './contactView.js';

window.addEventListener('load', () => {
    const contactTemplates = [];
    contacts.forEach((contact) =>
        contactTemplates.push(contactView.contactTemplate(contact))
    );
    render(contactTemplates, document.querySelector('#contacts'));
});
