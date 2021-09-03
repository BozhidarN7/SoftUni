const express = require('express');

const theaterService = require('../services/theaterService');
const isAuthenticated = require('../middlewares/isAuthenticated.js');

const router = express.Router();

module.exports = router;

router.route('/').get(async (req, res) => {
    if (req.user) {
        res.redirect('/userHome');
    }
    try {
        const theaters = await theaterService.getTheatersOrderByLikes();
        res.render('home', { title: 'theaters', theaters });
    } catch (err) {
        console.log(err);
        res.render('home', { title: 'theaters', err });
    }
});

router.route('/userHome').get(isAuthenticated, async (req, res) => {
    try {
        const userTheaters = await theaterService.getTheatersOrderByCreatedTime(
            req.query
        );
        res.render('userHome', { title: 'Theaters', userTheaters });
    } catch (err) {
        console.log(err);
        res.render('userHome', { title: 'Theaters', err });
    }
});

router.route('/sort/byLikes').get(isAuthenticated, async (req, res) => {
    try {
        const userTheaters = await theaterService.getTheatersOrderByLikes(
            req.query
        );
        res.render('userHome', { title: 'Theaters', userTheaters });
    } catch (err) {
        console.log(err);
        res.render('userHome', { title: 'Theaters', err });
    }
});

router
    .route('/create')
    .get(isAuthenticated, (req, res) => {
        res.render('create', { title: 'Add Theater' });
    })
    .post((req, res) => {
        theaterService
            .create(req.body, req)
            .then((response) => res.redirect('/userHome'))
            .catch((err) => {
                console.log(err.message);
                res.render('create', { title: 'Add Theater', err });
            });
    });

router.route('/details/:theaterId').get(isAuthenticated, async (req, res) => {
    try {
        const theater = await theaterService.getById(req.params.theaterId);

        if (req.user.username === theater.owner) {
            res.locals.canDeleteAndEdit = true;
        }
        if (theater.usersLiked.find((x) => x == req.user.id)) {
            res.locals.liked = true;
        }
        res.render('details', {
            title: `${theater.title} Info`,
            theater,
        });
    } catch (err) {
        console.log(err);
    }
});

router.route('/:theaterId/delete').get((req, res) => {
    theaterService
        .deleteById(req.params.theaterId)
        .then((response) => res.redirect('/userHome'))
        .catch((err) => {
            console.log(err);
        });
});

router
    .route('/:theaterId/edit')
    .get(async (req, res) => {
        try {
            const theater = await theaterService.findById(req.params.theaterId);
            if (theater.isPublic) {
                theater.checked = 'checked';
            }
            res.render('edit', { title: 'Edit Theater', theater });
        } catch (err) {
            console.log(err);
        }
    })
    .post(async (req, res) => {
        console.log(req.body);
        let theater = undefined;
        try {
            theater = await theaterService.update(
                req.params.theaterId,
                req.body,
                req
            );
            if (req.user.username === theater.owner) {
                res.locals.canDeleteAndEdit = true;
            }
            if (theater.usersEntrolled.find((x) => x === req.user.id)) {
                res.locals.entrolled = true;
            }
            res.render('details', {
                title: `${theater.title} Info`,
                theater,
            });
        } catch (err) {
            console.log(err);
            res.render('details', {
                title: `${theater.title} Info`,
                theater,
                err,
            });
        }
    });

router.route('/:theaterId/like').get(async (req, res) => {
    try {
        theaterService.like(req.params.theaterId, req.user);
        const theater = await theaterService.findById(req.params.theaterId);
        res.redirect(`/details/${theater._id}`);
    } catch (err) {
        console.log(err);
    }
});
