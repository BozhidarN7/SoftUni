import page from '../node_modules/page/page.mjs';
import {
    initializeNav,
    decorateContext,
} from './middlewares/renderingMiddleware.js';

import { navGetView } from './nav.js';
import { getCreatePage } from './pages/createPage.js';
import { getDetailsPage } from './pages/detailsPage.js';
import { getEditPage } from './pages/editPage.js';
import { getJobsPage } from './pages/jobsPage.js';
import { getAddCandidatePage } from './pages/addCandidatePage.js';

const navEl = document.querySelector('#titlebar');
const mainEl = document.querySelector('#root');

initializeNav(navEl, mainEl);

page('/index.html', '/jobs');
page('/', '/jobs');

page('/jobs', decorateContext, navGetView, getJobsPage);
page('/create', decorateContext, navGetView, getCreatePage);
page('/addCandidate', decorateContext, navGetView, getAddCandidatePage);
page('/details/:id', decorateContext, navGetView, getDetailsPage);
page('/edit/:id', decorateContext, navGetView, getEditPage);

page.start();
