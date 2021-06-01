function solve(input) {
    const catalogue = input.reduce((catalogue, x) => {
        let [product, price] = x.split(' : ');
        price = Number(price);
        catalogue.push({ product, price });
        return catalogue;
    }, []);

    catalogue.sort((a, b) =>
        a.product.toLowerCase().localeCompare(b.product.toLowerCase())
    );

    new Set(catalogue.map((x) => x.product[0])).forEach((letter) => {
        console.log(letter);
        catalogue
            .filter((x) => x.product.startsWith(letter))
            .forEach((pair) => console.log(`${pair.product}: ${pair.price}`));
    });
}

solve([
    'Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10',
]);

solve([
    'Banana : 2',
    "Rubic's Cube : 5",
    'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10',
]);
