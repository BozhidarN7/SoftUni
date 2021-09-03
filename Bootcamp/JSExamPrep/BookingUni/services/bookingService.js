const Hotel = require('../models/hotelModel.js');
const User = require('../models/userModel.js');

exports.getHotels = async () => {
    return await Hotel.find().sort({ freeRooms: -1 }).lean();
};

exports.createHotel = async (req) => {
    const data = req.body;
    data.owner = req.user.username;
    const hotel = await Hotel.create({
        name: data.hotel,
        city: data.city,
        freeRooms: Number(data['free-rooms']),
        imageUrl: data.imgUrl,
        owner: data.owner,
    });
    await User.updateOne(
        { _id: req.user.id },
        { $push: { offeredHotels: hotel._id } }
    );
};

exports.findOne = async (id) => {
    return await Hotel.findOne({ _id: id }).lean();
};

exports.deleteById = async (id) => {
    const hotel = await Hotel.deleteOne({ _id: id });
    await User.updateMany(
        { bookedHotels: id },
        { $pullAll: { bookedHotels: [id] } }
    );
};

exports.updateOne = async (id, data) => {
    const hotel = await Hotel.findOneAndUpdate(
        { _id: id },
        {
            name: data.name,
            imageUrl: data.imgUrl,
            freeRooms: data['free-rooms'],
            city: data.city,
        },
        {
            new: true,
        }
    ).lean();
    return hotel;
};
