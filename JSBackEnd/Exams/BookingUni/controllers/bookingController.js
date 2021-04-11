const express = require('express');

const bookingService = require('../services/bookingService');

const router = express.Router();


router.route('/')
    .get((req, res) => {
        res.render('home', { title: 'BookingUni' });
    });

router.route('/create')
    .get((req, res) => {
        res.render('create', { title: 'Add Hotel' });
    })
    .post((req, res) => {
        bookingService.createHotel(req);
        res.redirect('/');
    });

module.exports = router;