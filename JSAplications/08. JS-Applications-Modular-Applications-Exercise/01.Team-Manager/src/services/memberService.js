import { jsonRequest } from './httpService.js';

const baseUrl = 'http://localhost:3030/data/members';

async function getAll() {
    return await jsonRequest(`${baseUrl}?where=status%3D%22member%22`);
}

async function getAllMemberships(teamId) {
    return await jsonRequest(
        `${baseUrl}?where=teamId%3D%22${teamId}%22&load=user%3D_ownerId%3Ausers`
    );
}

export default {
    getAll,
    getAllMemberships,
};
