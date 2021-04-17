const mongoose = require('mongoose');

const userSchema = new mongoose.Schema({
    email: {
        type: String,
        required: [true, 'Please enter a valid email'],
        unique: true,
    },
    fullName: {
        type: String,
        require: [true, 'Please enter a name'],
    },
    password: {
        type: String,
        required: [true, 'Please enter a password'],
    },
    offersBought: [{
        type: mongoose.Types.ObjectId,
        ref: 'Shoe'
    }]
});

const User = mongoose.model('User', userSchema);

module.exports = User;