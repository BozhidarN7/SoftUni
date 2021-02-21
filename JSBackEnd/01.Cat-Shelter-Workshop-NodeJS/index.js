const http = require('http');

const config = require('./config.json');
const handlers = require('./handlers');


http.createServer((req, res) => {
    for (let handler of handlers) {
        if (!handler(req, res)) {
            break;
        }
    }
}).listen(config.port, () => {
    console.log(`Listening on port ${config.port}`);
});