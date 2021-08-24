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

async function join(teamId) {
    return await jsonRequest(`${baseUrl}`, 'POST', { teamId }, true, false);
}

async function decline(requestId) {
    return await jsonRequest(`${baseUrl}/${requestId}`, 'DELETE', true, true);
}

async function approve(requestId) {
    return await jsonRequest(
        `${baseUrl}/${requestId}`,
        'PUT',
        { status: 'member' },
        true,
        true
    );
}

function setMembershipRequestId(id) {
    localStorage.setItem('membershipRequestId', id);
}

function getMembershipRequestId() {
    return localStorage.getItem('membershipRequestId');
}

function deleteMembershipRequestId() {
    localStorage.removeItem('membershipRequestId');
}

export default {
    getAll,
    getAllMemberships,
    join,
    decline,
    approve,
    setMembershipRequestId,
    getMembershipRequestId,
    deleteMembershipRequestId,
};
