const mongoose = require('mongoose');

const hotelSchema = new mongoose.Schema({
    name: {
        type: String,
        required: [true, 'Please enter a hotel name'],
        unique: true,
    },
    city: {
        type: String,
        required: [true, 'Please enter a city']
    },
    imageUrl: {
        type: String,
        required: [true, 'Please provide an image url']
    },
    freeRooms: {
        type: Number,
        required: true,
        min: [1, 'At least one room'],
        max: [100, 'Too many rooms']
    },
    usersBookedARoom: [{
        type: mongoose.Types.ObjectId,
        ref: 'User'
    }],
    owner: {
        type: String
    }
});

const Hotel = mongoose.model('Hotel', hotelSchema);

module.exports = Hotel;