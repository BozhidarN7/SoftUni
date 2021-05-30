function solve(input) {
    const result = input.reduce((obj, x) => {
        const tokens = x.split(' <-> ');
        if (obj[tokens[0]]) {
            obj[tokens[0]] += Number(tokens[1]);
        } else {
            obj[tokens[0]] = Number(tokens[1]);
        }
        return obj;
    }, {});

    Object.entries(result).forEach(([town, population]) => {
        console.log(`${town} : ${population}`);
    });
}

solve([
    'Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000',
]);
