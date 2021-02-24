const fs = require('fs/promises');
const path = require('path');
const uniqid = require('uniqid');

const Cube = require('../models/Cube');
const productsData = require('../config/products.json');

function getAll(query) {
    let result = productsData;
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
}

function getOne(id) {
    return productsData.find(x => x.id === id);
}

function createProduct(data) {
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
}

module.exports = {
    createProduct,
    getAll,
    getOne
}