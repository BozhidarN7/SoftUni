const express = require('express');

const accessoryService = require('../services/accessoryService');
const isAuthenticated = require('../middlewares/isAuthenticated');
const isGuest = require('../middlewares/isGuests');
const router = new express.Router();

router.route('/create')
    .get(isAuthenticated, (req, res) => {
        res.render('createAccessory', { title: 'Accessories' });
    })
    .post(isAuthenticated, (req, res) => {
        // TODO: Validate req.body
        accessoryService.createAccessory(req.body).then(() => res.redirect('/')).catch(() => res.status(500).end());
        res.redirect('/');
    });

module.exports = router;