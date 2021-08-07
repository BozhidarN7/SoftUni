import { html } from '../node_modules/lit-html/lit-html.js';
import authService from './services/authService.js';

const navTemplate = (navInfo) => html` <nav>
    <a class="active" href="#">Home</a>
    <a href="allListings">All Listings</a>
    <a href="byYear">By Year</a>
    ${navInfo.isLoggeddIn
        ? html`<div id="profile">
              <a>Welcome ${navInfo.username}</a>
              <a href="/myListings/${navInfo.userId}">My Listings</a>
              <a href="/create">Create Listing</a>
              <a href="javascript:void(0)" @click=${navInfo.logoutHandler}
                  >Logout</a
              >
          </div>`
        : html`<div id="guest">
              <a href="/login">Login</a>
              <a href="/register">Register</a>
          </div>`}
</nav>`;

async function logoutHandler(context, e) {
    e.preventDefault();
    await authService.logout();
    context.page.redirect('/home');
}

export function navGetView(context, next) {
    const navInfo = {
        isLoggeddIn: authService.isLoggeddIn(),
        logoutHandler: logoutHandler.bind(null, context),
        username: authService.getUsername(),
        userId: authService.getUserId(),
    };
    const templateResult = navTemplate(navInfo);
    context.renderNav(templateResult);
    next();
}
