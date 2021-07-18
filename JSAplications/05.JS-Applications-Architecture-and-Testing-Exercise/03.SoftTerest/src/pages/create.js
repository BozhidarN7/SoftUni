import { jsonRequest } from '../services/httpService.js';
import viewFinder from '../viewFinder.js';

let section = undefined;

export function initialize(domSection) {
    section = domSection;
    const form = section.querySelector('form');
    form.addEventListener('submit', createMovie);
}

export async function getView() {
    return section;
}

async function createMovie(e) {
    e.preventDefault();
    try {
        let form = e.target;
        let formData = new FormData(form);
        let newIdea = {
            title: formData.get('title'),
            description: formData.get('description'),
            img: formData.get('imageURL'),
        };
        let createResult = await jsonRequest(
            'http://localhost:3030/data/ideas',
            'POST',
            newIdea,
            true
        );
        form.reset();
        viewFinder.navigateTo('dashboard');
    } catch (err) {
        console.error(err);
        alert(err);
    }
}

const createPage = {
    initialize,
    getView,
};

export default createPage;
