const mongoose = require('mongoose');
module.exports = (app) => {
    const dbURL = 'mongodb://localhost:27017/cubicle';
    mongoose.connect(dbURL, { useNewUrlParser: true, useUnifiedTopology: true });
    const db = mongoose.connection;
    db.on('error', console.error.bind(console, 'connection error:'));
    db.once('open', () => console.log('DB connection successful'));
}