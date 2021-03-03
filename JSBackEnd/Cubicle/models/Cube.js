const mongoose = require('mongoose');

// class Cube {
//     constructor(id, name, description, imageUrl, level) {
//         this.id = id;
//         this.name = name;
//         this.description = description;
//         this.imageUrl = imageUrl;
//         this.level = level;
//     }
// }
// module.exports = Cube;

const cubeSchema = new mongoose.Schema({
    name: {
        type: String,
        required: [true, 'Cube must have a name']
    },
    description: {
        type: String,
        required: [true, 'Cube must have a description'],
        maxLength: [150, 'Description length must not exceed 150']
    },
    imageUrl: {
        type: String,
        required: [true, 'Cube must have an image'],
        validate: /^https?/,
    },
    difficultyLevel: {
        type: Number,
        required: [true, 'Difficulty level must be specified'],
        min: 1,
        max: 6
    },
    accessories: [{
        type: mongoose.Types.ObjectId,
        ref: 'Accessory'
    }]
});

cubeSchema.pre('save', function(next) {
    const nameToLower = this.name.toLowerCase();
    this.name = nameToLower;
    next();
});

const Cube = new mongoose.model('Cube', cubeSchema);
module.exports = Cube;