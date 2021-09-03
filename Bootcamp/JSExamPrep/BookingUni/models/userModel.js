const mongoose = require('mongoose');

const userSchema = new mongoose.Schema({
    email: {
        type: String,
        required: [true, 'Please provide an email!'],
        unique: true,
    },
    username: {
        type: String,
        required: [true, 'Please provide a username!'],
        unique: true,
    },
    password: {
        type: String,
        required: [true, 'Please provide a password!'],
    },
    bookedHotels: [
        {
            type: mongoose.Types.ObjectId,
            ref: 'Hotel',
        },
    ],
    offeredHotels: [
        {
            type: mongoose.Types.ObjectId,
            ref: 'Hotel',
        },
    ],
});

const User = mongoose.model('User', userSchema);
module.exports = User;
