const express = require('express');

const router = express.Router();

const isAuthenticated = require('../middlewares/isAuthenticated');
const articleService = require('../services/articleService');

router.get('/', (req, res) => {
    res.render('home', { title: 'SoftUni Wiki' });
});

router.get('/all-articles', async(req, res) => {
    const articles = await articleService.getAllArticles();
    res.render('all-articles', { title: 'List of articles', articles });
});

router.get('/details/:articleId', async(req, res) => {
    const article = await articleService.getById(req.params.articleId);
    res.render('article', { article });
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
    });

router.route('/:articleId/edit')
    .get((req, res) => {
        articleService.getById(req.params.articleId)
            .then(article => {
                res.render('edit', { article });
            })
            .catch(err => {
                console.log(err);
            });
    })
    .post((req, res) => {
        articleService.updateOne(req.params.articleId, req.body)
            .then(response => {
                res.redirect(`/details/${req.params.articleId}`);
            })
            .catch(err => {
                console.log(err);
            });
    });
router.route('/:articleId/delete')
    .get((req, res) => {
        articleService.deleteById(req.params.articleId)
            .then((response) => {
                res.redirect('/');
            })
            .catch(err => {
                console.log(err);
            });
    })
module.exports = router;