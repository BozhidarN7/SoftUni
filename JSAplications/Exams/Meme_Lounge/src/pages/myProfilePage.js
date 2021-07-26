import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import memeService from '../services/memeService.js';

const myProfileTemplate = (memes, info) => html`
    <section id="user-profile-page" class="user-profile">
        <article class="user-info">
            <img
                id="user-avatar-url"
                alt="user-profile"
                src="/images/${info.gender === 'male' ? 'male' : 'female'}.png"
            />
            <div class="user-content">
                <p>Username: ${info.username}</p>
                <p>Email: ${info.email}</p>
                <p>My memes count: ${info.count}</p>
            </div>
        </article>
        <h1 id="user-listings-title">User Memes</h1>
        <div class="user-meme-listings">
            ${memes.length === 0
                ? html`<p class="no-memes">No memes in database.</p>`
                : memes.map((m) => memeTemplate(m))}
        </div>
    </section>
`;

const memeTemplate = (meme) => html`
    <div class="user-meme">
        <p class="user-meme-title">${meme.title}</p>
        <img
            class="userProfileImage"
            alt="meme-img"
            src="${meme.imageUrl.startsWith('/')
                ? `../../${meme.imageUrl}`
                : `${meme.imageUrl}`}"
        />
        <a class="button" href="/details/${meme._id}">Details</a>
    </div>
`;

export async function getMyProfileView(context) {
    // I need to check why /users/me endpoint doesn't return user
    const memes = await memeService.getMyMemes(authService.getUserId());
    const info = {
        gender: authService.getGender(),
        username: authService.getUsername(),
        email: authService.getEmail(),
        count: memes.length,
    };
    const templateResult = myProfileTemplate(memes, info);
    context.renderView(templateResult);
}
