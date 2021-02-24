const express = require('express');

const productController = require('./controllers/productController');
const aboutController = require('./controllers/aboutController');
const router = express.Router();

router.use('/', productController);
router.use('/about', aboutController);
router.get('*', (reqr, res) => {
    res.render('404');
})

module.exports = router;