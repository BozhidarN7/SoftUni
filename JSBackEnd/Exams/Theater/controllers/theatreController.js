const express = require('express');

const playService = require('../services/playSErvice');

const router = express.Router();

router.route('/')
    .get(async(req, res) => {
        const plays = await playService.getPlays(req);

        if (!req.user) {
            res.render('guest', { title: 'Welcome to the Theatre', plays });
        } else {
            res.render('user-home', { title: 'Welcome to the Theatre', plays });
        }
    });

router.route('/create')
    .get((req, res) => {
        res.render('create', { title: 'Create Theater' });
    })
    .post((req, res) => {
        playService.createPlay(req.body, req)
            .then(play => res.redirect('/'))
            .catch(err => console.log(err));
    });

router.route('/:playId/details')
    .get((req, res) => {
        playService.getPlay(req.params.playId, req.user.id)
            .then(play => res.render('details', { title: `${play.title} Info`, play }))
            .catch(err => console.log(err));
    });

router.route('/:playId/like')
    .get((req, res) => {
        playService.likePlay(req.params.playId, req.user.id)
            .then(play => res.redirect(`/${req.params.playId}/details`))
            .catch(err => console.log(err));
    })
module.exports = router;