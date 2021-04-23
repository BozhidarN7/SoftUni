const Play = require('../models/playModel');

exports.getPlays = async() => {
    return await Play.find().lean();
}

exports.createPlay = async data => {
    if (data.isPublic) {
        data.isPublic = true;
    }
    const play = await Play.create(data);
    console.log(play);
    return play;
}