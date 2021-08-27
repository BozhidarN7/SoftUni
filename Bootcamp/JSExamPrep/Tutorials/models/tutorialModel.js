const mongoose = require('mongoose');

const tutorialSchema = new mongoose.Schema({
    title: {
        type: String,
        required: [true, 'Please provide a title!'],
        minLength: [4, 'Title must be at least 4 characters'],
        unique: true,
    },
    description: {
        type: String,
        required: [true, 'Please provide a description!'],
        minLength: [20, 'Description must be at leat 20 characters'],
        maxLength: [50, 'Description must be at most 50 characters'],
    },
    imageUrl: {
        type: String,
        required: [true, 'Please provide a imageUrl'],
        validate: {
            validator: function (v) {
                return v.startsWith('http') || v.startsWith('https');
            },
            message: (props) => `${props.value} is not a valid image url`,
        },
    },
    duration: {
        type: String,
        required: [true, 'Please provide a duration!'],
    },
    createdAt: {
        type: Date,
        required: [true, 'Please provide a date!'],
    },
    usersEntrolled: [
        {
            type: mongoose.Types.ObjectId,
            ref: 'User',
        },
    ],
    owner: String,
});

const Tutorial = mongoose.model('Tutorial', tutorialSchema);
module.exports = Tutorial;
