const jwt = require('jsonwebtoken');

const config = require('../config/config');

module.exports = function() {
    return (req, res, next) => {
        const token = req.cookies['USER_SESSION'];
        if (token) {
            const userId = jwt.verify(token, config.SECRET, (err, decoded) => {
                if (err) {
                    res.clearCookie('USER_SESSION');
                    console.log(err);
                } else {
                    req.user = decoded;
                    res.locals.user = decoded;
                    res.locals.isAuthenticated = true;
                }
            });
        }
        next();
    }
}