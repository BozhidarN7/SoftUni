import auth from './services/authService.js';

export function setNavigation() {
    const userDiv = document.querySelector('#user');
    const guestDiv = document.querySelector('#guest');
    if (auth.getAuthToken()) {
        userDiv.classList.remove('hidden');
        guestDiv.classList.add('hidden');
    } else {
        userDiv.classList.add('hidden');
        guestDiv.classList.remove('hidden');
    }
}
