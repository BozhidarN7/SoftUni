const mongoose = require('mongoose');

const userSchema = new mongoose.Schema({
    id: mongoose.Types.ObjectId,
    username: {
        type: String,
        required: true,
        unique: true,
        minLength: 5,
        validate: {
            validator: (value) => {
                return /^[a-zA-Z0-9]+$/.test(value);
            },
            message: () => {
                return 'Username must consist only frrom letters and digits';
            }
        }
    },
    password: {
        type: String,
        required: true,
        minLength: 8,
        validate: {
            validator: (value) => {
                return /^[a-zA-Z0-9]+$/.test(value);
            },
            message: () => {
                return 'Password must consist only from letters and digits';
            }
        }
    }
});

module.exports = mongoose.model('User', userSchema);