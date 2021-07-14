import auth from './authService.js';

export async function jsonRequest(url, method, body, isAuthorized, skipResult) {
    const headers = {};

    if (method === undefined) {
        method = 'GET';
    }

    if (['post', 'put', 'patch'].includes(method.toLowerCase())) {
        headers['Content-Type'] = 'application/json';
    }

    if (isAuthorized) {
        headers['X-Authorization'] = auth.getAuthToken();
    }

    const options = {
        headers,
        method,
    };

    if (body !== undefined) {
        options.body = JSON.stringify(body);
    }

    const response = await fetch(url, options);
    if (!response.ok) {
        const message = await response.text();
        throw new Error(
            `${response.status}: ${response.statusText}\n${message}`
        );
    }

    let result = undefined;
    if (!skipResult) {
        result = await response.json();
    }
    return result;
}
