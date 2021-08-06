import page from '../node_modules/page/page.mjs';

import {
    initializeNav,
    decorateContext,
} from './middlewares/renderingMiddleware.js';

import { navGetView } from './nav.js';
import { getCreatePage } from './pages/createPage.js';
import { getDetailsPage } from './pages/detailsPage.js';
import { getEditPage } from './pages/editPage.js';
import { getHomePage } from './pages/homePage.js';
import { getLoginPage } from './pages/loginPage.js';
import { getRegisterPage } from './pages/registerPage.js';
import { getTeamsPage } from './pages/teamsPage.js';

const navEl = document.querySelector('#titlebar');
const mainEl = document.querySelector('#root');

initializeNav(navEl, mainEl);

page('/index.html', '/home');
page('/', '/home');

page('/home', decorateContext, navGetView, getHomePage);
page('/register', decorateContext, navGetView, getRegisterPage);
page('/login', decorateContext, navGetView, getLoginPage);
page('/teams', decorateContext, navGetView, getTeamsPage);
page('/create', decorateContext, navGetView, getCreatePage);
page('/details/:id', decorateContext, navGetView, getDetailsPage);
page('/edit/:id', decorateContext, navGetView, getEditPage);

page.start();
