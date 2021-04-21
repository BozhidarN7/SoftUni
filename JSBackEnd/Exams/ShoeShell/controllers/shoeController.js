const express = require('express');

const shoeService = require('../services/shoeService');

const router = express.Router();

router.route('/')
    .get(async(req, res) => {
        if (!req.user) {
            res.render('home', { title: 'Shoe Shelf' });
        } else {
            const shoes = await shoeService.getShoes();
            res.render('shoes', { title: 'Shoe Shelf', shoes });
        }
    });

router.route('/create')
    .get((req, res) => {
        res.render('create', { title: 'Create Offer' });
    })
    .post((req, res) => {
        shoeService.createOffer(req)
            .then(response => res.redirect('/'))
            .catch(err => console.log(err));
    });

router.route('/:shoeId/details')
    .get(async(req, res) => {
        const shoe = await shoeService.findOne(req.params.shoeId, req.user.id);
        res.render('details', { title: `${shoe.name} Info`, shoe })
    });

router.route('/:shoeId/edit')
    .get((req, res) => {
        shoeService.getOne(req.params.shoeId)
            .then(shoe => res.render('edit', { title: `Edit ${shoe.name}`, shoe }))
    })
    .post((req, res) => {
        shoeService.editShoeOffer(req.body, req.params.shoeId)
            .then(response => res.redirect(`/${req.params.shoeId}/details`))
            .catch(err => console.log(err));
    })

router.route('/:shoeId/buy')
    .get((req, res) => {
        shoeService.buyOne(req.params.shoeId, req.user.id)
            .then(() => res.redirect(`/${req.params.shoeId}/details`));
    });

router.route('/:shoeId/delete')
    .get((req, res) => {
        shoeService.deleteShoeOffer(req.params.shoeId)
            .then(response => res.redirect('/'))
            .catch(err => console.log(err));
    });

module.exports = router;