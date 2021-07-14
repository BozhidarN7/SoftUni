import auth from '../services/authService.js';
import viewFinder from '../viewFinder.js';

let section = undefined;

export function initialize(domSection) {
    section = domSection;
    const form = section.querySelector('form');
    form.addEventListener('submit', sendLoginRequest);
}

export async function getView() {
    return section;
}

async function sendLoginRequest(e) {
    e.preventDefault();

    try {
        const data = new FormData(e.currentTarget);
        const email = data.get('email');
        const password = data.get('password');

        await auth.login({ email, password });
        e.target.reset();
        viewFinder.navigateTo('home');
    } catch (err) {
        console.log(err);
        alert(err);
    }
}

let loginPage = {
    initialize,
    getView,
};

export default loginPage;
