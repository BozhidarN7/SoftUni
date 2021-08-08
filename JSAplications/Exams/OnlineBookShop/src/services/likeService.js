import { jsonRequest } from './httpService.js';

const baseUrl = 'http://localhost:3030/data/likes';

async function create(body) {
    return await jsonRequest(baseUrl, 'POST', body, true);
}

async function getAllBookLikes(bookId) {
    return await jsonRequest(
        `${baseUrl}?where=bookId%3D%22${bookId}%22&distinct=_ownerId&count`
    );
}

async function getIfUserHasLikedTheBook(bookId, userId) {
    return await jsonRequest(
        `${baseUrl}?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count`
    );
}

export default {
    create,
    getAllBookLikes,
    getIfUserHasLikedTheBook,
};
