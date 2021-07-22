import { jsonRequest } from './httpService.js';

const baseUrl = 'http://localhost:3030/users';

async function register(context) {
    this.preventDefault();
    console.log(context);
    const data = new FormData(this.currentTarget);
    const email = data.get('email');
    const password = data.get('password');
    const rePass = data.get('rePass');

    try {
        const newUser = await jsonRequest(`${baseUrl}/register`, 'POST', {
            email,
            password,
        });

        setAuthToken(newUser.accessToken);
        setUserId(newUser._id);

        context.page.redirect('/home');
    } catch (err) {
        this.target.reset();
        console.log(err);
        context.page.redirect('/register');
    }
}

function getUserId() {
    return localStorage.getItem('useId');
}

function getAuthToken() {
    return localStorage.getItem('accessToken');
}

function setAuthToken(token) {
    localStorage.setItem('authToken', token);
}

function setUserId(userId) {
    localStorage.setItem('userId', userId);
}

const auth = {
    getUserId,
    getAuthToken,
    register,
};

export default auth;
