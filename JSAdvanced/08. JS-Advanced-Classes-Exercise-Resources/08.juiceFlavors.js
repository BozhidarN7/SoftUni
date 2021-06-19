function solve(input) {
    const juices = new Map();
    const bottles = new Map();

    input.forEach((curr) => {
        let [juice, quantity] = curr.split(' => ');
        quantity = Number(quantity);

        if (!juices.has(juice)) {
            juices.set(juice, 0);
        }
        juices.set(juice, juices.get(juice) + quantity);

        if (juices.get(juice) >= 1000) {
            const newBottles = Number.parseInt(juices.get(juice) / 1000);
            juices.set(juice, juices.get(juice) - newBottles * 1000);

            if (!bottles.has(juice)) {
                bottles.set(juice, 0);
            }
            bottles.set(juice, bottles.get(juice) + newBottles);
        }
    });

    let result = '';
    for (const [juice, bottlesCount] of bottles) {
        result += `${juice} => ${bottlesCount}\n`;
    }
    return result;
}

console.log(
    solve([
        'Orange => 2000',
        'Orange => 1432',
        'Orange => 450',
        'Orange => 600',
        'Orange => 549',
    ])
);
