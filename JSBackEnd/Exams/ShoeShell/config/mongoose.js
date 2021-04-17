const mongoose = require('mongoose');

module.exports = () => {
    const dbURL = 'mongodb://localhost:27017/shoeShelf';
    mongoose.connect(dbURL, { useNewUrlParser: true, useUnifiedTopology: true });
    const db = mongoose.connection;
    db.on('error', console.error.bind(console, 'Connection error.'));
    db.on('open', () => console.log('DB connection successful'));
}