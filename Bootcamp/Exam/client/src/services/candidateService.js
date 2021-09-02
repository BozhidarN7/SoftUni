import { jsonRequest } from './httpService.js';

const baseUrl = 'http://localhost:5000/candidates';

async function create(body) {
    return await jsonRequest(baseUrl, 'POST', body, false);
}

async function getAll() {
    return await jsonRequest(baseUrl);
}

async function getInterviews(id) {
    return await jsonRequest(`${baseUrl}/${id}/interviews`);
}
async function getById(id) {
    return await jsonRequest(`${baseUrl}/${id}`);
}

async function del(id) {
    return await jsonRequest(`${baseUrl}/${id}`, 'DELETE', undefined);
}

export default {
    create,
    getAll,
    getInterviews,
    getById,
    del,
};
