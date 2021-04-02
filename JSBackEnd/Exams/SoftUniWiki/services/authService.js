const mongoose = require('mongoose');
const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');

const config = require('../config/config');
const User = require('../models/user');

const signToken = id => {
    return jwt.signToken({ id }, config.JWT_SECRET, { expiresIn: `${config.JWT_EXPIRES_IN}d` });
}

exports.registerUser = async({ username, password }) => {
    const salt = await bcrypt.genSalt(config.SALT_ROUNDS);
    const hash = await bcrypt.hash(password, salt);
    return User.create({ username, password: hash });

};

exports.duplicateUserNameFound = async(username) => {
    const user = await User.findOne({ username });
    if (user) {
        return 1;
    }
    return 0;
};

exports.login = async({ username, password }) => {
    const user = await User.findOne({ username });
    if (!user) throw { message: 'Incorrect username or password' };

    const isMatch = await bcrypt.compare(password, user.password);
    if (!isMatch) throw { message: 'Incorrect username or password' };
};