import { jsonRequest } from './httpService.js';

const baseUrl = 'http://localhost:3030/data/memes';

async function getAll() {
    return await jsonRequest(baseUrl);
}

async function getAllOrderByCreation() {
    return await jsonRequest(`${baseUrl}?sortBy=_createdOn%20desc`);
}

async function getById(id) {
    return await jsonRequest(`${baseUrl}/${id}`);
}

async function create(body) {
    return await jsonRequest(baseUrl, 'POST', body, true);
}
async function del(id) {
    return await jsonRequest(`${baseUrl}/${id}`, 'DELETE', undefined, true);
}

async function edit(id, body) {
    return await jsonRequest(`${baseUrl}/${id}`, 'PUT', body, true);
}

export default {
    getAll,
    getAllOrderByCreation,
    getById,
    create,
    del,
    edit,
};
