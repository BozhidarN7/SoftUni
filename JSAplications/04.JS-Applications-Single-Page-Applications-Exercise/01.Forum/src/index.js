import { createPost } from './createPost.js';
import helper from './helpers.js';

window.addEventListener('load', async () => {
    const posts = await (await fetch(`${helper.baseUrl}/posts`)).json();
    for (const id in posts) {
        const post = posts[id];
        createPost(post);
    }
});

document.querySelector('#homeBtn').addEventListener('click', (e) => {
    e.preventDefault();

    document.querySelector('.answer-comment').classList.add('hidden');

    document.querySelector('.new-topic-border').classList.remove('hidden');

    document.querySelectorAll('.topic-container').forEach((el) => {
        el.classList.remove('hidden');
    });
});
