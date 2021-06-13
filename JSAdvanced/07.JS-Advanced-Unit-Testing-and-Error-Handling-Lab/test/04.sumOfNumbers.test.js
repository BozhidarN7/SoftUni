const { assert } = require('chai');
const sum = require('../04.sumOfNumbers');

describe('Test sum functionality', () => {
    it('Should add positive numbers', () => {
        const input = [1, 2, 3, 4, 5];
        const expectedSum = 15;

        const actualSum = sum(input);

        assert.equal(expectedSum, actualSum);
    });
});
