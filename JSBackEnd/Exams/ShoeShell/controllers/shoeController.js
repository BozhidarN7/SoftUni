const express = require('express');

const router = express.Router();

router.route('/')
    .get((reqr, res) => {
        res.render('home', { title: 'Shoe Shelf' });
    })

module.exports = router;