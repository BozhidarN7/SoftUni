const { assert } = require('chai');
const rgbToHexColor = require('../06.rgbToHex');

describe('Test rgbToHexColor function functionality', () => {
    it('Should return undefined if red is not a number', () => {
        assert.equal(undefined, rgbToHexColor('1', 23, 23));
    });
    it('Should return undefined if red is less than 0', () => {
        assert.equal(undefined, rgbToHexColor(-1, 23, 23));
    });
    it('Should return undefined if red is more than 255', () => {
        assert.equal(undefined, rgbToHexColor(333, 23, 23));
    });
    it('Should return undefined if green is not a number', () => {
        assert.equal(undefined, rgbToHexColor(23, '1', 23));
    });
    it('Should return undefined if green is less than 0', () => {
        assert.equal(undefined, rgbToHexColor(23, -1, 23));
    });
    it('Should return undefined if green is more than 255', () => {
        assert.equal(undefined, rgbToHexColor(33, 333, 23));
    });
    it('Should return undefined if blue is not a number', () => {
        assert.equal(undefined, rgbToHexColor(23, 2, '23'));
    });
    it('Should return undefined if blue is less than 0', () => {
        assert.equal(undefined, rgbToHexColor(23, 1, -23));
    });
    it('Should return undefined if blue is more than 255', () => {
        assert.equal(undefined, rgbToHexColor(33, 33, 323));
    });
    it('Should return rgb to hex', () => {
        assert.equal('#32A852', rgbToHexColor(50, 168, 82));
    });
    it('Should test lowest possible input: zeros', () => {
        assert.equal(rgbToHexColor(0, 0, 0), '#000000');
    });
    it('Should test highest possible input: 255', () => {
        assert.equal(rgbToHexColor(255, 255, 255), '#FFFFFF');
    });
});
