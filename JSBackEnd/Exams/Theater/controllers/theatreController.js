const express = require('express');

const router = express.Router();

router.route('/')
    .get((req, res) => {
        res.render('guest', { title: 'Welcome to the Theatre' });
    });

module.exports = router;