const mongoose = require('mongoose');

module.exports = (app) => {
    const dbURL = 'mongodb://localhost:27017/wiki';
    mongoose.connect(dbURL, { useNewUrlParser: true, useUnifiedTopology: true });
    const db = mongoose.connection;
    db.on('error', console.error.bind(console, 'Connection error.'));
    db.on('open', () => console.log('DB connection successful'));
}