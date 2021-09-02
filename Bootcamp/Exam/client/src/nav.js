import { html } from '../node_modules/lit-html/lit-html.js';

const navTemplate = () => html`
    <a href="/" class="site-logo">Job Manager</a>
    <nav>
        <a href="/create" class="action">Create Job</a>
        <a href="/addCandidate" class="action">Add Candidate</a>
    </nav>
`;

export function navGetView(context, next) {
    const templateResult = navTemplate();
    context.renderNav(templateResult);
    next();
}
