const express = require('express');

const bookingController = require('./controllers/bookingController');
const authController = require('./controllers/authController');
const router = express.Router();

router.use('/', bookingController);
router.use('/auth', authController);

module.exports = router;