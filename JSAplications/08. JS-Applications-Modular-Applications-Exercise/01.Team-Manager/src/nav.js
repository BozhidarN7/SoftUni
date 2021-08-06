import { html } from '../node_modules/lit-html/lit-html.js';
import authService from './services/authService.js';

const navTemplate = (navInfo) => html`
    <a href="/" class="site-logo">Team Manager</a>
    <nav>
        ${navInfo.isLoggedIn
            ? html`<a href="/teams" class="action">Browse Teams</a>
                  <a href="/myTeams" class="action">My Teams</a>
                  <a
                      href="javascript:void(0)"
                      @click=${navInfo.logoutHandler}
                      class="action"
                      >Logout</a
                  >`
            : html`<a href="/teams" class="action">Browse Teams</a>
                  <a href="/login" class="action">Login</a>
                  <a href="/register" class="action">Register</a>`}
    </nav>
`;

async function logoutHandler(context, e) {
    e.preventDefault();
    await authService.logout();
    context.page.redirect('/home');
}

export function navGetView(context, next) {
    const navInfo = {
        logoutHandler: logoutHandler.bind(null, context),
        isLoggedIn: authService.getUsername(),
    };
    const templateResult = navTemplate(navInfo);
    context.renderNav(templateResult);
    next();
}
