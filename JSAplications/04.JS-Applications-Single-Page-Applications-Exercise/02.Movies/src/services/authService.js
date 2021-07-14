import nav from '../nav.js';
import viewFinder from '../viewFinder.js';
import { jsonRequest } from './httpService.js';

async function logout() {
    try {
        const logoutResult = await fetch(
            'http://localhost:3030/users/logout',
            'GET',
            undefined,
            true,
            true
        );
        localStorage.removeItem('authToken');
        localStorage.removeItem('userId');
        localStorage.removeItem('userName');
        nav.logoutUser();
        return viewFinder.redirectTo('login');
    } catch (err) {
        alert(err);
    }
}

async function register(newUser) {
    try {
        const registerResult = await jsonRequest(
            'http://localhost:3030/users/register',
            'POST',
            newUser
        );
        localStorage.setItem('authToken', registerResult.accessToken);
        localStorage.setItem('userId', registerResult._id);
        localStorage.setItem('userName', registerResult.email);
        nav.loginUser();
    } catch (err) {
        alert(err);
    }
}

async function login(loginUser) {
    try {
        const loginResult = await jsonRequest(
            'http://localhost:3030/users/login',
            'POST',
            loginUser
        );
        localStorage.setItem('authToken', loginResult.accessToken);
        localStorage.setItem('userId', loginResult._id);
        localStorage.setItem('userName', loginResult.email);
        nav.loginUser();
    } catch (err) {
        alert(err);
    }
}

function cleanStorage() {
    localStorage.clear();
}

function isLoggedIn() {
    return (
        localStorage.getItem('authToken') !== null &&
        localStorage.getItem('authToken') !== undefined
    );
}

function getUserName() {
    return localStorage.getItem('userName');
}

function getUserId() {
    return localStorage.getItem('userId');
}

function getAuthToken() {
    return localStorage.getItem('authToken');
}

const auth = {
    logout,
    register,
    login,
    isLoggedIn,
    getUserName,
    getUserId,
    getAuthToken,
    cleanStorage,
};

export default auth;
