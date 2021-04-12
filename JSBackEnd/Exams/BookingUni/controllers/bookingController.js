const express = require('express');

const bookingService = require('../services/bookingService');
const isAuthenticated = require('../middlewares/isAuthenticated');
const router = express.Router();


router.route('/')
    .get(async(req, res) => {
        const hotels = await bookingService.getHotels();
        res.render('home', { title: 'BookingUni', hotels });
    });

router.route('/create')
    .get((req, res) => {
        res.render('create', { title: 'Add Hotel' });
    })
    .post((req, res) => {
        bookingService.createHotel(req);
        res.redirect('/');
    });

router.route('/details/:hotelId')
    .get(isAuthenticated, async(req, res) => {
        const hotel = await bookingService.findOne(req.params.hotelId);
        res.render('details', { title: `${hotel.name} Info`, hotel });
    });

router.route('/:hotelId/delete')
    .get((req, res) => {
        bookingService.deleteById(req.params.hotelId)
            .then(response => res.redirect('/'))
            .catch(err => console.log(err));
    })
module.exports = router;