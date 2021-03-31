const mongoose = require('mongoose');

const articleSchema = new mongoose.Schema({
    title: {
        type: String,
        required: [true, 'Please specify title'],
        unique: true,
        minLength = 5,
    },
    description: {
        type: String,
        required: [true, 'Please specify description'],
        minLength: 20
    },
    articleAuthor: {
        type: mongoose.Types.ObjectId,
        ref: 'User'
    },
    creationData: {
        type: Date,
        default: Date.now()
    }
});

const Article = moongose.model('Article', articleSchema);
module.exports = Article;