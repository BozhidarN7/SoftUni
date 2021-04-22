const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');

const Uesr = require('../models/userModel');
const config = require('../config/config');
const User = require('../models/userModel');

const signToken = id => {
    return jwt.sign({ id }, config.SECRET, { expiresIn: `${config.JWT_EXPIRES_IN}d` });
};

const createSendToken = (user, res) => {
    const token = signToken(user._id);
    res.cookie('jwt', token, {
        expires: new Date(Date.now() + config.JWT_EXPIRES_IN * 24 * 60 * 60 * 1000),
        httpOnly: true,
    });
};

exports.register = async(data, res) => {
    const salt = await bcrypt.genSalt(config.SALT);
    const hash = await bcrypt.hash(data.password, salt);
    data.password = hash;
    const user = await User.create(data);
    createSendToken(user, res);
};