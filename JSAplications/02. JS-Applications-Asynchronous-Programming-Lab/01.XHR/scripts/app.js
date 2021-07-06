function loadRepos() {
    const resDiv = document.querySelector('#res');

    const url = ' https://api.github.com/users/testnakov/repos';
    const httpRequest = new XMLHttpRequest();
    httpRequest.addEventListener('readystatechange', () => {
        if (httpRequest.readyState === 4 && httpRequest.status === 200) {
            resDiv.textContent = httpRequest.responseText;
        }
    });

    httpRequest.open('GET', url);
    httpRequest.send();
}
