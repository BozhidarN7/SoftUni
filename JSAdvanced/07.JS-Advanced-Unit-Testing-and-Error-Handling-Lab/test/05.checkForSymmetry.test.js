const { assert, expect } = require('chai');
const isSymmetric = require('../05.checkForSymmetry');

describe('Test isSymmetric function functionality', () => {
    it('Should accepts array as argument', () => {
        const input = 2;
        const expectedResult = false;

        const actualResult = isSymmetric(input);

        assert.equal(expectedResult, actualResult);
    });

    it('Should return true if array is symmetric', () => {
        const input = [1, 2, 1];
        const expectedResult = true;

        const actualREsult = isSymmetric(input);

        assert.equal(expectedResult, actualREsult);
    });
    it('Should return false if array is not symetric', () => {
        const input = [1, 2, 1, 1];
        const expectedResult = false;

        const actualREsult = isSymmetric(input);

        assert.equal(expectedResult, actualREsult);
    });
    it('Should fail', () => {
        expect(isSymmetric(['1', 1])).to.be.false;
    });
});
