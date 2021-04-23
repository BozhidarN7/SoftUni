const express = require('express');

const playService = require('../services/playSErvice');

const router = express.Router();

router.route('/')
    .get(async(req, res) => {
        const plays = await playService.getPlays();
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
        playService.createPlay(req.body)
            .then(play => res.redirect('/'))
            .catch(err => console.log(err));
    })


module.exports = router;