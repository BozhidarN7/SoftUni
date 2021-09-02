import { jsonRequest } from './httpService.js';

const baseUrl = 'http://localhost:5000/jobs';

async function getAll() {
    return await jsonRequest(baseUrl);
}

async function create(body) {
    return await jsonRequest(baseUrl, 'POST', body, false);
}

async function getById(id) {
    return await jsonRequest(`${baseUrl}/${id}`);
}

async function edit(id, body) {
    return await jsonRequest(`${baseUrl}/${id}`, 'PUT', body);
}

async function del(id) {
    return await jsonRequest(`${baseUrl}/${id}`, 'DELETE', undefined);
}

async function getCandidates(id) {
    return await jsonRequest(`${baseUrl}/${id}/candidates`);
}

async function addPotentialCandidate(id, body) {
    return await jsonRequest(`${baseUrl}/${id}/candidates`, 'POST', body);
}

async function getInterviews(id) {
    return await jsonRequest(`${baseUrl}/${id}/interviews`);
}

async function removeCandidate(jobId, candidateId) {
    return await jsonRequest(
        `${baseUrl}/${jobId}/candidates/${candidateId}`,
        'DELETE',
        undefined
    );
}

export default {
    getAll,
    create,
    getById,
    edit,
    del,
    getCandidates,
    addPotentialCandidate,
    getInterviews,
    removeCandidate,
};
