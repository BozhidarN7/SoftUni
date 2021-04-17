const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');

const config = require('../config/config');
const User = require('../models/userModel');

const signToken = function(id, username) {
    return jwt.sign({ id, username }, config.SECRET, { expiresIn: `${config.JWT_EXPIRES_IN}d` });
}

const createSendToken = function(user, res) {
    const token = signToken(user._id, user.username);
    res.cookie('jwt', token, {
        expires: new Date(Date.now() + config.JWT_EXPIRES_IN * 24 * 60 * 60 * 1000),
        httpOnly: true,
    });
}

exports.register = async(data, res) => {
    const salt = await bcrypt.genSalt(config.SALT);
    const hash = await bcrypt.hash(data.password, salt);
    data.password = hash;
    const user = await User.create(data);
    createSendToken(user, res);
}