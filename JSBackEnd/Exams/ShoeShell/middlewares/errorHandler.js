const mongoose = require("mongoose");

module.exports = (err, req, res, next) => {
    err.message = err.message || 'Something went wrong';
    err.status = err.status || 500;

    console.log(err);

    res.status(err.status).render('register', { title: 'Register', error: err });

}