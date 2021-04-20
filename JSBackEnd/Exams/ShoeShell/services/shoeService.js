const Shoe = require('../models/shoeModel');

exports.getShoes = async() => {
    return await Shoe.find().lean();
};

exports.createOffer = async(req) => {
    console.log(req.body);
    req.body.creator = req.user.id;
    const shoes = await Shoe.create(req.body);
};

exports.findOne = async(id, userId) => {
    const shoe = await Shoe.findById({ _id: id }).lean();
    shoe.isOwn = shoe.creator == userId;
    shoe.isBought = shoe.buyers.includes(userId);
    console.log(userId);
    return shoe;
}

exports.buyOne = (id, userId) => {
    return Shoe.findById({ _id: id })
        .then(shoe => {
            shoe.buyers.push(userId);

            return shoe.save();
        });
}