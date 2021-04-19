const mongoose = require('mongoose');

const shoeSchema = new mongoose.Schema({
    name: {
        type: String,
        required: [true, 'Please enter a shoes name'],
        unique: true,
    },
    price: {
        type: Number,
        required: [true, 'Please enter a price'],
        min: 0,
    },
    imageUrl: {
        type: String,
        required: [true, 'Please enter a imgae url'],
    },
    brand: String,
    description: String,
    createdAt: {
        type: Date,
        required: [true, 'Please enter a date of creation'],
        default: Date.now
    },
    buyers: [{
        type: mongoose.Types.ObjectId,
        ref: 'User'
    }],
    creator: {
        type: mongoose.Types.ObjectId,
        ref: 'User'
    }
});

const Shoe = mongoose.model('Shoe', shoeSchema);
module.exports = Shoe;