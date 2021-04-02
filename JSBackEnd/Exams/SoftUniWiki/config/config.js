const config = {
    development: {
        PORT: 3000,
        SALT_ROUNDS: 12,
        JWT_SECRET: 'This is my very very stong powerful ultimate secure secret',
        JWT_EXPIRES_IN: 90
    },
    production: {
        PORR: 80
    }
}

module.exports = config.development;