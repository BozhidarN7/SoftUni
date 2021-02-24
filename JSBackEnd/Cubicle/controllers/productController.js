const { Router } = require('express');

const productService = require('../services/productService');

const router = Router();

router.get('/', (req, res) => {
    const products = productService.getAll(req.query);
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

router.get('/details/:productId', (req, res) => {
    const product = productService.getOne(req.params.productId);
    res.render('details', { title: 'Product Details', product });
})

module.exports = router;