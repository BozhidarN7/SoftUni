import { render } from '../node_modules/lit-html/lit-html.js';
import { navTemplate } from './templates/templates.js';

import auth from './services/authService.js';

export function initializeNav(context, next) {
    const navInfo = {
        pathname: context.pathname,
    };
    render(navTemplate(navInfo), document.querySelector('#nav'));
    next();
}

export function setNavigation() {
    const userDiv = document.querySelector('#user');
    const guestDiv = document.querySelector('#guest');
    if (auth.getAuthToken()) {
        userDiv.classList.remove('hidden');
        guestDiv.classList.add('hidden');
    } else {
        userDiv.classList.add('hidden');
        guestDiv.classList.remove('hidden');
    }
}
