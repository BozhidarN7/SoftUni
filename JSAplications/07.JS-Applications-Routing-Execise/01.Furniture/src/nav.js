import authService from './services/authService.js';

export function setNavigation() {
    const userDiv = document.querySelector('#user');
    const guestDiv = document.querySelector('#guest');
    if (authService.getToken()) {
        userDiv.classList.remove('hidden');
        guestDiv.classList.add('hidden');
    } else {
        userDiv.classList.add('hidden');
        guestDiv.classList.remove('hidden');
    }
}
