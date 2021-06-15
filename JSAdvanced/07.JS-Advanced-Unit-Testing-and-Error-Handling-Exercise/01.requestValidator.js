function solve(req) {
    function generateErrorMessage(wrongPart) {
        return `Invalid request header: Invalid ${wrongPart}`;
    }

    const methods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    const versions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];

    if (!req.hasOwnProperty('method') || !methods.includes(req.method)) {
        throw new Error(generateErrorMessage('Method'));
    }
    if (
        !req.hasOwnProperty('uri') ||
        req.uri.trim() === '' ||
        (!req.uri.match(/^[\w.]+$/) && req.uri !== '*')
    ) {
        throw new Error(generateErrorMessage('URI'));
    }
    if (!req.hasOwnProperty('version') || !versions.includes(req.version)) {
        throw new Error(generateErrorMessage('Version'));
    }
    if (!req.hasOwnProperty('message') || !req.message.match(/^[^<>\\&'"]*$/)) {
        throw new Error(generateErrorMessage('Message'));
    }

    return req;
}

console.log(
    solve({
        method: 'GET',
        uri: '*',
        version: 'HTTP/1.1',
        message: 'asdfadfa,',
    })
);
