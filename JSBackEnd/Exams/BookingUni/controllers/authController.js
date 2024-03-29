const express = require('express');

const router = express.Router();

const authService = require('../services/authService');

router.route('/login')
    .get((req, res) => {
        res.render('login', { title: 'Login' });
    })
    .post((req, res) => {
        authService.login(req.body, res).then(response => res.redirect('/')).catch(err => console.log(err));
    })

router.route('/register')
    .get((req, res) => {
        res.render('register', { title: 'Register' });
    })
    .post((req, res) => {
        authService.register(req.body, res)
            .then(response => res.redirect('/'))
            .catch(err => {
                console.log(err.message);
                res.render('register', { title: 'Register', err });
            });
    });

router.route('/logout')
    .get((req, res) => {
        res.clearCookie('jwt');
        res.redirect('/');
    });

router.route('/profile/:userId')
    .get((req, res) => {
        authService.getUser(req.params.userId)
            .then(user => {
                res.render('profile', { title: `${user.username} Profile`, user });
            })
            .catch(err => console.log(err));
    })

module.exports = router;