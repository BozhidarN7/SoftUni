const Hotel = require('../models/hotelModel');
const User = require('../models/userModel');

exports.createHotel = async(req) => {
    const data = req.body;
    data.owner = req.user.username;
    const hotel = await Hotel.create(data);
    await User.updateOne({ _id: req.user.id }, { '$push': { 'offeredHotels': hotel._id } });
};

exports.getHotels = async() => {
    return await Hotel.find().lean();
};

exports.findOne = async(id) => {
    const hotel = await Hotel.findOne({ _id: id }).lean();
    return hotel;
}

exports.deleteById = async(id) => {
    const hotel = await Hotel.deleteOne({ _id: id });
}

exports.updateOne = async(id, data) => {
    const hotel = await Hotel.findOneAndUpdate({ _id: id }, data, { new: true }).lean();
    return hotel;
};

exports.bookHotel = async(id, user) => {
    await Hotel.updateOne({ _id: id }, { '$push': { 'usersBookedARoom': user.id } })
    await User.updateOne({ _id: user.id }, { '$push': { 'bookedHotels': id } });
}

// exports.deleteElementsInArray = async(id, user) => {
//     await User.updateOne({ _id: user.id }, { $set: { bookedHotels: [] } });
// }