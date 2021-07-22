import page from '../node_modules/page/page.mjs';
import { initializeHome } from './pages/home.js';
import { initializeLogin } from './pages/login.js';
import { initializeRegister } from './pages/register.js';
import { setNavigation } from './nav.js';

setNavigation();

const views = {
    homeView: () => initializeHome,
    loginView: () => initializeLogin,
    register: () => initializeRegister,
};

page('/', initializeHome);
page('/home', initializeHome);
page('/login', initializeLogin);
page('/register', initializeRegister);
page.start();
