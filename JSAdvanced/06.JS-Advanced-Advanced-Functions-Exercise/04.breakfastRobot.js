function solution() {
    const ingredients = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0,
    };

    const cooker = {
        apple(quantity) {
            if (ingredients['carbohydrate'] * quantity < 1 * quantity) {
                return `Error: not enough carbohydrate in stock`;
            }
            if (ingredients['flavour'] * quantity < 2 * quantity) {
                return `Error: not enough flavour in stock`;
            }
            ingredients['carbohydrate'] -= 1 * quantity;
            ingredients['flavour'] -= 2 * quantity;
            return 'Success';
        },
        lemonade(quantity) {
            if (ingredients['carbohydrate'] * quantity < 10 * quantity) {
                return `Error: not enough carbohydrate in stock`;
            }
            if (ingredients['flavour'] * quantity < 20 * quantity) {
                return `Error: not enough flavour in stock`;
            }
            ingredients['carbohydrate'] -= 10 * quantity;
            ingredients['flavour'] -= 20 * quantity;
            return 'Success';
        },
        burger(quantity) {
            if (ingredients['carbohydrate'] * quantity < 5 * quantity) {
                return `Error: not enough carbohydrate in stock`;
            }
            if (ingredients['fat'] * quantity < 7 * quantity) {
                return `Error: not enough fat in stock`;
            }
            if (ingredients['flavour'] * quantity < 3 * quantity) {
                return `Error: not enough flavour in stock`;
            }
            ingredients['carbohydrate'] -= 5 * quantity;
            ingredients['flavour'] -= 3 * quantity;
            ingredients['fat'] -= 7 * quantity;
            return 'Success';
        },
        eggs(quantity) {
            if (ingredients['protein'] * quantity < 5 * quantity) {
                return `Error: not enough protein in stock`;
            }
            if (ingredients['fat'] * quantity < 1 * quantity) {
                return `Error: not enough fat in stock`;
            }
            if (ingredients['flavour'] * quantity < 1 * quantity) {
                return `Error: not enough flavour in stock`;
            }
            ingredients['protein'] -= 5 * quantity;
            ingredients['flavour'] -= 1 * quantity;
            ingredients['fat'] -= 1 * quantity;
            return 'Success';
        },
        turkey(quantity) {
            if (ingredients['protein'] * quantity < 10 * quantity) {
                return `Error: not enough protein in stock`;
            }
            if (ingredients['carbohydrate'] * quantity < 10 * quantity) {
                return `Error: not enough carbohydrate in stock`;
            }
            if (ingredients['fat'] * quantity < 10 * quantity) {
                return `Error: not enough fat in stock`;
            }
            if (ingredients['flavour'] * quantity < 10 * quantity) {
                return `Error: not enough flavour in stock`;
            }
            ingredients['carbohydrate'] -= 10 * quantity;
            ingredients['flavour'] -= 10 * quantity;
            ingredients['fat'] -= 10 * quantity;
            ingredients['protein'] -= 10 * quantity;
            return 'Success';
        },
    };

    const processor = {
        restock(ing, quantity) {
            ingredients[ing] += quantity;
            return 'Success';
        },
        prepare(ing, quantity) {
            return cooker[ing](quantity);
        },
        report() {
            return Object.entries(ingredients)
                .map(([prop, value]) => `${prop}=${value}`)
                .join(' ');
        },
    };

    return (input) => {
        let [cmd, ing, quantity] = input.split(' ');
        quantity = Number(quantity);

        if (ing) {
            return processor[cmd](ing, quantity);
        }
        return processor[cmd]();
    };
}

let manager = solution();
console.log(manager('prepare turkey 1'));
console.log(manager('restock protein 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('restock carbohydrate 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('restock fat 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('restock flavour 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('report'));
