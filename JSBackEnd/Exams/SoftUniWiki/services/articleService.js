const mongoose = require('mongoose');

const Article = require('../models/article');

exports.createArticle = async(req) => {
    const { title, description } = req.body;
    return Article.create({ title, description, articleAuthor: req.user.id });

}