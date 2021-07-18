import auth from '../services/authService.js';
import viewFinder from '../viewFinder.js';

let section = undefined;

export function initialize(domSection) {
    section = domSection;
    const form = section.querySelector('form');
    form.addEventListener('submit', sendRegisterRequest);
}

export async function getView() {
    return section;
}

async function sendRegisterRequest(e) {
    e.preventDefault();
    try {
        const data = new FormData(e.currentTarget);
        const email = data.get('email');
        const password = data.get('password');
        const repeatPassword = data.get('repeatPassword');

        if (!email.trim() || !password.trim()) {
            alert('Fields cannot be empty');
            return;
        }

        if (email.length < 3) {
            alert('Email must be at leats 3 characters');
        }

        if (password.length < 3) {
            alert('Password must be at leat 3 characters');
            return;
        }
        if (password !== repeatPassword) {
            alert('Password mismatch');
            return;
        }

        await auth.register({ email, password });
        e.target.reset();
        viewFinder.navigateTo('dashboard');
    } catch (err) {
        console.log(err);
        alert(err.message);
    }
}

const registerPage = {
    initialize,
    getView,
};

export default registerPage;
