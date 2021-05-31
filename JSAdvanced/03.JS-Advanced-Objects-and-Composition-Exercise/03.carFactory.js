function solve(order) {
    const engine = {
        small: {
            power: 90,
            volume: 1800,
        },
        normal: {
            power: 120,
            volume: 2400,
        },
        monster: {
            power: 200,
            volume: 3500,
        },
    };
    const carriage = {
        hatchback: {
            type: 'hatchback',
            color: null,
        },
        coupe: {
            type: 'coupe',
            color: null,
        },
    };

    const result = {};

    result.model = order.model;

    if (order.power <= 90) {
        result.engine = engine.small;
    } else if (order.power > 90 && order.power <= 120) {
        result.engine = engine.normal;
    } else {
        result.engine = engine.monster;
    }

    result.carriage = carriage[order.carriage];
    result.carriage.color = order.color;

    result.wheels =
        Math.floor(order.wheelsize) % 2
            ? new Array(4).fill(Math.floor(order.wheelsize))
            : new Array(4).fill(Math.floor(order.wheelsize) - 1);

    return result;
}

console.log(
    solve({
        model: 'VW Golf II',
        power: 90,
        color: 'blue',
        carriage: 'hatchback',
        wheelsize: 14,
    })
);
console.log(2);
