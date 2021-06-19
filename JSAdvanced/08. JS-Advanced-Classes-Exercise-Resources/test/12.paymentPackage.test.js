const { assert, expect } = require('chai');
const PaymentPackage = require('../12.paymentPackage');

describe('Test PaymentPackage class functionality', () => {
    describe('Constructor tests', () => {
        it('Should throw exception if name is invalid', () => {
            assert.throws(() => new PaymentPackage('', 12), Error);
            assert.throws(() => new PaymentPackage(12, 12), Error);
            assert.throws(() => new PaymentPackage({}, 12), Error);
            assert.throws(() => new PaymentPackage(null, 12), Error);
        });
        it('Should throw exception if value is invalid', () => {
            assert.throws(() => new PaymentPackage('Test', null), Error);
            assert.throws(() => new PaymentPackage('Test', 'asdf'), Error);
            assert.throws(() => new PaymentPackage('Test', []), Error);
            assert.throws(() => new PaymentPackage('Test', -12), Error);
        });
        it('Should initialize name field', () => {
            assert.equal(new PaymentPackage('Test', 12).name, 'Test');
            assert.equal(new PaymentPackage('  ', 12).name, '  ');
        });
        it('Should initialize value filed', () => {
            assert.equal(new PaymentPackage('Test', 12).value, 12);
            assert.equal(new PaymentPackage('Test', 12.2).value, 12.2);
            assert.equal(new PaymentPackage('Test', 0).value, 0);
        });
        it('Should initialize VAT field', () => {
            assert.equal(new PaymentPackage('Test', 12).VAT, 20);
        });
        it('Should initialize active filed', () => {
            assert.equal(new PaymentPackage('Test', 12).active, true);
        });
    });
    describe('VAT set propert tests', () => {
        it('Should throw exception if VAt is invalid', () => {
            const paymentPackage = new PaymentPackage('Test', 12);
            assert.throws(() => (paymentPackage.VAT = 'a'), Error);
            assert.throws(() => (paymentPackage.VAT = -12), Error);
            assert.throws(() => (paymentPackage.VAT = null), Error);
        });
        it('Should change VAT default value', () => {
            const paymentPackage = new PaymentPackage('Test', 12);
            paymentPackage.VAT = 25;
            assert.equal(paymentPackage.VAT, 25);

            paymentPackage.VAT = 25.5;
            assert.equal(paymentPackage.VAT, 25.5);

            paymentPackage.VAT = 0;
            assert.equal(paymentPackage.VAT, 0);
        });
    });
    describe('Active set propert tests', () => {
        it('Should throw exception if active is invalid', () => {
            const paymentPackage = new PaymentPackage('Test', 12);
            assert.throws(() => (paymentPackage.active = 'a'), Error);
            assert.throws(() => (paymentPackage.VAT = -12), Error);
            assert.throws(() => (paymentPackage.VAT = null), Error);
        });
        it('Should change active default value', () => {
            const paymentPackage = new PaymentPackage('Test', 12);
            paymentPackage.active = false;
            assert.equal(paymentPackage.active, false);
        });
    });
    describe('toString method tests', () => {
        it('Should return correct message', () => {
            const paymentPackage = new PaymentPackage('Test', 12);
            const expected =
                'Package: Test\n- Value (excl. VAT): 12\n- Value (VAT 20%): 14.399999999999999';
            assert.equal(paymentPackage.toString(), expected);
        });
        it('Should return correct message', () => {
            const paymentPackage = new PaymentPackage('Test', 12);
            paymentPackage.active = false;
            const expected =
                'Package: Test (inactive)\n- Value (excl. VAT): 12\n- Value (VAT 20%): 14.399999999999999';
            assert.equal(paymentPackage.toString(), expected);
        });
    });
});
