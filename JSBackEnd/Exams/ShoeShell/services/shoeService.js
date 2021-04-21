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
    const shoe = await Shoe.findById({ _id: id }).populate('buyers').lean();
    shoe.isOwn = shoe.creator._id == userId;
    shoe.isBought = shoe.buyers.some(x => x._id == userId);
    console.log(shoe);
    return shoe;
}

exports.getOne = async(id) => {
    return await Shoe.findById({ _id: id }).lean();
}

exports.buyOne = (id, userId) => {
    return Shoe.findById({ _id: id })
        .then(shoe => {
            shoe.buyers.push(userId);

            return shoe.save();
        });
}

exports.editShoeOffer = async(data, id) => {
    return await Shoe.updateOne({ _id: id }, data);
}

exports.deleteBuyers = async id => {
    const shoe = await Shoe.updateOne({ _id: id }, { $set: { buyers: [] } });
}