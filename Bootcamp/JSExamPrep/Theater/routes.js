const express = require('express');

const authController = require('./controllers/authController');
const theaterController = require('./controllers/theaterController');

const router = express.Router();

router.use('/', theaterController);
router.use('/auth', authController);

module.exports = router;
