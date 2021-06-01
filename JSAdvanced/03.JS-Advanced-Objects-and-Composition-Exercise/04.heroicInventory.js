function solve(input) {
    const result = input.reduce((arr, x) => {
        let [name, level, items] = x.split(' / ');
        level = Number(level);
        items = items ? items.split(', ') : [];

        arr.push({ name, level, items });
        return arr;
    }, []);

    console.log(JSON.stringify(result));
}

solve([
    'Isacc / 25',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara',
]);
