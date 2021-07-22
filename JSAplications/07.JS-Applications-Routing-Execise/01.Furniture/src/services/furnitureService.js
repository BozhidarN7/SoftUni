import { jsonRequest } from './httpService.js';

const baseUrl = 'http://localhost:3030/data/catalog';

async function getAll() {
    const data = await jsonRequest(baseUrl);
    return data;
}

async function getOne(id) {
    return await jsonRequest(`${baseUrl}/${id}`);
}

async function create(body) {
    validateBody(body);

    return await jsonRequest(baseUrl, 'POST', body, true);
}
async function edit(body, id) {
    validateBody(body);

    return await jsonRequest(`${baseUrl}/${id}`, 'PUT', body, true);
}

function validateBody(body) {
    if (body.make.length < 4) {
        throw new Error('Make field must be at leat 4 symbols long');
    }
    if (body.model.length < 4) {
        throw new Error('Model field must be at leat 4 symbols long');
    }
    if (body.description.length <= 10) {
        throw new Error('Model field must be more than 10 symbols long');
    }
    if (Number(body.price) < 0) {
        throw new Error('Price field must be positive number');
    }
    if (!body.img) {
        throw new Error('Image field is required');
    }
}

async function del(context) {
    const id = context.params.id;

    try {
        const response = await jsonRequest(
            `${baseUrl}/${id}`,
            'DELETE',
            undefined,
            true
        );
        context.page.redirect('/home');
    } catch (err) {
        console.log(err);
    }
}

export default {
    getAll,
    getOne,
    create,
    del,
    edit,
};
