const express = require('express');

const config = require('./config/config');

const app = new express();
app.listen(config.PORT, () => console.log(`Listening on port ${config.PORT}...`))