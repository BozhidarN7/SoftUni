const express = require('express');
const handlebars = require('express-handlebars');
const mongoose = require('mongoose');

const config = require('./config/config');
const expressConfig = require('./config/express');
const mongooseConfig = require('./config/mongoose');
const routes = require('./routes');

const app = new express();

// requires('./config/express')(app);
expressConfig(app);
mongooseConfig(app);

app.use(routes);

app.listen(config.PORT, () => console.log(`Listening on port ${config.PORT}...`))