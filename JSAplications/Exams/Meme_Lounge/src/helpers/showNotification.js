import { html, render } from '../../node_modules/lit-html/lit-html.js';

const notificationTemplate = (message) => html`
    <div id="errorBox" class="notification">
        <span>${message}</span>
    </div>
`;

const notificationSection = document.querySelector('#notifications');

export function showNotification(message) {
    render(notificationTemplate(message), notificationSection);
    setTimeout(() => notificationSection?.children[0]?.remove(), 3000);
}
