const registerForm = document.querySelector('form:nth-of-type(1)');
const loginForm = document.querySelector('form:nth-of-type(2)');
const baseUrl = 'http://localhost:3030';

registerForm.addEventListener('submit', async (e) => {
    e.preventDefault();

    const data = new FormData(e.currentTarget);

    const email = data.get('email');
    const password = data.get('password');
    const rePass = data.get('rePass');

    try {
        if (password !== rePass) {
            throw new Error('Password mismatch');
        }

        const res = await fetch(`${baseUrl}/users/register`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application.json',
            },
            body: JSON.stringify({ email, password }),
        });

        if (!res.ok) {
            throw new Error('Registration failed');
        }

        const user = await res.json();
        saveToken(user.accessToken);
        setUserId(user._id);
        e.target.reset();
        window.location.href = 'homeLogged.html';
    } catch (error) {
        console.log(error);
        e.target.reset();
    }
});

loginForm.addEventListener('submit', async (e) => {
    e.preventDefault();

    const data = new FormData(e.currentTarget);
    const email = data.get('email');
    const password = data.get('password');

    try {
        const res = await fetch(`${baseUrl}/users/login`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ email, password }),
        });
        if (!res.ok) {
            throw new Error('Login failed');
        }
        const user = await res.json();
        saveToken(user.accessToken);
        setUserId(user._id);
        window.location.href = 'homeLogged.html';
    } catch (error) {
        console.log(error);
        e.target.reset();
    }
});

function getToken() {
    return localStorage.getItem('auth_token');
}
function saveToken(token) {
    localStorage.setItem('auth_token', token);
}

function setUserId(id) {
    localStorage.setItem('userId', id);
}
