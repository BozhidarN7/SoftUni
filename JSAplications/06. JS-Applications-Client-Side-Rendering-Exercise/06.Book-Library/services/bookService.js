import { jsonRequest } from '../helpers.js/jsonRequest.js';

const baseUrl = 'http://localhost:3030';

async function getAllBooks() {
    const books = await jsonRequest(`${baseUrl}/jsonstore/collections/books`);
    return books;
}

async function getBook(id) {
    return await jsonRequest(`${baseUrl}/jsonstore/collections/books/${id}`);
}

async function createBook(book) {
    const createdBook = await jsonRequest(
        `${baseUrl}/jsonstore/collections/books`,
        'POST',
        book
    );
    return createdBook;
}

async function editBook(id, book) {
    const editedBook = await jsonRequest(
        `${baseUrl}/jsonstore/collections/books/${id}`,
        'PUT',
        book
    );
    return editedBook;
}

async function deleteBook(id) {
    const deleteResult = await jsonRequest(
        `${baseUrl}/jsonstore/collections/books/${id}`,
        'DELETE'
    );
    return deleteResult;
}

export default {
    getAllBooks,
    getBook,
    editBook,
    createBook,
    deleteBook,
};
