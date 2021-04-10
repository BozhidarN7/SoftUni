const mongoose = require('mongoose');

const Article = require('../models/article');

exports.createArticle = async(req) => {
    const { title, description } = req.body;
    return Article.create({ title, description, articleAuthor: req.user.id });
};
exports.getAllArticles = async() => {
    return Article.find().lean();
};

exports.getById = async id => {
    return await Article.findById({ _id: id }).lean();
};

exports.updateOne = (id, articleData) => {
    return Article.updateOne({ _id: id }, articleData);
};

exports.deleteById = (id) => {
    return Article.deleteOne({ _id: id });
};

exports.getLatestThree = async() => {
    const articles = await Article.find().sort({ creationData: -1 }).limit(3).lean();
    return articles;
}