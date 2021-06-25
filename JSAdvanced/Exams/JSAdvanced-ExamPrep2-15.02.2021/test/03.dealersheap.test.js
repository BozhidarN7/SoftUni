const { assert, expect } = require('chai');
const dealership = require('../03.dealersheap');

describe('Test dealership object functionality', () => {
    describe('Test newCarCost function', () => {
        it('Should return deducted price', () => {
            assert.equal(dealership.newCarCost('Audi A4 B8', 20000), 5000);
            assert.equal(dealership.newCarCost('Audi A8 D5', 10000), -15000);
            assert.equal(
                dealership.newCarCost('Audi TT 8J', 14001.1),
                1.1000000000003638
            );
        });
        it('Should return non deducted price', () => {
            assert.equal(dealership.newCarCost('Audi A4 B1', 20000), 20000);
            assert.equal(dealership.newCarCost('Au', 10000), 10000);
            assert.equal(dealership.newCarCost('', 14001.1), 14001.1);
        });
    });

    describe('Test carEquipment function', () => {
        it('Should return the desired extras', () => {
            expect(
                dealership.carEquipment(
                    [
                        'sport rims',
                        'navigation',
                        'heated seats',
                        'sliding roof',
                    ],
                    [0, 1, 3]
                )
            ).to.have.same.members([
                'sport rims',
                'navigation',
                'sliding roof',
            ]);

            expect(
                dealership.carEquipment(
                    [
                        'sport rims',
                        'navigation',
                        'heated seats',
                        'sliding roof',
                    ],
                    [2]
                )
            ).to.have.same.members(['heated seats']);

            expect(
                dealership.carEquipment([1, 2, 3, 4, 5], [0, 1, 3])
            ).to.have.same.members([1, 2, 4]);
            expect(
                dealership.carEquipment([1, 2, 3, -4, -5], [3, 4])
            ).to.have.same.members([-4, -5]);

            expect(
                dealership.carEquipment([1, 2, 3, 4, 5], [0, 1, 3])
            ).to.have.same.members([1, 2, 4]);
            expect(
                dealership.carEquipment(['test', 2.2], [1, 0])
            ).to.have.same.members([2.2, 'test']);
        });
    });
    describe('Test euroCategory function', () => {
        it('Should return emssage when the category is low', () => {
            assert.equal(
                dealership.euroCategory(3),
                'Your euro category is low, so there is no discount from the final price!'
            );
            assert.equal(
                dealership.euroCategory(2),
                'Your euro category is low, so there is no discount from the final price!'
            );
            assert.equal(
                dealership.euroCategory(-33),
                'Your euro category is low, so there is no discount from the final price!'
            );
            assert.equal(
                dealership.euroCategory(3.9),
                'Your euro category is low, so there is no discount from the final price!'
            );
        });
        it('Should return message when the category is not low', () => {
            assert.equal(
                dealership.euroCategory(4),
                'We have added 5% discount to the final price: 14250.'
            );
            assert.equal(
                dealership.euroCategory(5),
                'We have added 5% discount to the final price: 14250.'
            );
            assert.equal(
                dealership.euroCategory(4.1),
                'We have added 5% discount to the final price: 14250.'
            );
        });
    });
});
