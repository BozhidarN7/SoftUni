const registerForm = document.querySelector('form:nth-of-type(1)');
const loginForm = document.querySelector('form:nth-of-type(2)');

const baseUrl = 'http://localhost:3030';

registerForm.addEventListener('submit', (e) => {
    e.preventDefault();

    const data = new FormData(e.currentTarget);
    const email = data.get('email');
    const password = data.get('password');
    const rePass = data.get('rePass');

    if (password !== rePass) {
        e.target.reset();
        return;
    }

    fetch(`${baseUrl}/users/register`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ email, password }),
    })
        .then((response) => {
            if (!response.ok) {
                throw new Error('Registration failed!');
            }
            return response.json();
        })
        .then((data) => {
            saveToken(data.accessToken);
            setUserId(data._id);
            e.target.reset();
            window.location.href = 'index.html';
        })
        .catch((error) => {
            console.log(error);
            e.target.reset();
            // To do:
            // To show append message in the DOM
        });
});

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
        .then((response) => {
            if (!response.ok) {
                throw new Error('Registration failed!');
            }
            return response.json();
        })
        .then((data) => {
            console.log(data);
            saveToken(data.accessToken);
            setUserId(data._id);
            e.target.reset();
            window.location.href = 'index.html';
        })
        .catch((error) => {
            console.log(error);
            e.target.reset();
        });
});

function saveToken(token) {
    localStorage.setItem('auth_token', token);
}

function getToken() {
    return localStorage.getItem('auth_token');
}
function setUserId(id) {
    localStorage.setItem('userId', id);
}
function getUserId() {
    return localStorage.getItem('userId');
}
function removeUserId() {
    localStorage.removeItem('userId');
}
