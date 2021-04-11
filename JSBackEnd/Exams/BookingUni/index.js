const express = require('express');

const config = require('./config/config');
const expresConfig = require('./config/express');
const routes = require('./routes');

const app = new express();

expresConfig(app);

app.use(routes);

app.listen(config.PORT, () => console.log(`Listening on port ${config.PORT}...`));