const express = require('express');

const { PORT } = require('./config/config');
const expressConfig = require('./config/express');
const mongooseConfig = require('./config/mongoose');
const routes = require('./routes');
const errorHandler = require('./middlewares/errorHandler');

const app = express();

expressConfig(app);
mongooseConfig();

app.use(routes);
app.use(errorHandler);

app.listen(PORT, () => console.log(`Listening on port ${PORT}...`));