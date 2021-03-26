const express = require('express');

const router = express.Router();

router.get('/', (req, res) => {
    res.render('home', { title: 'SoftUni Wiki' });
});

router.get('/all-articles', (req, res) => {
    res.render('all-articles');
});

router.get('/details/:articleId', (req, res) => {
    res.render('article');
})

module.exports = router;