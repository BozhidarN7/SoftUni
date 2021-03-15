const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');

const User = require('../models/user');
const config = require('../config/config');

const registerUser = async({ username, password }) => {
    const salt = await bcrypt.genSalt(config.SALT_ROUNDS);
    const hash = await bcrypt.hash(password, salt);
    const user = new User({ username, password: hash });
    return user.save();
};

const login = async({ username, password }) => {
    const user = await User.findOne({ username })
    if (!user) throw { message: 'Incorrect username or password' };

    const isMatch = await bcrypt.compare(password, user.password);
    if (!isMatch) throw { message: 'Incorrect username or password' }

    const token = jwt.sign({ _id: user._id, roles: ['admin'] }, config.SECRET);
    return token;
}

module.exports = {
    registerUser,
    login,
}