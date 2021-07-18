import auth from './services/authService.js';

let section = undefined;

export function initialize(domSection) {
    section = domSection;
    if (auth.isLoggedIn()) {
        this.loginUser();
    } else {
        this.logoutUser();
    }
}

export function loginUser() {
    // const userWelcome = section.querySelector('#user-welcome');
    // userWelcome.textConent = `Welcome, ${auth.getUserName}`;
    const userLinks = [...section.querySelectorAll('.user')];
    userLinks.forEach((el) => el.classList.remove('hidden'));
    const guestLinks = [...section.querySelectorAll('.guest')];
    guestLinks.forEach((el) => el.classList.add('hidden'));
}

export function logoutUser() {
    // let userWelcome = section.querySelector('#user-welcome');
    // userWelcome.textContent = 'Welcome, guest';
    let userLinks = [...section.querySelectorAll('.user')];
    userLinks.forEach((el) => el.classList.add('hidden'));
    let guestLinks = [...section.querySelectorAll('.guest')];
    guestLinks.forEach((el) => el.classList.remove('hidden'));
}

let nav = {
    initialize,
    loginUser,
    logoutUser,
};

export default nav;
