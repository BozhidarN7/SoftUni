function solve(input) {
    const result = [];
    for (const iterator of input) {
        let [town, product, price] = iterator.split(' | ');
        price = Number(price);

        let obj = result.find((x) => x.product === product && x.town === town);
        if (obj) {
            obj.price = price;
        } else {
            result.push({ town, product, price });
        }
    }
    const products = new Set(result.map((x) => x.product));
    result.sort((a, b) => a.price - b.price);

    products.forEach((product) => {
        const res = result.find((x) => x.product === product);
        console.log(`${res.product} -> ${res.price} (${res.town})`);
    });
}

solve([
    'Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10',
]);
