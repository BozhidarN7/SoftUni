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
        if (req.user.username == hotel.owner) {
            res.locals.canDeleteAndEdit = true;
        }
        if (hotel.usersBookedARoom.find(x => x == req.user.id)) {
            res.locals.booked = true;
        }
        res.render('details', { title: `Hotel ${hotel.name} Info`, hotel });
    });

router.route('/:hotelId/delete')
    .get((req, res) => {
        bookingService.deleteById(req.params.hotelId)
            .then(response => res.redirect('/'))
            .catch(err => console.log(err));
    });

router.route('/:hotelId/edit')
    .get((req, res) => {
        bookingService.findOne(req.params.hotelId)
            .then(hotel => {
                res.render('edit', { title: `Hotel ${hotel.name} Edit`, hotel });
            })
            .catch(err => console.log(err));
    })
    .post((req, res) => {
        bookingService.updateOne(req.params.hotelId, req.body)
            .then(hotel => {
                res.render('details', { title: `Hotel ${hotel.name} Info`, hotel });
                // res.redirect(`/details/${req.params.hotelId}`);
            })
            .catch(err => console.log(err));
    });

router.route(('/:hotelId/book'))
    .get((req, res) => {
        bookingService.bookHotel(req.params.hotelId, req.user)
            .then(response => {
                res.redirect('/');
            })
            .catch(err => {
                console.log(err);
            })
    });


module.exports = router;