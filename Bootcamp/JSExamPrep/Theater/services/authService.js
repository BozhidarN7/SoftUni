const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');

const config = require('../config/config');
const User = require('../models/userModel.js');

const signToken = function (id, username) {
    return jwt.sign({ id, username }, config.JWT_SECRET, {
        expiresIn: `${config.JWT_EXPIRES_IN}d`,
    });
};

const createSendToken = function (user, res) {
    const token = signToken(user._id, user.username);
    res.cookie('jwt', token, {
        expires: new Date(
            Date.now() + config.JWT_EXPIRES_IN * 24 * 60 * 60 * 1000
        ),
        httpOnly: true,
    });
};

exports.register = async (data, res) => {
    try {
        if (!isPasswordValid(data.password)) {
            throw new Error('Invalid Password!');
        }
        const salt = await bcrypt.genSalt(config.SALT_ROUNDS);
        const hash = await bcrypt.hash(data.password, salt);

        if (data.password !== data.rePassword) {
            throw new Error('Password mismatch!');
        }

        const user = await User.create({
            username: data.username,
            password: hash,
        });
        createSendToken(user, res);
    } catch (err) {
        console.log(err);
        throw err;
    }
};

exports.login = async ({ username, password }, res) => {
    try {
        const user = await User.findOne({ username });
        if (!user) throw new Error('Incorrect username or password');

        const isMatch = await bcrypt.compare(password, user.password);
        if (!isMatch) throw new Error('Incorrect username or password');

        createSendToken(user, res);
    } catch (err) {
        throw err;
    }
};

function isPasswordValid(password) {
    return password.length > 3 && /^[A-Za-z0-9]{3,}$/.test(password);
}
