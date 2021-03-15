const { Router } = require('express');

const productService = require('../services/productService');
const accessoryService = require('../services/accessoryService');
const isAuthenticated = require('../middlewares/isAuthenticated');
const isGuest = require('../middlewares/isGuests');
const router = Router();

router.get('/', async(req, res) => {
    const products = await productService.getAll(req.query);
    res.render('home', { title: 'Browse', products });
});

router.route('/create')
    .get(isAuthenticated, (req, res) => {
        res.render('create', { title: 'Create' });
    })
    .post(isAuthenticated, (req, res) => {
        //TODO: Validate inputs
        productService.createProduct(req.body, req.user._id).then(() => res.redirect('/')).catch(() => res.status(500).end());
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
    .get(isAuthenticated, async(req, res) => {
        const product = await productService.getOne(req.params.productId);
        const accessories = await accessoryService.getAllUnattached(product.accessories);
        res.render('attachAccessory', { title: 'Attach accessory', product, accessories });
    })
    .post(isAuthenticated, (req, res) => {
        productService.attachAccessory(req.params.productId, req.body.accessory)
            .then(() => res.redirect(`/details/${req.params.productId}`));
    });

router.route('/:productId/edit')
    .get(isAuthenticated, (req, res) => {
        productService.getOne(req.params.productId)
            .then(product => {
                res.render('editCube', { title: 'Edit cube', product });
            })
    })
    .post(isAuthenticated, (req, res) => {
        productService.updateOne(req.params.productId, req.body)
            .then(response => {
                res.redirect(`/details/${req.params.productId}`);
            })
            .catch(err => {
                console.log(err);
            });
    });

router.route('/:productId/delete')
    .get(isAuthenticated, (req, res) => {
        productService.getOne(req.params.productId)
            .then(product => {
                if (req.user._id !== product.creator) {
                    res.redirect('/');
                } else {
                    res.render('deleteCube', { title: 'Delete cube', product });
                }
            });
    })
    .post(isAuthenticated, (req, res) => {
        productService.deleteOne(req.params.productId)
            .then(response => res.redirect('/'));
    });

module.exports = router;