import { html } from '../node_modules/lit-html/lit-html.js';
import { ifDefined } from '../node_modules/lit-html/directives/if-defined.js';
import authService from './services/authService.js';
const navTemplate = (navInfo) => html`
    <nav>
        <a
            class="${ifDefined(
                navInfo.pathname.startsWith('/home') ? 'active' : undefined
            )}"
            href="/home"
            >Home</a
        >
        <a
            class="${ifDefined(
                navInfo.pathname.startsWith('/allListings')
                    ? 'active'
                    : undefined
            )}"
            href="/allListings"
            >All Listings</a
        >
        <a
            class="${ifDefined(
                navInfo.pathname.startsWith('/byYear') ? 'active' : undefined
            )}"
            href="/byYear"
            >By Year</a
        >
        ${navInfo.isLoggeddIn
            ? html`<div id="profile">
                  <a>Welcome ${navInfo.username}</a>
                  <a
                      class="${ifDefined(
                          navInfo.pathname.startsWith('/myListings')
                              ? 'active'
                              : undefined
                      )}"
                      href="/myListings"
                      >My Listings</a
                  >
                  <a
                      class="${ifDefined(
                          navInfo.pathname.startsWith('/create')
                              ? 'active'
                              : undefined
                      )}"
                      href="/create"
                      >Create Listing</a
                  >
                  <a href="/logout">Logout</a>
              </div>`
            : html` <div id="guest">
                  <a
                      class="${ifDefined(
                          navInfo.pathname.startsWith('/login')
                              ? 'active'
                              : undefined
                      )}"
                      href="/login"
                      >Login</a
                  >
                  <a
                      class="${ifDefined(
                          navInfo.pathname.startsWith('/register')
                              ? 'active'
                              : undefined
                      )}"
                      href="/register"
                      >Register</a
                  >
              </div>`}
    </nav>
`;

export function navGetView(context, next) {
    const navInfo = {
        isLoggeddIn: authService.isLoggeddIn(),
        username: authService.getUsername(),
        pathname: context.pathname,
    };
    const templateResult = navTemplate(navInfo);
    context.renderNav(templateResult);
    next();
}
