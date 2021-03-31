const express = require('express');
const handlebars = require('express-handlebars');

const app = new express();

module.exports = (app) => {
    app.engine('hbs', handlebars({
        extname: 'hbs'
    }));
    app.set('view engine', 'hbs');
    app.use(express.static('public'));
    app.use(express.urlencoded({ extended: true }));
};