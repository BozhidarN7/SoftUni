const Theater = require('../models/theaterModel.js');
const User = require('../models/userModel.js');

exports.create = async (data, req) => {
    try {
        const theater = await Theater.create({
            title: data.title,
            description: data.description,
            imageUrl: data.imageUrl,
            isPublic: data.on ? true : false,
            createdAt: Date.now(),
            owner: req.user.username,
        });
    } catch (err) {
        throw err;
    }
};

exports.getTheatersOrderByLikes = async () => {
    try {
        // return await Tutorial.find().sort({ usersEntrolled: -1 }).lean();
        return await Theater.aggregate([
            {
                $project: {
                    title: 1,
                    description: 1,
                    imageUrl: 1,
                    isPublic: 1,
                    createdAt: 1,
                    usersLiked: 1,
                    length: { $size: '$usersLiked' },
                },
            },
            { $sort: { length: -1 } },
            { $limit: 3 },
        ]);
    } catch (err) {
        console.log(err);
        throw err;
    }
};

exports.getTheatersOrderByCreatedTime = async (searchQuery) => {
    try {
        let query = Theater.find();
        if (searchQuery.search) {
            query = query.find({
                title: { $regex: `.*${searchQuery.search}.*` },
            });
        }
        return await query.sort({ createdAt: -1 }).lean();
    } catch (err) {
        console.log(err);
        throw err;
    }
};

exports.getById = async (id) => {
    try {
        return await Theater.findById({ _id: id }).lean();
    } catch (err) {
        console.log(err);
        throw err;
    }
};

exports.deleteById = async (id) => {
    try {
        return await Theater.deleteOne({ _id: id });
    } catch (err) {
        console.log(err);
        throw err;
    }
};

exports.findById = async (id) => {
    try {
        return await Theater.findOne({ _id: id }).lean();
    } catch (err) {
        console.log(err);
        throw err;
    }
};
exports.findByIdAndPopulate = async (id) => {
    try {
        return await Theater.findOne({ _id: id })
            .populate('usersEntrolled')
            .lean();
    } catch (err) {
        console.log(err);
        throw err;
    }
};

exports.update = async (id, data, req) => {
    try {
        return await Theater.findOneAndUpdate(
            { _id: id },
            {
                title: data.title,
                description: data.description,
                imageUrl: data.imageUrl,
                isPublic: data.on ? true : false,
                createdAt: Date.now(),
                owner: req.user.username,
            },
            {
                new: true,
            }
        ).lean();
    } catch (err) {
        console.log(err);
        throw err;
    }
};

exports.like = async (theaterId, user) => {
    try {
        await Theater.updateOne(
            { _id: theaterId },
            { $push: { usersLiked: user.id } }
        );
        await User.updateOne(
            { _id: user.id },
            { $push: { likedPlays: theaterId } }
        );
    } catch (err) {
        console.log(err);
        throw err;
    }
};
