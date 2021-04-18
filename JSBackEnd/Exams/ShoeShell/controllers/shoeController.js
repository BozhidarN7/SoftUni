const express = require('express');

const router = express.Router();

router.route('/')
    .get((req, res) => {
        if (!req.user) {
            res.render('home', { title: 'Shoe Shelf' });
        } else {
            res.render('shoes', { title: 'Shoe Shelf' });
        }
    })

module.exports = router;