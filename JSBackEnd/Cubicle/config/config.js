const config = {
    development: {
        PORT: 3000,
        SALT_ROUNDS: 10,
        SECRET: 'The most secret mega secret secret in the whole world',
    },
    production: {
        PORT: 80,
        SALT_ROUNDS: 10,
        SECRET: 'The most secret mega secret secret in the whole world',
    }
}

module.exports = config[process.env.NODE_ENV.trim()];