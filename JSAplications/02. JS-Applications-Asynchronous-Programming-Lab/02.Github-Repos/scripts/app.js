function loadRepos() {
    const usernameField = document.querySelector('#username');
    const ulElement = document.querySelector('#repos');
    const url = `https://api.github.com/users/${usernameField.value}/repos`;

    fetch(url)
        .then((response) => response.json())
        .then((reps) => {
            reps.forEach((rep) => {
                const liEl = document.createElement('li');
                const aEl = document.createElement('a');
                aEl.href = rep.html_url;
                aEl.textContent = rep.full_name;

                liEl.appendChild(aEl);
                ulElement.appendChild(liEl);
            });
        });
}
