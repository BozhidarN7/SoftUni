import createPage from './pages/create.js';
import dashboardPage from './pages/dashboard.js';
import homePage from './pages/home.js';
import ideaDetailsPage from './pages/ideaDetails.js';
import loginPage from './pages/login.js';
import registerPage from './pages/register.js';
import auth from './services/authService.js';

const sections = {
    home: async () => await homePage.getView(),
    dashboard: async () => await dashboardPage.getView(),
    details: async (id) => await ideaDetailsPage.getView(id),
    register: async () => await registerPage.getView(),
    login: async () => await loginPage.getView(),
    create: async () => await createPage.getView(),
    logout: async () => await auth.logout(),
    delete: async (id) => await ideaDetailsPage.deleteIdea(id),
};

let getViewCallback = undefined;
let linkRouteSelector = undefined;

export function initialize(linkElements, linkSelector, callBack) {
    linkRouteSelector = linkSelector;
    linkElements.forEach((el) =>
        el.addEventListener('click', navigationHangler)
    );
    getViewCallback = callBack;
}

export function navigationHangler(e) {
    let element = e.target.matches(linkRouteSelector)
        ? e.target
        : e.currentTarget.closest(linkRouteSelector);
    if (element.dataset.route !== undefined) {
        let [route, id] = element.dataset.route.split('/');
        navigateTo(route, id);
    }
}

export function navigateTo(route, id) {
    if (sections[route] !== undefined) {
        const viewPromise = sections[route](id);
        getViewCallback(viewPromise);
    }
}

export function redirectTo(route, id) {
    if (sections[route] !== undefined) {
        const viewPromise = sections[route](id);
        location.hash = `/${route}${id !== undefined ? `/${id}` : ''}`;
        return viewPromise;
    }
}

const viewFinder = {
    navigateTo,
    redirectTo,
    navigationHangler,
    initialize,
};

export default viewFinder;
