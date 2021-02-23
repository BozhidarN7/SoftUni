const express = require('express');

const productController = require('./controllers/productController');

const router = express.Router();

router.use(productController);

module.exports = router;