import { jsonRequest } from './httpService.js';

const baseUrl = 'http://localhost:3030/users';

async function login(body) {
    const user = await jsonRequest(`${baseUrl}/login`, 'POST', body);
    setToken(user.accessToken);
    setUserId(user._id);
    setUsername(user.username);
}

async function register(body) {
    const user = await jsonRequest(`${baseUrl}/register`, 'POST', body);
    setToken(user.accessToken);
    setUserId(user._id);
    setUsername(user.username);
}

async function logout() {
    try {
        await jsonRequest(`${baseUrl}/logout`, 'GET', undefined, true, true);
        localStorage.removeItem('userId');
        localStorage.removeItem('accessToken');
        localStorage.removeItem('username');
    } catch (err) {
        alert(err);
        console.log(err);
    }
}

function isLoggeddIn() {
    return localStorage.getItem('accessToken') !== null;
}

function getUserId() {
    return localStorage.getItem('userId');
}

function getUsername() {
    return localStorage.getItem('username');
}

function getToken() {
    return localStorage.getItem('accessToken');
}

function getEmail() {
    return localStorage.getItem('email');
}

function setEmail(email) {
    localStorage.setItem('email', email);
}

function setToken(token) {
    localStorage.setItem('accessToken', token);
}

function setUsername(username) {
    localStorage.setItem('username', username);
}
function setUserId(id) {
    localStorage.setItem('userId', id);
}

export default {
    isLoggeddIn,
    getToken,
    getUserId,
    getUsername,
    login,
    register,
    logout,
    getEmail,
};
