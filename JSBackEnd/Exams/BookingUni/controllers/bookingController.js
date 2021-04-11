const express = require('express');

const router = express.Router();

router.route('/')
    .get((req, res) => {
        res.render('home', { title: 'BookingUni' });
    });

router.route('/create')
    .get((req, res) => {
        res.render('create', { title: 'Add Hotel' });
    })

module.exports = router;