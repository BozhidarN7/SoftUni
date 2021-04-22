const config = {
    development: {
        PORT: 3000,
        SALT: 12,
        SECRET: 'Very power strong amazing unhackable longest strong secret',
        JWT_EXPIRES_IN: 90
    }
}

module.exports = config.development;