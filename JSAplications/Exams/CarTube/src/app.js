import page from '../node_modules/page/page.mjs';
import {
    initializeNav,
    decorateContext,
} from './middlewares/renderingMiddleware.js';
import { navGetView } from './nav.js';
import { getAllListingsPage } from './pages/allListingsPage.js';
import { getByYearPage } from './pages/byYearPage.js';
import { getCreatePage } from './pages/createPage.js';
import { getDetailsPage } from './pages/detailsPage.js';
import { getEditPage } from './pages/editPage.js';
import { getHomePage } from './pages/homePage.js';
import { getLoginPage } from './pages/loginPage.js';
import { getMyListingsPage } from './pages/myListingsPage.js';
import { getRegisterPage } from './pages/registerPage.js';
import authService from './services/authService.js';
import carService from './services/carService.js';
const navEl = document.querySelector('#nav');
const mainEl = document.querySelector('#site-content');

initializeNav(navEl, mainEl);

page('/', decorateContext, navGetView, getHomePage);
page('/home', decorateContext, navGetView, getHomePage);
page('/login', decorateContext, navGetView, getLoginPage);
page('/register', decorateContext, navGetView, getRegisterPage);
page('/allListings', decorateContext, navGetView, getAllListingsPage);
page('/create', decorateContext, navGetView, getCreatePage);
page('/details/:id', decorateContext, navGetView, getDetailsPage);
page('/delete/:id', decorateContext, navGetView, async (context) => {
    await carService.del(context.params.id);
    context.page.redirect('/allListings');
});
page('/edit/:id', decorateContext, navGetView, getEditPage);
page('/myListings', decorateContext, navGetView, getMyListingsPage);
page('/byYear', decorateContext, navGetView, getByYearPage);
page('/logout', async (context) => {
    await authService.logout();
    context.page.redirect('/home');
});
page.start();
