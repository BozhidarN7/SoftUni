const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');

const config = require('../config/config');
const User = require('../models/userModel');

const signToken = function(id, username) {
    return jwt.sign({ id, username }, config.JWT_SECRET, { expiresIn: `${config.JWT_EXPIRES_IN}d` });
}

const createSendToken = function(user, res) {
    const token = signToken(user._id, user.username);
    res.cookie('jwt', token, {
        expires: new Date(Date.now() + config.JWT_EXPIRES_IN * 24 * 60 * 60 * 1000),
        httpOnly: true,
    });
}

exports.register = async(data, res) => {
    const salt = await bcrypt.genSalt(config.SALT_ROUNDS);
    const hash = await bcrypt.hash(data.password, salt);
    const user = await User.create({
        email: data.email,
        username: data.username,
        password: hash,
    });
    createSendToken(user, res);
};

exports.login = async({ username, password }, res) => {
    const user = await User.findOne({ username });
    if (!user) throw { message: 'Incorrect username or password' };

    const isMatch = await bcrypt.compare(password, user.password);
    if (!isMatch) throw { message: 'Incorrect username or password' };
    createSendToken(user, res);
}