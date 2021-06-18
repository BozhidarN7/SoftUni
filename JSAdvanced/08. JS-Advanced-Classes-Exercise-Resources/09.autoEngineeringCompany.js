function solve(input) {
    const cars = input.reduce((cars, curr) => {
        let [brand, model, producedCars] = curr.split(' | ');
        producedCars = Number(producedCars);

        if (!cars[brand]) {
            cars[brand] = {};
        }
        if (!cars[brand][model]) {
            cars[brand][model] = 0;
        }
        cars[brand][model] += producedCars;
        return cars;
    }, {});

    Object.entries(cars).forEach(([brand, models]) => {
        console.log(brand);
        for (const model in models) {
            console.log(`###${model} -> ${models[model]}`);
        }
    });
}

solve([
    'Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10',
]);
