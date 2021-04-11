const express = require('express');

const config = require('./config/config');
const expresConfig = require('./config/express');
const mongooseConfig = require('./config/mongoose');
const routes = require('./routes');

const app = new express();

expresConfig(app);
mongooseConfig(app);

app.use(routes);

app.listen(config.PORT, () => console.log(`Listening on port ${config.PORT}...`));