const config = {
    development: {
        PORT: 3000,
        SALT: 12,
        SECRET: 'This is strongest ever human made super powerful strong strongs ecret in the whole world',
        JWT_EXPIRES_IN: 90
    }
}

module.exports = config.development;