const mongoose = require('mongoose');

const accessorySchema = new mongoose.Schema({
    name: {
        type: String,
        required: [true, 'Accessory must have a name']
    },
    imageUrl: {
        type: String,
        required: [true, 'Accessory must have a image url']
    },
    description: {
        type: String,
        required: [true, 'Accessory must have a description']
    }
});

const Accessory = mongoose.model('Accessory', accessorySchema);
module.exports = Accessory;