const mongoose = require('mongoose');

const userSchema = new mongoose.Schema({
    username: {
        type: String,
        required: [true, 'Please provide a username!'],
        minLength: [3, 'Username must be at least 5 characters long!'],
        validate: {
            validator: function (v) {
                return /^[A-Za-z0-9]{5,}$/.test(v);
            },
            message: (props) => `${props.value} is not a valid username`,
        },
        unique: [true, 'Username must be unique'],
    },
    password: {
        type: String,
        minLength: [3, 'Password must be at leat 3 characters long!'],
        required: [true, 'Please provide a password!'],
    },
    likedPlays: [
        {
            type: mongoose.Types.ObjectId,
            ref: 'Theater',
        },
    ],
});

const User = mongoose.model('User', userSchema);
module.exports = User;
