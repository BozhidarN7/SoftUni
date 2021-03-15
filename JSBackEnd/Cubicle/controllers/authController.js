const express = require('express');

const authService = require('../services/authService');
const isAuthenticated = require('../middlewares/isAuthenticated');
const isGuest = require('../middlewares/isGuests');

const router = new express.Router();

router.route('/login')
    .get(isGuest, (req, res) => {
        res.render('login', { title: 'login' });
    })
    .post(isGuest, async(req, res) => {
        const { username, password } = req.body;
        try {
            const token = await authService.login({ username, password });
            res.cookie('USER_SESSION', token);
            res.redirect('/');
        } catch (err) {
            console.log(err);
            res.render('login', { err });
        }
    });

router.route('/register')
    .get(isGuest, (req, res) => {
        res.render('register', { title: 'registration' });
    })
    .post(isGuest, async(req, res) => {
        const { username, password, repeatPassword } = req.body;
        if (password !== repeatPassword) {
            res.render('register', { message: 'Password mismatch' });
            return;
        }
        try {
            await authService.registerUser(req.body);
            res.redirect('/auth/login');
        } catch (err) {
            console.log(err);
            res.render('register', { err });
        }
    });
router.route('/logout')
    .get(isAuthenticated, (req, res) => {
        res.clearCookie('USER_SESSION');
        res.redirect('/');
    })
module.exports = router;