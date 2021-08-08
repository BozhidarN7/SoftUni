import { html } from '../node_modules/lit-html/lit-html.js';
import authService from './services/authService.js';

const navTemplate = (navInfo) => html`<nav class="navbar">
    <section class="navbar-dashboard">
        <a href="/dashboard">Dashboard</a>
        ${navInfo.isLoggeddIn
            ? html`<div id="user">
                  <span>Welcome, ${navInfo.email}</span>
                  <a class="button" href="/myBooks">My Books</a>
                  <a class="button" href="/create">Add Book</a>
                  <a
                      class="button"
                      href="javascript:void(0)"
                      @click=${navInfo.logoutHandler}
                      >Logout</a
                  >
              </div>`
            : html` <div id="guest">
                  <a class="button" href="/login">Login</a>
                  <a class="button" href="/register">Register</a>
              </div>`}
    </section>
</nav>`;

async function logoutHandler(context, e) {
    e.preventDefault();
    await authService.logout();
    context.page.redirect('/dashboard');
}

export function navGetView(context, next) {
    const navInfo = {
        logoutHandler: logoutHandler.bind(null, context),
        isLoggeddIn: authService.isLoggeddIn(),
        email: authService.getEmail(),
    };
    const templateResult = navTemplate(navInfo);
    context.renderNav(templateResult);
    next();
}
