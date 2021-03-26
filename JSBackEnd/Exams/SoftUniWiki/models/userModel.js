const mongoose = require('mongoose');

const userSchema = new mongoose.Schema({
    username: {
        type: String,
        required: [true, 'Please specify a username'],
        unique: true
    }
});

const User = mongoose.model('User', userSchema);
module.exports = User;