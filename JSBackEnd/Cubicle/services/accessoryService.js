const Accessory = require('../models/accessory');

function createAccessory(data) {
    return Accessory.create(data);
}

function getAll() {
    return Accessory.find().lean();
}

function getAllWithout(ids) {
    return Accessory.find({ _id: { $nin: ids } }).lean();
}

module.exports = {
    createAccessory,
    getAll,
    getAllWithout,
}