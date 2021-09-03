const express = require('express');

const authController = require('./controllers/authController');
const bookingController = require('./controllers/bookingController');

const router = express.Router();

router.use('/', bookingController);
router.use('/auth', authController);

module.exports = router;
