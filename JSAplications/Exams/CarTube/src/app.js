import page from '../node_modules/page/page.mjs';
import { navGetView } from './nav.js';
import {
    initializeNav,
    decorateContext,
} from './middlewares/renderingMiddleware.js';
import { getHomePage } from './pages/homePage.js';
import { getLoginPage } from './pages/loginPage.js';
import { getRegisterPage } from './pages/registerPage.js';
import { getAllListingsPage } from './pages/allListings.js';
import { getCreatePage } from './pages/createPage.js';
import { getDetailsPage } from './pages/detailsPage.js';
import { getEditPage } from './pages/editPage.js';
import { getMyListingsPage } from './pages/myListings.js';
import { getByYearPage } from './pages/byYearPage.js';

const navEl = document.querySelector('#nav-container');
const mainEl = document.querySelector('#site-content');

initializeNav(navEl, mainEl);

page('index.html', '/home');
page('/', '/home');

page('/home', decorateContext, navGetView, getHomePage);
page('/login', decorateContext, navGetView, getLoginPage);
page('/register', decorateContext, navGetView, getRegisterPage);
page('/allListings', decorateContext, navGetView, getAllListingsPage);
page('/create', decorateContext, navGetView, getCreatePage);
page('/details/:id', decorateContext, navGetView, getDetailsPage);
page('/edit/:id', decorateContext, navGetView, getEditPage);
page('/myListings/:id', decorateContext, navGetView, getMyListingsPage);
page('/byYear', decorateContext, navGetView, getByYearPage);

page.start();
