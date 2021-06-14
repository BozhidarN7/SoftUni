const { assert, expect } = require('chai');
const createCalculator = require('../07.addSubtract');

describe('Test createCalculator function functionality', () => {
    it('Should check if returned valu is object', () => {
        assert.equal('object', typeof createCalculator());
    });
    it('Should check if returned object contains add', () => {
        const obj = createCalculator();
        assert.equal(obj.hasOwnProperty('add'), true);
    });
    it('Should check if returned object contains subtract', () => {
        const obj = createCalculator();
        assert.equal(obj.hasOwnProperty('subtract'), true);
    });
    it('Should check if returned object contains get', () => {
        const obj = createCalculator();
        assert.equal(obj.hasOwnProperty('get'), true);
    });
    it('Should not allow to modified the internal sum', () => {
        const obj = createCalculator();
        let sum = obj.get();
        sum += 5;

        assert.notEqual(sum, obj.get());
    });
    it('Should not allow to modified the internal sum', () => {
        const obj = createCalculator();

        assert.equal(obj.value, undefined);
    });
    it('Should add number to the inner state variable', () => {
        const numberToAdd = 5;
        const obj = createCalculator();
        obj.add(numberToAdd);

        assert.equal(5, obj.get());
    });
    it(`add method adds parsable input`, () => {
        const calc = createCalculator();
        calc.add('1');
        expect(calc.get()).to.equals(1);
    });
    it(`subtract method subtracts parsable input`, () => {
        const calc = createCalculator();
        calc.add('2');
        calc.subtract('1');
        expect(calc.get()).to.equals(1);
    });
});
