const mongoose = require('mongoose');

const userSchema = new mongoose.Schema({
    username: {
        type: String,
        required: [true, 'Please enter a username'],
        unique: true
    },
    password: {
        type: String,
        requried: [true, 'Please enter a password'],
    },
    likedPlays: [{
        type: mongoose.Types.ObjectId,
        ref: 'Play'
    }]
});

const User = mongoose.model('User', userSchema);
module.exports = User;