import helper from './helpers.js';
import { showComments } from './comments.js';
const postForm = document.querySelector('form');
const publicBtn = document.querySelector('.public');
const cancelBtn = document.querySelector('.cancel');

publicBtn.addEventListener('click', async (e) => {
    e.preventDefault();
    const data = new FormData(postForm);
    const topicName = data.get('topicName');
    const username = data.get('username');
    const postText = data.get('postText');

    try {
        const res = await fetch(`${helper.baseUrl}/posts`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                topicName,
                username,
                postText,
            }),
        });

        const post = await res.json();
        createPost(post);
        postForm.reset();
    } catch (error) {
        console.log(error);
    }
});

cancelBtn.addEventListener('click', (e) => {
    e.preventDefault();
    postForm.reset();
});

export async function createPost(post) {
    const topicContainerDiv = helper.ce('div', { class: 'topic-container' });
    const topicNameWrapperDiv = helper.ce('div', {
        class: 'topic-name-wrapper',
    });
    const topicNameDiv = helper.ce('div', { class: 'topic-name' });
    const titleHeading = helper.ce('h2', undefined, post.topicName);
    const aEl = helper.ce(
        'a',
        { href: 'javascript:void(0)', class: 'normal' },
        titleHeading
    );
    aEl.addEventListener('click', showComments);
    const columnsDiv = helper.ce('div', { class: 'columns' });
    const dateDiv = helper.ce('div', undefined);
    const timeEl = helper.ce('time', undefined, new Date(Date.now()));
    const dateParagraph = helper.ce('p', undefined, 'Date: ', timeEl);
    const nickNameDiv = helper.ce('div', { class: 'nick-name' });
    const span = helper.ce('span', undefined, post.username);
    const usernameParagraph = helper.ce('p', undefined, 'Username: ', span);

    nickNameDiv.appendChild(usernameParagraph);
    dateDiv.appendChild(dateParagraph);
    dateDiv.appendChild(nickNameDiv);
    columnsDiv.appendChild(dateDiv);
    topicNameDiv.appendChild(aEl);
    topicNameDiv.appendChild(columnsDiv);
    topicNameWrapperDiv.appendChild(topicNameDiv);
    topicContainerDiv.appendChild(topicNameWrapperDiv);

    topicContainerDiv.dataset.id = post._id;

    document
        .querySelector('.new-topic-border')
        .insertAdjacentElement('afterend', topicContainerDiv);
}
