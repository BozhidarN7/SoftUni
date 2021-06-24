const { assert, expect } = require('chai');
const pizzUni = require('../03.pizzaPlace');

describe('Test pizzUnit obj functionality', () => {
    describe('Test makeOrder function', () => {
        it('Should throw error if there is no ordered pizza', () => {
            assert.throws(() =>
                pizzUni.makeAnOrder({ test: 'test', orderedDrink: 'drink' })
            );
            assert.throws(() =>
                pizzUni.makeAnOrder({
                    noPizza: 'noPizza',
                    noDrink: 'drink',
                })
            );
        });
        it('Should return informartion only for the pizza if there is no drink', () => {
            const expected = 'You just ordered VeganPizza';
            assert.equal(
                pizzUni.makeAnOrder({
                    orderedPizza: 'VeganPizza',
                    drink: 'noDrink',
                }),
                expected
            );
        });
        it('Should return informartion for the pizza and the drink', () => {
            const expected = 'You just ordered VeganPizza and Water.';
            assert.equal(
                pizzUni.makeAnOrder({
                    orderedPizza: 'VeganPizza',
                    orderedDrink: 'Water',
                }),
                expected
            );
        });
    });
    describe('Test getRemainingWork method', () => {
        it('Should return message when all orders are complete', () => {
            assert.equal(
                pizzUni.getRemainingWork([
                    { pizzaName: 'Vegan', status: 'ready' },
                    { pizzaName: 'Meat', status: 'ready' },
                    { pizzaName: 'Sugar', status: 'ready' },
                ]),
                'All orders are complete!'
            );
        });
        it('Should return the remaining orders', () => {
            assert.equal(
                pizzUni.getRemainingWork([
                    { pizzaName: 'Vegan', status: 'ready' },
                    { pizzaName: 'Meat', status: 'preparing' },
                    { pizzaName: 'Sugar', status: 'ready' },
                    { pizzaName: 'Tomato', status: 'preparing' },
                ]),
                'The following pizzas are still preparing: Meat, Tomato.'
            );
        });
    });
    describe('Test orderType method', () => {
        it('Should test carry out case ', () => {
            assert.equal(pizzUni.orderType(20, 'Carry Out'), 18);
            assert.equal(pizzUni.orderType(200, 'Carry Out'), 180);
            assert.equal(pizzUni.orderType(20.2, 'Carry Out'), 18.18);
        });
        it('Should test Delivery case', () => {
            assert.equal(pizzUni.orderType(20, 'Delivery'), 20);
            assert.equal(pizzUni.orderType(200, 'Delivery'), 200);
            assert.equal(pizzUni.orderType(20.2, 'Delivery'), 20.2);
        });
    });
});
