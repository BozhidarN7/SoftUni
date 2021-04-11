const express = require('express');

const router = express.Router();

router.route('/login')
    .get((req, res) => {
        res.render('login', { title: 'Login' });
    })

router.route('/register')
    .get((req, res) => {
        res.render('register', { title: 'Register' });
    })

module.exports = router;