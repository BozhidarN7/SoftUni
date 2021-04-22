const express = require('express');

const { PORT } = require('./config/config');
const expressConfig = require('./config/express');
const mongooseConfig = require('./config/mongoose');
const routes = require('./routes');

const app = express();

expressConfig(app);
mongooseConfig();

app.use(routes);

app.listen(PORT, () => console.log(`Listening on port ${PORT}...`));