const express = require('express');

const articleController = require('./controllers/articleController');
const authController = require('./controllers/authController.js');

const router = express.Router();

router.use('/', articleController);
router.use('/auth', authController);

module.exports = router;