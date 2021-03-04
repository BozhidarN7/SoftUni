const fs = require('fs/promises');
const path = require('path');
const uniqid = require('uniqid');

const Cube = require('../models/cube');
const Accessory = require('../models/accessory');
const productsData = require('../config/products.json');

async function getAll(searchQuery) {
    /*let result = productsData;
    if (query.search) {
        result = result.filter(x => x.name.toLowerCase().includes(query.search));
    }
    if (query.from) {
        result = result.filter(x => Number(x.level) >= query.from);
    }
    if (query.to) {
        result = result.filter(x => Number(x.level) <= query.to);
    }
    return result;
    */
    try {
        let query = Cube.find();
        if (searchQuery.search) {
            query = query.find({ name: { $regex: `.*${searchQuery.search}.*` } });
        }
        if (searchQuery.from) {
            query = query.find({ difficultyLevel: { $gte: searchQuery.from } });
        }
        if (searchQuery.to) {
            query = query.find({ difficultyLevel: { $lte: searchQuery.to } });
        }
        const cubes = await query.lean();
        return cubes;
    } catch {
        throw new Error('Cannot get data from db');
    }
}

async function getOne(id) {
    // return productsData.find(x => x.id === id);
    return await Cube.findById(id).lean();
}

function getOneWithAccessories(id) {
    return Cube.findById(id).populate('accessories').lean();
}

function createProduct(data) {
    /*
    const cube = new Cube(uniqid(), data.name, data.description, data.imageUrl, data.difficultyLevel);
    // console.log(path.join(__dirname, '/../config/products.json'));
    // console.log(path.resolve('../config/products.json'));
    productsData.push(cube);
    // fs.writeFile(__dirname + '/../config/products.json', JSON.stringify(productsData), (err) => {
    //     if (err) {
    //         throw err;
    //     }
    // });
    return fs.writeFile(path.join(__dirname, '/../config/products.json'), JSON.stringify(productsData));
    */
    return Cube.create(data);
}

async function attachAccessory(productId, accessoryId) {
    const cube = await Cube.findById(productId);
    const accessory = await Accessory.findById(accessoryId);
    cube.accessories.push(accessory);
    return cube.save();
}

module.exports = {
    createProduct,
    getAll,
    getOne,
    attachAccessory,
    getOneWithAccessories
}