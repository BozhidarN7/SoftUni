const { assert } = require('chai');
const lookupChar = require('../03.charLookup');

describe('Test lookupChar function', () => {
    it('Should return undefined if first argument is not a string', () => {
        assert.equal(undefined, lookupChar(5, 5));
        assert.equal(undefined, lookupChar({}, 5));
        assert.equal(undefined, lookupChar([], 5));
    });
    it('Should return undefined if second argument is not a integer', () => {
        assert.equal(undefined, lookupChar('test', 'test'));
        assert.equal(undefined, lookupChar('test', 2.5));
        assert.equal(undefined, lookupChar('test', {}));
        assert.equal(undefined, lookupChar('test', []));
    });
    it('Should return undefined if both arguments are not string and interger respectively', () => {
        assert.equal(undefined, lookupChar([], []));
        assert.equal(undefined, lookupChar([], {}));
        assert.equal(undefined, lookupChar(5, '5'));
    });
    it('Should return error message if index is not in bounds', () => {
        assert.equal('Incorrect index', lookupChar('test', -1));
        assert.equal('Incorrect index', lookupChar('test', 10));
        assert.equal('Incorrect index', lookupChar('', 0));
    });
    it('Should return char at the given index', () => {
        assert.equal('t', lookupChar('test', 0));
        assert.equal('e', lookupChar('test', 1));
        assert.equal('s', lookupChar('test', 2));
    });
});
