const { assert, expect } = require('chai');
const testNumbers = require('../03.testNumbers');

describe('Tet testNumber object', () => {
    describe('Test sumNumber function', () => {
        it('Should return undefined if arguments are not numbers', () => {
            assert.equal(testNumbers.sumNumbers(2, '2'), undefined);
            assert.equal(testNumbers.sumNumbers('234', 2), undefined);
            assert.equal(testNumbers.sumNumbers('234', '324.2342'), undefined);
            assert.equal(testNumbers.sumNumbers({}, 32), undefined);
            assert.equal(testNumbers.sumNumbers([], 32), undefined);
        });
        it('Should return the sum of the two numbers', () => {
            assert.equal(testNumbers.sumNumbers(2, 2), 4);
            assert.equal(testNumbers.sumNumbers(20, -2), 18);
            assert.equal(testNumbers.sumNumbers(0, 0), 0);
            assert.equal(testNumbers.sumNumbers(-11, -12), -23);
            assert.equal(testNumbers.sumNumbers(2.2, 2), (2.2 + 2).toFixed(2));
            assert.equal(
                testNumbers.sumNumbers(-2.2, 2),
                (-2.2 + 2).toFixed(2)
            );
        });
    });
    describe('Test numberCheck function', () => {
        it('Should throw error if input is not a number', () => {
            assert.throws(
                () => testNumbers.numberChecker(undefined),
                Error,
                'The input is not a number!'
            );
            assert.throws(
                () => testNumbers.numberChecker({}),
                Error,
                'The input is not a number!'
            );
            assert.throws(
                () => testNumbers.numberChecker(function () {}),
                Error,
                'The input is not a number!'
            );
            assert.throws(
                () => testNumbers.numberChecker(NaN),
                Error,
                'The input is not a number!'
            );
        });
        it('Should return whether is odd or even', () => {
            assert.equal(testNumbers.numberChecker([]), 'The number is even!');
            assert.equal(
                testNumbers.numberChecker(null),
                'The number is even!'
            );
            assert.equal(testNumbers.numberChecker(''), 'The number is even!');
            assert.equal(testNumbers.numberChecker(2), 'The number is even!');
            assert.equal(testNumbers.numberChecker(333), 'The number is odd!');
            assert.equal(testNumbers.numberChecker(3), 'The number is odd!');
            assert.equal(testNumbers.numberChecker(-3), 'The number is odd!');
            assert.equal(testNumbers.numberChecker(-2), 'The number is even!');
            assert.equal(testNumbers.numberChecker(-3.2), 'The number is odd!');
            assert.equal(testNumbers.numberChecker(2.2), 'The number is odd!');
        });
    });
    describe('Test averageSumArray function', () => {
        it('Should return the average sum of arr', () => {
            assert.equal(testNumbers.averageSumArray([1, 2, 3]), 6 / 3);
            assert.equal(testNumbers.averageSumArray([1, 2, 4]), 7 / 3);
            // assert.equal(testNumbers.averageSumArray(['', 2, 4]), '-8');

            assert.equal(
                testNumbers.averageSumArray([-1, -2, 4, 7, 5]),
                13 / 5
            );
            assert.equal(
                testNumbers.averageSumArray([2.2, 0.5, -0.3, -12, 6]),
                -3.6 / 5
            );
        });
    });
});
