import page from '../node_modules/page/page.mjs';
import { navGetView } from './nav.js';
import {
    initializeNav,
    decorateContext,
} from './middlewares/renderingMiddleware.js';
import { getDashboardPage } from './pages/dashboardPage.js';
import { getLoginPage } from './pages/loginPage.js';
import { getRegisterPage } from './pages/registerPage.js';
import { getCreatePage } from './pages/createPage.js';
import { getDetailsPage } from './pages/detailsPage.js';
import { getEditPage } from './pages/editPage.js';
import { getMyBooksPage } from './pages/myBooksPage.js';

const navEl = document.querySelector('#site-header');
const mainEl = document.querySelector('#site-content');

initializeNav(navEl, mainEl);

page('index.html', '/dashboard');
page('/', '/dashboard');

page('/dashboard', decorateContext, navGetView, getDashboardPage);
page('/login', decorateContext, navGetView, getLoginPage);
page('/register', decorateContext, navGetView, getRegisterPage);
page('/create', decorateContext, navGetView, getCreatePage);
page('/details/:id', decorateContext, navGetView, getDetailsPage);
page('/edit/:id', decorateContext, navGetView, getEditPage);
page('/myBooks', decorateContext, navGetView, getMyBooksPage);

page.start();
