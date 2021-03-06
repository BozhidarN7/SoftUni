const express = require('express');

const authService = require('../services/authService')

const router = express.Router();


router.route('/login')
    .get((req, res) => {
        res.render('login');
    })
    .post(async(req, res) => {
        try {
            await authService.login(req.body, res);
            res.redirect('/');
        } catch (error) {
            console.log(error);
            res.render('login', { error });
        }
    });

router.route('/register')
    .get((req, res) => {

        res.render('register');
    })
    .post(async(req, res) => {
        if (req.body.password !== req.body.repeatPassword) {
            res.render(('register'), { error: { message: 'Both passwords should be the same' } });
            return;
        }
        if (await authService.duplicateUserNameFound(req.body.username)) {
            res.render(('register'), { error: { message: 'Already have user with that username' } });
            return;
        }

        try {
            await authService.registerUser(req.body, res);
            res.redirect('/');
        } catch (err) {
            // console.log(err);
            res.render('register');
        }
    });

router.route('/logout')
    .get((req, res) => {
        res.clearCookie('jwt');
        res.redirect('/');
    })

module.exports = router;