const Shoe = require('../models/shoeModel');

exports.getShoes = async() => {
    return await Shoe.find().lean();
}

exports.createOffer = async(req) => {
    console.log(req.body);
    req.body.creator = req.user.id;
    const shoes = await Shoe.create(req.body);
}