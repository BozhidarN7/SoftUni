const mongoose = require('mongoose');

const playSchema = new mongoose.Schema({
    title: {
        type: String,
        require: [true, 'Please enter a play title'],
        unique: true
    },
    description: {
        type: String,
        required: [true, 'Please enter a play description'],
        maxlength: 50
    },
    imageUrl: {
        type: String,
        require: [true, 'Please enter a imageUrl'],
    },
    isPublic: {
        type: Boolean,
        default: false
    },
    createdAt: {
        type: Date,
        require: [true, 'Please enter a creation date'],
        default: Date.now
    },
    usersLiked: [{
        type: mongoose.Types.ObjectId,
        ref: 'User'
    }]
});

const Play = mongoose.model('Play', playSchema);
module.exports = Play;