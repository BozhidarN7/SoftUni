function loadCommits() {
    const usernameField = document.querySelector('#username');
    const repoField = document.querySelector('#repo');
    const ulEl = document.querySelector('#commits');

    Array.from(ulEl.children).forEach((li) => li.remove());

    const url = `https://api.github.com/repos/${usernameField.value}/${repoField.value}/commits`;
    fetch(url)
        .then((response) => response.json())
        .then((commits) => {
            console.log(commits);
            commits.forEach((commit) => {
                const liEl = document.createElement('li');
                liEl.textContent = `${commit.commit.author.name}: ${commit.commit.message}`;
                ulEl.appendChild(liEl);
            });
        })
        .catch((error) => {
            const liEl = document.createElement('li');
            liEl.textContent = `Error: ${
                error?.status ? error.status : 404
            } (Not Found)`;
            ulEl.appendChild(liEl);
        });
}
