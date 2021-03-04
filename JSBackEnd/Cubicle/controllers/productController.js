const { Router } = require('express');

const productService = require('../services/productService');
const accessoryService = require('../services/accessoryService');
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
    const product = await productService.getOneWithAccessories(req.params.productId);
    res.render('details', { title: 'Product Details', product });
});

router.route('/:productId/attach')
    .get(async(req, res) => {
        const product = await productService.getOne(req.params.productId);
        const accessories = await accessoryService.getAllUnattached(product.accessories);
        res.render('attachAccessory', { title: 'Attach accessory', product, accessories });
    })
    .post((req, res) => {
        productService.attachAccessory(req.params.productId, req.body.accessory)
            .then(() => res.redirect(`/details/${req.params.productId}`));
    });

module.exports = router;