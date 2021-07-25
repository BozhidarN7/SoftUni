import page from '../node_modules/page/page.mjs';
import { navGetView } from './nav.js';
import { guestGetView } from './pages/guestPage.js';
import {
    initializeNav,
    decorateContext,
} from './middlewares/renderingMiddleware.js';
import { getLoginView } from './pages/loginPage.js';
import { getRegisterView } from './pages/registerPage.js';
import authService from './services/authService.js';

const navEl = document.querySelector('#nav');
const mainEl = document.querySelector('#root');

initializeNav(navEl, mainEl);

page('/home', decorateContext, navGetView, guestGetView);
page('/', decorateContext, navGetView, guestGetView);
page('/login', decorateContext, navGetView, getLoginView);
page('/register', decorateContext, navGetView, getRegisterView);
page('/logout', async (context) => {
    await authService.logout();
    context.page.redirect('/home');
});

page.start();
