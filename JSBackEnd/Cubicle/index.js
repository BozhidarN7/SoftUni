const express = require('express');
const handlebars = require('express-handlebars');
const mongoose = require('mongoose');

const config = require('./config/config');
const expressConfig = require('./config/express');
const routes = require('./routes');

const app = new express();

// requires('./config/express')(app);
expressConfig(app);

const dbURL = 'mongodb://localhost:27017/cubicle';
mongoose.connect(dbURL, { useNewUrlParser: true, useUnifiedTopology: true });
const db = mongoose.connection;
db.on('error', console.error.bind(console, 'connection error:'));
db.once('open', () => console.log('DB connection successful'));

app.use(routes);

app.listen(config.PORT, () => console.log(`Listening on port ${config.PORT}...`))