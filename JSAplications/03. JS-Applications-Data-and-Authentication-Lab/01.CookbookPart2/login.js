const loginForm = document.querySelector('form');

const baseUrl = 'http://localhost:3030';

loginForm.addEventListener('submit', (e) => {
    e.preventDefault();

    const data = new FormData(e.currentTarget);
    const email = data.get('email');
    const password = data.get('password');

    fetch(`${baseUrl}/users/login`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            email,
            password,
        }),
    })
        .then((response) => response.json())
        .then((data) => {
            console.log(data);
            saveToken(data.accessToken);
        })
        .catch((error) => {
            console.log(error);
        });

    e.currentTarget.reset();

    window.location.href = 'index.html';
});

function saveToken(token) {
    localStorage.setItem('auth_token', token);
}
