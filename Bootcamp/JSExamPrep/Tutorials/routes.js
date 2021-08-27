const express = require('express');

const authController = require('./controllers/authController');
const tutorialController = require('./controllers/tutorialController.js');

const router = express.Router();

router.use('/', tutorialController);
router.use('/auth', authController);

module.exports = router;
