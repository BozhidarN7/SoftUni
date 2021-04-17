const express = require('express');

const shoeController = require('./controllers/shoeController');

const router = express.Router();

router.use('/', shoeController);

module.exports = router;