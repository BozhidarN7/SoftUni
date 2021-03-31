const mongoose = require('mongoose');
const bcrypt = require('bcrypt');

const config = require('../config/config');
const User = require('../models/user');

exports.registerUser = async({ username, password }) => {
    const salt = await bcrypt.genSalt(config.SALT_ROUNDS);
    const hash = await bcrypt.hash(password, salt);
    return User.create({ username, password: hash });

}