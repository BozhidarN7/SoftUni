import { jsonRequest } from './httpService.js';

const baseUrl = 'http://localhost:5000/interviews';

async function create(body) {
    return await jsonRequest(baseUrl, 'POST', body, false);
}

async function getAll() {
    return await jsonRequest(baseUrl);
}

async function remove(id) {
    return await jsonRequest(`${baseUrl}/${id}`, 'DELETE', undefined);
}

export default {
    create,
    getAll,
    remove,
};
