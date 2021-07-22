import { jsonRequest } from './httpService.js';

const baseUrl = 'http://localhost:3030/data/catalog';

async function getAll() {
    const data = await jsonRequest(baseUrl);
    return data;
}

async function getOne(id) {
    return await jsonRequest(`${baseUrl}/${id}`);
}

export default {
    getAll,
    getOne,
};
