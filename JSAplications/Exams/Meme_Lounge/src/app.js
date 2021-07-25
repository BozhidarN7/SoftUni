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
import { getAllMemesPage } from './pages/allMemes.js';
import { getDetailsPage } from './pages/detailsPage.js';
import { getCreateView } from './pages/createPage.js';
import { getEditView } from './pages/editPage.js';

const navEl = document.querySelector('#nav');
const mainEl = document.querySelector('#root');

initializeNav(navEl, mainEl);

page('/home', decorateContext, navGetView, guestGetView);
page('/', decorateContext, navGetView, guestGetView);
page('/all', decorateContext, navGetView, getAllMemesPage);
page('/details/:id', decorateContext, navGetView, getDetailsPage);
page('/edit/:id', decorateContext, navGetView, getEditView);
page('/create', decorateContext, navGetView, getCreateView);
page('/login', decorateContext, navGetView, getLoginView);
page('/register', decorateContext, navGetView, getRegisterView);
page('/logout', async (context) => {
    await authService.logout();
    context.page.redirect('/home');
});

page.start();
