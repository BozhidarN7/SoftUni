import { createPost } from './createPost.js';
import helper from './helpers.js';

const answerCommentForm = document.querySelector('.answer-comment form');

answerCommentForm.addEventListener('submit', async (e) => {
    e.preventDefault();

    const data = new FormData(answerCommentForm);

    const username = data.get('username');
    const postText = data.get('postText');

    const id = document.querySelector('.comment').dataset.id;

    try {
        const res = await fetch(`${helper.baseUrl}/posts/${id}/comments`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                username,
                postText,
            }),
        });
        const newComment = await res.json();
        createCommentView(newComment);
    } catch (error) {
        console.log(error);
    }
});

export async function showComments(e) {
    e.preventDefault();
    const parentEl = e.target.closest('main > div');
    document.querySelectorAll('.normal').forEach((link) => {
        const topicWrapperDiv = link.closest('main > div');

        topicWrapperDiv.classList.add('hidden');
    });
    document.querySelector('.answer-comment').classList.remove('hidden');
    document.querySelector('.new-topic-border').classList.add('hidden');

    const post = await (
        await fetch(`${helper.baseUrl}/posts/${parentEl.dataset.id}`)
    ).json();

    createPostView(post);

    const res = await fetch(
        `${helper.baseUrl}/posts/${parentEl.dataset.id}/comments`
    );
    const comments = await res.json();
    for (const id in comments) {
        const comment = comments[id];
        createCommentView(comment);
    }
}

function createPostView(post) {
    const commentDiv = helper.ce('div', { class: 'comment' });
    const headerDiv = helper.ce('div', { class: 'header' });
    const img = helper.ce('img', {
        src: './static/profile.png',
        alt: 'avatar',
    });
    const span = helper.ce('span', undefined, post.username);
    const time = helper.ce('time', undefined, new Date(Date.now()));
    const userAndDateP = helper.ce('p', undefined, span, ' posted on ', time);
    const contentP = helper.ce('p', { class: 'post-content' }, post.postText);

    headerDiv.appendChild(img);
    headerDiv.appendChild(userAndDateP);
    headerDiv.appendChild(contentP);
    commentDiv.appendChild(headerDiv);

    commentDiv.dataset.id = post._id;

    document.querySelector('.answer-comment').previousElementSibling?.remove();

    document
        .querySelector('.answer-comment')
        .insertAdjacentElement('beforebegin', commentDiv);
}

function createCommentView(comment) {
    const userCommentDiv = helper.ce('div', { id: 'user-comment' });
    const topicNameWrapperDiv = helper.ce('div', {
        class: 'topic-name-wrapper',
    });
    const topicNameDiv = helper.ce('div', {
        class: 'topic-name',
    });
    const strong = helper.ce('strong', undefined, comment.username);
    const time = helper.ce('time', undefined, new Date(Date.now()));
    const nameAndTimeP = helper.ce(
        'p',
        undefined,
        strong,
        ' commented on ',
        time
    );
    const postContentDiv = helper.ce('div', {
        class: 'post-content',
    });

    const contentP = helper.ce('p', undefined, comment.postText);

    postContentDiv.appendChild(contentP);
    topicNameDiv.appendChild(nameAndTimeP);
    topicNameDiv.appendChild(postContentDiv);
    topicNameWrapperDiv.appendChild(topicNameDiv);
    userCommentDiv.appendChild(topicNameWrapperDiv);

    document.querySelector('.comment').appendChild(userCommentDiv);
}
