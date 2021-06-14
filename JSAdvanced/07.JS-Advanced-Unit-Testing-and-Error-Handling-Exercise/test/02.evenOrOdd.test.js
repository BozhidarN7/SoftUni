const { assert } = require('chai');
const isOddOrEven = require('../02.evenOrOdd');

describe('Test isOddOrEven function', () => {
    it('Should return undefined if string is not passed', () => {
        assert.equal(undefined, isOddOrEven(5));
        assert.equal(undefined, isOddOrEven({}));
        assert.equal(undefined, isOddOrEven([]));
    });
    it('Should return even if length of string is even', () => {
        assert.equal('even', isOddOrEven('even'));
    });
    it('Should return odd if length of string is odd', () => {
        assert.equal('odd', isOddOrEven('odd'));
    });
});
