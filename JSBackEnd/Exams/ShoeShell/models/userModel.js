const mongoose = require('mongoose');
const bcrypt = require('bcrypt');

const config = require('../config/config');

const userSchema = new mongoose.Schema({
    email: {
        type: String,
        required: [true, 'Please enter a valid email'],
        unique: true,
        minlength: [3, 'The email must be at leat 3 characters long'],
        validate: {
            validator: function(val) {
                return /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/.test(val);
            },
            message: props => `${props.value} is not a valid email`
        }
    },
    fullName: {
        type: String,
        require: [true, 'Please enter a name'],
    },
    password: {
        type: String,
        required: [true, 'Please enter a password'],
        minlength: 3
    },
    offersBought: [{
        type: mongoose.Types.ObjectId,
        ref: 'Shoe'
    }]
});

userSchema.pre('save', async function() {
    const salt = await bcrypt.genSalt(config.SALT);
    const hash = await bcrypt.hash(this.password, salt);
    this.password = hash;
})

const User = mongoose.model('User', userSchema);

module.exports = User;