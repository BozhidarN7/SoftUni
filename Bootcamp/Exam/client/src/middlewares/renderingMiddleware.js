import { render } from '../../node_modules/lit-html/lit-html.js';

let navContainer = undefined;
let viewContainer = undefined;

export function initializeNav(navContainerDomEl, viewContainerDomEl) {
    navContainer = navContainerDomEl;
    viewContainer = viewContainerDomEl;
}

function renderView(templateResult) {
    render(templateResult, viewContainer);
}

function renderNav(templateResult) {
    render(templateResult, navContainer);
}

export function decorateContext(context, next) {
    context.renderView = renderView;
    context.renderNav = renderNav;
    next();
}
