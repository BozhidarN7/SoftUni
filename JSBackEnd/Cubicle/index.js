const express = require('express');
const handlebars = require('express-handlebars');

const config = require('./config/config');
const expressConfig = require('./config/express');
const routes = require('./routes');

const app = new express();

// requires('./config/express')(app);
expressConfig(app);

app.use(routes);

app.listen(config.PORT, () => console.log(`Listening on port ${config.PORT}...`))