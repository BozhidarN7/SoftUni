const { assert } = require('chai');
const mathEnforcer = require('../04.mathEnforcer');

describe('Test mathEnforcer object', () => {
    describe('Test addFive function', () => {
        it('Should return undefined if not a number is passed', () => {
            assert.equal(undefined, mathEnforcer.addFive({}));
            assert.equal(undefined, mathEnforcer.addFive([]));
            assert.equal(undefined, mathEnforcer.addFive('f'));
        });
        it('Should add 5 to argument positive number', () => {
            assert.equal(10, mathEnforcer.addFive(5));
        });
        it('Should add 5 to argument negative number', () => {
            assert.equal(-5, mathEnforcer.addFive(-10));
        });
        it('Should add 5 to argument floating point number', () => {
            assert.closeTo(
                10.56,
                mathEnforcer.addFive(5.5678),
                0.01,
                'numbers are close'
            );
        });
    });
    describe('Test subtraction function', () => {
        it('Should return undefined if not a number is passed', () => {
            assert.equal(undefined, mathEnforcer.subtractTen({}));
            assert.equal(undefined, mathEnforcer.subtractTen([]));
            assert.equal(undefined, mathEnforcer.subtractTen('f'));
        });
        it('Should subtract 10 from passed argument positive number', () => {
            assert.equal(5, mathEnforcer.subtractTen(15));
        });
        it('Should subtract 10 from passed argument negative number', () => {
            assert.equal(-25, mathEnforcer.subtractTen(-15));
        });
        it('Should subtract 10 from passed argument floating point number', () => {
            assert.closeTo(5.56, mathEnforcer.subtractTen(15.5678), 0.01);
            assert.closeTo(-25.56, mathEnforcer.subtractTen(-15.5678), 0.01);
        });
    });
    describe('Test sum function', () => {
        it('Should return undefined if arguments are not numbers', () => {
            assert.equal(undefined, mathEnforcer.sum('a', 5));
            assert.equal(undefined, mathEnforcer.sum(1, '5'));
            assert.equal(undefined, mathEnforcer.sum({}, {}));
        });
        it('Should add the passed numbers positive', () => {
            assert.equal(15, mathEnforcer.sum(7, 8));
        });
        it('Should add the passed numbers negative', () => {
            assert.equal(-1, mathEnforcer.sum(7, -8));
        });
        it('Should add the passed floating point', () => {
            assert.closeTo(15.567, mathEnforcer.sum(7.5678, 8), 0.01);
            assert.closeTo(0.43, mathEnforcer.sum(-7.5678, 8), 0.01);
            assert.closeTo(0.69, mathEnforcer.sum(0.1234, 0.5678), 0.01);
        });
    });
});
