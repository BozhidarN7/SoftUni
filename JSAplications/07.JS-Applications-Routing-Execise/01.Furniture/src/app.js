import page from '../node_modules/page/page.mjs';
import { initializeHome } from './pages/home.js';
import { initializeLogin } from './pages/login.js';
import { initializeRegister } from './pages/register.js';
import { initializeDetails } from './pages/details.js';
import { initializeCreate } from './pages/create.js';
import { initializeEdit } from './pages/edit.js';
import { setNavigation } from './nav.js';
import auth from './services/authService.js';
import furnitureService from './services/furnitureService.js';

setNavigation();

page('/', initializeHome);
page('/home', initializeHome);
page('/login', initializeLogin);
page('/register', initializeRegister);
page('/logout', auth.logout);
page('/details/:id', initializeDetails);
page('/create', initializeCreate);
page('/delete/:id', furnitureService.del);
page('/edit/:id', initializeEdit);
page.start();
