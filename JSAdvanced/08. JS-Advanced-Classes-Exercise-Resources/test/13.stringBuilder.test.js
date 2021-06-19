const { assert, expect } = require('chai');
const StringBuilder = require('../13.stringBuilder');

describe('Tests StringBuilder class functionality', () => {
    describe('Tests constructor functionality', () => {
        it('Should throw error if argument is not a string', () => {
            assert.throws(() => new StringBuilder(12), TypeError);
            assert.throws(() => new StringBuilder(12.2), TypeError);
            assert.throws(() => new StringBuilder(null), TypeError);
            assert.throws(() => new StringBuilder({}), TypeError);
        });
        it('Should initialze empty string if undefined is passed ', () => {
            assert.equal(new StringBuilder(undefined), '');
        });
        it('Should initialze stringd', () => {
            assert.equal(new StringBuilder(''), '');
            assert.equal(new StringBuilder('  '), '  ');
            assert.equal(new StringBuilder('asdf'), 'asdf');
        });
    });
    describe('Tests append function', () => {
        it('Should throw exception if argument is not a string', () => {
            assert.throws(
                () => new StringBuilder('Ivan').append(undefined),
                TypeError
            );
            assert.throws(
                () => new StringBuilder('Ivan').append(12),
                TypeError
            );
            assert.throws(
                () => new StringBuilder('Ivan').append(null),
                TypeError
            );
        });
        it('Should add the given string to the end of the current', () => {
            const sb = new StringBuilder('Ivan');
            sb.append(' is cool');
            assert.equal(sb.toString(), 'Ivan is cool');
        });
        it('Should add the given string to the end of the current', () => {
            const sb = new StringBuilder('Ivan');
            sb.append('  ');
            assert.equal(sb.toString(), 'Ivan  ');
        });
    });
    describe('Tests prpend function', () => {
        it('Should throw exception if argument is not a string', () => {
            assert.throws(
                () => new StringBuilder('Ivan').prepend(undefined),
                TypeError
            );
            assert.throws(
                () => new StringBuilder('Ivan').prepend(12),
                TypeError
            );
            assert.throws(
                () => new StringBuilder('Ivan').prepend(null),
                TypeError
            );
        });
        it('Should add the given string to the beginning of the current', () => {
            const sb = new StringBuilder('Ivan');
            sb.prepend('is cool ');
            assert.equal(sb.toString(), 'is cool Ivan');
        });
        it('Should add the given string to the end of the current', () => {
            const sb = new StringBuilder('Ivan');
            sb.prepend('  ');
            assert.equal(sb.toString(), '  Ivan');
        });
    });
    describe('Tests insertAt function', () => {
        it('Should throw exception if argument is not a string', () => {
            assert.throws(
                () => new StringBuilder('Ivan').inserAt(undefined, 2),
                TypeError
            );
            assert.throws(
                () => new StringBuilder('Ivan').insertAt(12, 2),
                TypeError
            );
            assert.throws(
                () => new StringBuilder('Ivan').insertAt(null, 2),
                TypeError
            );
        });
        it('Should add the given string at the specified index', () => {
            const sb = new StringBuilder('Ivan');
            sb.insertAt('K.', 0);
            assert.equal(sb.toString(), 'K.Ivan');

            sb.insertAt(' is a programmer', 6);
            assert.equal(sb.toString(), 'K.Ivan is a programmer');

            sb.insertAt('  ', 6);
            assert.equal(sb.toString(), 'K.Ivan   is a programmer');
        });
    });
    describe('Tests remove function', () => {
        it('Should remove the part', () => {
            const sb = new StringBuilder('Ivan');
            sb.insertAt('K.', 0);
            assert.equal(sb.toString(), 'K.Ivan');

            sb.remove(0, 2);
            assert.equal(sb.toString(), 'Ivan');

            sb.remove(3, 1);
            assert.equal(sb.toString(), 'Iva');

            sb.remove(1, 1);
            assert.equal(sb.toString(), 'Ia');
        });
    });
});
