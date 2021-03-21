const express = require('express');
const validator = require('validator');
const { check, validationResult } = require('express-validator');

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

const isStrongPasswordMiddleware = function(req, res, next) {
    const password = req.body.password;
    const isStrongPassword = validator.isStrongPassword(password, {
        minLength: 8,
        minLowercase: 1,
        minUppercase: 1,
        minNumbers: 1,
        minSymbols: 1
    });
    if (!isStrongPassword) {
        return res.render('register', { err: { message: 'You should have strong password' }, username: req.body.username });
    }
    next();
}

router.route('/register')
    .get(isGuest, (req, res) => {
        res.render('register', { title: 'registration' });
    })
    .post(check('username', 'Specify username').notEmpty(), check('password', 'Password must be at least 5 characters').isLength({ min: 5 }), isGuest, async(req, res) => {
        const { username, password, repeatPassword } = req.body;

        if (password !== repeatPassword) {
            res.render('register', { error: { message: 'Password mismatch' } });
            return;
        }

        const errors = validationResult(req);

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