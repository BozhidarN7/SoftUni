const express = require('express');

const theatreController = require('./controllers/theatreController');
const authController = require('./controllers/authController');
const router = express.Router();

router.use('/', theatreController);
router.use('/auth', authController)

module.exports = router;