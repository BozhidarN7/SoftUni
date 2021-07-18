import createPage from './src/pages/create.js';
import homePage from './src/pages/home.js';
import loginPage from './src/pages/login.js';
import registerPage from './src/pages/register.js';
import viewFinder from './src/viewFinder.js';
import nav from './src/nav.js';
import auth from './src/services/authService.js';
import dashboardPage from './src/pages/dashboard.js';
import ideaDetailsPage from './src/pages/ideaDetails.js';

let appElement = undefined;

setupApp();

function setupApp() {
    let appSelector = '#app';
    appElement = document.querySelector(appSelector);
    homePage.initialize(document.querySelector('#home-page'));
    dashboardPage.initialize(document.querySelector('#dashboard-holder'));
    registerPage.initialize(document.querySelector('#register-page'));
    loginPage.initialize(document.querySelector('#login-page'));
    createPage.initialize(document.querySelector('#create-page'));
    ideaDetailsPage.initialize(document.querySelector('#details-page'), 'link');
    nav.initialize(document.querySelector('nav'));
    viewFinder.initialize(
        document.querySelectorAll('.link'),
        '.link',
        changeView
    );

    if (auth.isLoggedIn()) {
        viewFinder.navigateTo('dashboard');
    }
    viewFinder.navigateTo('home');
}

async function changeView(viewPromise) {
    const view = await viewPromise;
    [...appElement.children].forEach((el) => el.remove());
    appElement.appendChild(view);
}
