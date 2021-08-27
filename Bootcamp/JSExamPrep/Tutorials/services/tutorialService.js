const Tutorial = require('../models/tutorialModel.js');
const User = require('../models/userModel.js');

exports.create = async (data, req) => {
    try {
        const tutorial = await Tutorial.create({
            title: data.title,
            description: data.description,
            imageUrl: data.imageUrl,
            duration: data.duration,
            createdAt: Date.now(),
            owner: req.user.username,
        });
    } catch (err) {
        throw err;
    }
};

exports.getTutorialsOrderByEnrolledUsers = async () => {
    try {
        // return await Tutorial.find().sort({ usersEntrolled: -1 }).lean();
        return await Tutorial.aggregate([
            {
                $project: {
                    title: 1,
                    description: 1,
                    imageUrl: 1,
                    duration: 1,
                    createdAt: 1,
                    usersEntrolled: 1,
                    length: { $size: '$usersEntrolled' },
                },
            },
            { $sort: { length: -1 } },
        ]);
    } catch (err) {
        console.log(err);
        throw err;
    }
};

exports.getTutorialsOrderByCreatedTime = async (searchQuery) => {
    try {
        let query = Tutorial.find();
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
        return await Tutorial.findById({ _id: id }).lean();
    } catch (err) {
        console.log(err);
        throw err;
    }
};

exports.deleteById = async (id) => {
    try {
        return await Tutorial.deleteOne({ _id: id });
    } catch (err) {
        console.log(err);
        throw err;
    }
};

exports.findById = async (id) => {
    try {
        return await Tutorial.findOne({ _id: id }).lean();
    } catch (err) {
        console.log(err);
        throw err;
    }
};
exports.findByIdAndPopulate = async (id) => {
    try {
        return await Tutorial.findOne({ _id: id })
            .populate('usersEntrolled')
            .lean();
    } catch (err) {
        console.log(err);
        throw err;
    }
};

exports.update = async (id, data, req) => {
    try {
        return await Tutorial.findOneAndUpdate(
            { _id: id },
            {
                title: data.title,
                description: data.description,
                imageUrl: data.imageUrl,
                duration: data.duration,
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

exports.enroll = async (tutorialId, user) => {
    try {
        await Tutorial.updateOne(
            { _id: tutorialId },
            { $push: { usersEntrolled: user.id } }
        );
        await User.updateOne(
            { _id: user.id },
            { $push: { enrolledCourse: tutorialId } }
        );
    } catch (err) {
        console.log(err);
        throw err;
    }
};
