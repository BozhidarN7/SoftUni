export async function jsonRequest(url, method, body, isAuthorized, skipResult) {
    const headers = {};

    if (!method) {
        method = 'GET';
    }

    if (['post', 'put', 'path'].includes(method.toLowerCase())) {
        headers['Content-Type'] = 'application/json';
    }

    if (isAuthorized) {
        headers['X-Authorization'] = localStorage.getItem('accessToken');
    }
    const options = {
        method,
        headers,
    };

    if (body) {
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
