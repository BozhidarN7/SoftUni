const Accessory = require('../models/accessory');

function createAccessory(data) {
    return Accessory.create(data);
}

module.exports = {
    createAccessory,
}