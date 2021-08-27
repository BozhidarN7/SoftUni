const config = {
    development: {
        PORT: 3000,
        SALT_ROUNDS: 12,
        JWT_SECRET:
            'This is my very very strong powerful ultimate secure secret',
        JWT_EXPIRES_IN: 90,
    },
};

module.exports = config.development;
