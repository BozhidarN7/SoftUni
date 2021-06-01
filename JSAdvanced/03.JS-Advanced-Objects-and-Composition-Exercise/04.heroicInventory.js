function solve(input) {
    const result = input.reduce((arr, x) => {
        const obj = {};
        const tokens = x.split(' / ');
        obj.name = tokens[0];
        obj.level = Number(tokens[1]);
        if (tokens[2]) {
            obj.items = tokens[2].split(', ');
        } else {
            obj.items = [];
        }
        arr.push(obj);
        return arr;
    }, []);

    console.log(JSON.stringify(result));
}

solve([
    'Isacc / 25',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara',
]);
