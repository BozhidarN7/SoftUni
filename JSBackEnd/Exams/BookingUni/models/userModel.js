const mongoose = require('mongoose');

const userSchema = new mongoose.Schema({
    email: {
        type: String,
        required: [true, 'Please provide an email'],
        unique: true,
        validate: {
            validator: function(val) {
                return /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/.test(val)
            },
            message: props => `${props.value} is not a valid email`
        }
    },
    username: {
        type: String,
        required: [true, 'Please enter a username'],
        unique: true
    },
    password: {
        type: String,
        required: [true, 'Please enter a password'],
        minLength: [5, 'Password should be at least 5 characters long and should consist only english letters and digits']
    },
    bookedHotels: [{
        type: mongoose.Types.ObjectId,
        ref: 'Hotel'
    }],
    offeredHotels: [{
        type: mongoose.Types.ObjectId,
        ref: 'Hotel'
    }]

});

const User = mongoose.model('User', userSchema);
module.exports = User;