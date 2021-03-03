const express = require('express');

const accessoryService = require('../services/accessoryService');

const router = new express.Router();

router.route('/create')
    .get((req, res) => {
        res.render('createAccessory', { title: 'Accessories' });
    })
    .post((req, res) => {
        // TODO: Validate req.body
        accessoryService.createAccessory(req.body).then(() => res.redirect('/')).catch(() => res.status(500).end());
        res.redirect('/');
    });

module.exports = router;