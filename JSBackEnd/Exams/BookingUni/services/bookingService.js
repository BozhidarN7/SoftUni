const Hotel = require('../models/hotelModel');


exports.createHotel = async(req) => {
    const data = req.body;
    data.owner = req.user.username;
    data.usersBookedARoom = [];
    data.usersBookedARoom.push(req.user.id);
    console.log(data);
    const hotel = await Hotel.create(data);
    console.log(hotel);
};

exports.getHotels = async() => {
    return await Hotel.find().lean();
};

exports.findOne = async(id) => {
    const hotel = await Hotel.findOne({ _id: id }).lean();
    return hotel
}

exports.deleteById = async(id) => {
    await Hotel.deleteOne({ _id: id });
}

exports.updateOne = async(id, data) => {
    const hotel = await Hotel.findOneAndUpdate({ _id: id }, data, { new: true }).lean();
    return hotel;
}