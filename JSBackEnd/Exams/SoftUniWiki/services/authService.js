const mongoose = require('mongoose');
const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');

const config = require('../config/config');
const User = require('../models/user');

const signToken = id => {
    return jwt.sign({ id }, config.JWT_SECRET, { expiresIn: `${config.JWT_EXPIRES_IN}d` });
};

const createSendToken = function(user, res) {
    const token = signToken(user._id);

    res.cookie('jwt', token, {
        expires: new Date(Date.now() + config.JWT_EXPIRES_IN * 24 * 60 * 60 * 1000),
        httpOnly: true,
    });
};

exports.registerUser = async({ username, password }, res) => {
    const salt = await bcrypt.genSalt(config.SALT_ROUNDS);
    const hash = await bcrypt.hash(password, salt);
    const user = await User.create({ username, password: hash });
    createSendToken(user, res);

};

exports.duplicateUserNameFound = async(username) => {
    const user = await User.findOne({ username });
    if (user) {
        return 1;
    }
    return 0;
};

exports.login = async({ username, password }, res) => {
    const user = await User.findOne({ username });
    if (!user) throw { message: 'Incorrect username or password' };

    const isMatch = await bcrypt.compare(password, user.password);
    if (!isMatch) throw { message: 'Incorrect username or password' };
    createSendToken(user, res);
};