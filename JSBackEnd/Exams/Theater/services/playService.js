const Play = require('../models/playModel');
const User = require('../models/userModel');

// const soryByCountOfLikes = async() => {
//     return await Play.find().sort()
// }

exports.getPlays = async(req) => {
    return await Play.find().lean();

}

exports.createPlay = async(data, req) => {
    if (data.isPublic) {
        data.isPublic = true;
    }
    data.createdBy = req.user.id;
    data.likes = 0;
    const play = await Play.create(data);
    return play;
};

exports.getPlay = async(id, userId) => {
    const play = await Play.findById({ _id: id }).lean();
    play.isOwn = play.createdBy == userId;
    play.isLiked = play.usersLiked.some(x => x._id == userId);
    play.checked = play.isPublic ? 'checked' : '';
    return play;
}

exports.likePlay = async(id, userId) => {
    await Play.updateOne({ _id: id }, { '$push': { 'usersLiked': userId }, $inc: { likes: 1 } })
    await User.updateOne({ _id: userId }, { '$push': { 'likedPlays': id } });
}

exports.deletePlay = async id => {
    return await Play.deleteOne({ _id: id });
};

exports.updatePlay = async(data, id) => {
    if (!data.isPublic) {
        data.isPublic = false;
    } else {
        data.isPublic = true;
    }
    return await Play.updateOne({ _id: id }, data);
}