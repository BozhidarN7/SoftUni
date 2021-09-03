const mongoose = require('mongoose');

const theaterSchema = new mongoose.Schema({
    title: {
        type: String,
        required: [true, 'Please provide a title!'],
        unique: true,
    },
    description: {
        type: String,
        required: [true, 'Please provide a description!'],
        maxLength: [50, 'Description must be at most 50 characters'],
    },
    imageUrl: {
        type: String,
        required: [true, 'Please provide a imageUrl'],
    },
    isPublic: {
        type: Boolean,
        required: [true, 'Please provide a duration!'],
        default: true,
    },
    createdAt: {
        type: Date,
        required: [true, 'Please provide a date!'],
    },
    usersLiked: [
        {
            type: mongoose.Types.ObjectId,
            ref: 'User',
        },
    ],
    owner: String,
});

const Theater = mongoose.model('Theater', theaterSchema);
module.exports = Theater;
