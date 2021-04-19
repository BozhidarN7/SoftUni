const jwt = require('jsonwebtoken');

const { SECRET } = require('../config/config');

module.exports = function() {
    return (req, res, next) => {
        const token = req.cookies['jwt'];
        if (token) {
            jwt.verify(token, SECRET, (err, decoded) => {
                if (err) {
                    res.clearCookie('jwt');
                    console.log(err);
                } else {
                    req.user = decoded;
                    res.locals.user = decoded;
                    res.locals.isAuthenticated = true;
                }
            })
        }
        next();
    }
}