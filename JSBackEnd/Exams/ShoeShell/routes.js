const express = require('express');

const shoeController = require('./controllers/shoeController');
const authController = require('./controllers/authController');

const router = express.Router();

router.use('/', shoeController);
router.use('/auth', authController);

module.exports = router;