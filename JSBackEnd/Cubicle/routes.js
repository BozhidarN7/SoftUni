const express = require('express');

const productController = require('./controllers/productController');
const aboutController = require('./controllers/aboutController');
const accessoryController = require('./controllers/accessoryController');
const authController = require('./controllers/authController');
const isAuthenticated = require('./middlewares/isAuthenticated');
const isGuest = require('./middlewares/isGuests');
const router = express.Router();

router.use('/', productController);
router.use('/auth', authController);
router.use('/about', aboutController);
router.use('/accessories', accessoryController);
router.get('*', (req, res) => {
    res.render('404');
})

module.exports = router;