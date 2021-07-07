function attachEvents() {
    const loadPostBtn = document.querySelector('#btnLoadPosts');
    const selectEl = document.querySelector('#posts');
    const viewPostsBtn = document.querySelector('#btnViewPost');

    loadPostBtn.addEventListener('click', () => {
        const url = `http://localhost:3030/jsonstore/blog/posts`;
        fetch(url)
            .then((response) => response.json())
            .then((posts) => {
                Object.keys(posts).forEach((key) => {
                    const post = posts[key];
                    const optionEl = document.createElement('option');
                    optionEl.value = key;
                    optionEl.textContent = post.title;
                    selectEl.appendChild(optionEl);
                });
            });
    });

    viewPostsBtn.addEventListener('click', async () => {
        const post = await (
            await fetch(
                `http://localhost:3030/jsonstore/blog/posts/${selectEl.value}`
            )
        ).json();

        const comments = Object.values(
            await (
                await fetch(`http://localhost:3030/jsonstore/blog/comments/`)
            ).json()
        )
            .map((comment) => {
                if (comment.postId === post.id) {
                    return comment;
                }
            })
            .filter((comment) => comment);

        const postTitleEl = document.querySelector('#post-title');
        const postBodyEl = document.querySelector('#post-body');
        const postCommentsEl = document.querySelector('#post-comments');

        postTitleEl.textContent = post.title;
        postBodyEl.textContent = post.body;

        Array.from(postCommentsEl.children).forEach((li) => li.remove());

        comments.forEach((comment) => {
            const liEl = document.createElement('li');
            liEl.textContent = comment.text;
            postCommentsEl.appendChild(liEl);
        });
    });
}

attachEvents();
