import { html } from '../node_modules/lit-html/lit-html.js';
import authService from './services/authService.js';
const navTemplate = (navInfo) => html`
    <a href="/all">All Memes</a>
    ${navInfo.isLoggeddIn
        ? html` <div class="user">
              <a href="/create">Create Meme</a>
              <div class="profile">
                  <span>Welcome, {email}</span>
                  <a href="/myProfile">My Profile</a>
                  <a href="/logout">Logout</a>
              </div>
          </div>`
        : html`<div class="guest">
              <div class="profile">
                  <a href="/login">Login</a>
                  <a href="/register">Register</a>
              </div>
              <a class="active" href="/home">Home Page</a>
          </div>`}
`;

export function navGetView(context, next) {
    const navInfo = {
        isLoggeddIn: authService.isLoggeddIn(),
    };
    const templateResult = navTemplate(navInfo);
    context.renderNav(templateResult);
    next();
}
