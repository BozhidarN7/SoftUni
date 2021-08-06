import { jsonRequest } from './httpService.js';

const baseUrl = 'http://localhost:3030/data/members';

async function getAll() {
    return await jsonRequest(`${baseUrl}?where=status%3D%22member%22`);
}

export default {
    getAll,
};
