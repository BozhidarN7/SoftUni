import { setNavigation } from '../nav.js';
import { jsonRequest } from './httpService.js';

const baseUrl = 'http://localhost:3030/users';

async function register(context) {
    this.preventDefault();
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

        setNavigation();
        context.page.redirect('/home');
    } catch (err) {
        this.target.reset();
        console.log(err);
        context.page.redirect('/register');
    }
}

async function login(context) {
    this.preventDefault();
    const data = new FormData(this.currentTarget);
    const email = data.get('email');
    const password = data.get('password');

    try {
        const newUser = await jsonRequest(`${baseUrl}/login`, 'POST', {
            email,
            password,
        });

        setAuthToken(newUser.accessToken);
        setUserId(newUser._id);

        setNavigation();
        context.page.redirect('/home');
    } catch (err) {
        this.target.reset();
        console.log(err);
        context.page.redirect('/login');
    }
}

export function logout(context) {
    try {
        const logoutResult = jsonRequest(
            `${baseUrl}`,
            'GET',
            undefined,
            true,
            true
        );
        localStorage.removeItem('authToken');
        localStorage.removeItem('userId');
        setNavigation();
        context.page.redirect('/Login');
    } catch (err) {
        console.log(err);
    }
}

function getUserId() {
    return localStorage.getItem('userId');
}

function getAuthToken() {
    return localStorage.getItem('authToken');
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
    login,
    logout,
};

export default auth;
