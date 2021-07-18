import { jsonRequest } from '../services/httpService.js';
import viewFinder from '../viewFinder.js';

let section = undefined;

export function initialize(domSection) {
    section = domSection;
    const form = section.querySelector('form');
    form.addEventListener('submit', editMovie);
}

export async function getView(id) {
    try {
        const movie = await jsonRequest(
            `http://localhost:3030/data/movies/${id}`
        );

        let titleInput = section.querySelector('input[name="title"]');
        let descriptionTextarea = section.querySelector(
            'textarea[name="description"]'
        );
        let imageInput = section.querySelector('input[name="imageUrl"]');
        let idInput = section.querySelector('input[name="id"]');

        titleInput.value = movie.title;
        descriptionTextarea.value = movie.description;
        imageInput.value = movie.img;
        idInput.value = id;
        return section;
    } catch (err) {
        alert(err);
    }
}

async function editMovie(e) {
    e.preventDefault();
    try {
        const data = new FormData(e.currentTarget);
        const id = data.get('id');

        const editedMovie = {
            title: data.get('title'),
            description: data.get('description'),
            img: data.get('imageUrl'),
        };

        const updateResult = await jsonRequest(
            `http://localhost:3030/data/movies/${id}`,
            'Put',
            editedMovie,
            true
        );
        e.target.reset();
        viewFinder.navigateTo('details', id);
    } catch (err) {
        console.log(err);
        alert(err);
    }
}

let editMoviePage = {
    initialize,
    getView,
};

export default editMoviePage;
