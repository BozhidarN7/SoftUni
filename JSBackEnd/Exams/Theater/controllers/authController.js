const express = require('express');

const authService = require('../services/authService');

const router = express.Router();

router.route('/register')
    .get((req, res) => {
        res.render('register', { title: 'Register' });
    })
    .post((req, res) => {
        authService.register(req.body, res)
            .then((response) => res.redirect('/'))
            .catch(err => console.log(err));
    })

module.exports = router;