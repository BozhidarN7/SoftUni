const Hotel = require('../models/hotelModel');


exports.createHotel = async(req) => {
    const data = req.body;
    data.owner = req.user.username;
    data.usersBookedARoom = [];
    data.usersBookedARoom.push(req.user.id);
    console.log(data);
    const hotel = await Hotel.create(data);
    console.log(hotel);
}