const express = require('express');

const router = express.Router();

const isAuthenticated = require('../middlewares/isAuthenticated');
const articleService = require('../services/articleService');

router.get('/', (req, res) => {
    res.render('home', { title: 'SoftUni Wiki' });
});

router.get('/all-articles', (req, res) => {
    res.render('all-articles');
});

router.get('/details/:articleId', (req, res) => {
    res.render('article');
});

router.route('/create/article')
    .get(isAuthenticated, (req, res) => {
        res.render('create', { title: 'Create article' });
    })
    .post((req, res) => {
        articleService
            .createArticle(req)
            .then(() => res.redirect('/'))
            .catch((err) => {
                res.render('create', { err });
            });
    })

module.exports = router;