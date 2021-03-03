const { Router } = require('express');

const productService = require('../services/productService');
const Cube = require('../models/cube');
const router = Router();

router.get('/', async(req, res) => {
    const products = await productService.getAll(req.query);
    res.render('home', { title: 'Browse', products });
});

router.route('/create')
    .get((req, res) => {
        res.render('create', { title: 'Create' });
    })
    .post((req, res) => {
        //TODO: Validate inputs
        productService.createProduct(req.body).then(() => res.redirect('/')).catch(() => res.status(500).end());
    });

router.route('/create/accessory')
    .get((req, res) => {
        res.render('createAccessory', { title: 'Create Accessory' });
    })
    .post((req, res) => {
        // TODO
        res.send('Not implemented yet.');
    });

router.get('/details/:productId', async(req, res) => {
    const product = await productService.getOne(req.params.productId);
    res.render('details', { title: 'Product Details', product });
})

module.exports = router;