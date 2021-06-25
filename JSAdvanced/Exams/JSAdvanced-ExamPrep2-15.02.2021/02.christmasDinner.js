class ChristmasDinner {
    constructor(budget) {
        this.budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }

    get budget() {
        return this._budget;
    }
    set budget(value) {
        if (value < 0) {
            throw new Error('The budget cannot be a negative number');
        }
        this._budget = value;
    }

    shopping(products) {
        const price = Number(products[1]);
        const product = products[0];

        if (this.budget < price) {
            throw new Error('Not enough money to buy this product');
        }

        this.budget -= price;
        this.products.push(product);

        return `You have successfully bought ${product}!`;
    }

    recipes(recipe) {
        recipe.productsList.forEach((product) => {
            if (!this.products.includes(product)) {
                throw new Error('We do not have this product');
            }
        });

        this.dishes.push({
            recipeName: recipe.recipeName,
            productsList: recipe.productsList,
        });

        return `${recipe.recipeName} has been successfully cooked!`;
    }
    inviteGuests(name, dish) {
        const dishObj = this.dishes.find(
            (curDish) => curDish.recipeName === dish
        );

        if (!dishObj) {
            throw new Error('We do not have this dish');
        }

        if (Object.keys(this.guests).includes(name)) {
            throw new Error('This guest has already been invited');
        }

        this.guests[name] = dish;
        return `You have successfully invited ${name}!`;
    }

    showAttendance() {
        let result = '';

        for (const guest in this.guests) {
            result += `${guest} will eat ${
                this.guests[guest]
            }, which consists of ${this.dishes
                .find((cur) => cur.recipeName === this.guests[guest])
                .productsList.join(', ')}`;
            result += '\n';
        }
        return result.trim();
    }
}

let dinner = new ChristmasDinner(300);

console.log(dinner.shopping(['Salt', 1]));
console.log(dinner.shopping(['Beans', 3]));
console.log(dinner.shopping(['Cabbage', 4]));
console.log(dinner.shopping(['Rice', 2]));
console.log(dinner.shopping(['Savory', 1]));
console.log(dinner.shopping(['Peppers', 1]));
console.log(dinner.shopping(['Fruits', 40]));
console.log(dinner.shopping(['Honey', 10]));

console.log(
    dinner.recipes({
        recipeName: 'Oshav',
        productsList: ['Fruits', 'Honey'],
    })
);
dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory'],
});
dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt'],
});

console.log(dinner.inviteGuests('Ivan', 'Oshav'));
console.log(dinner.inviteGuests('Ivan', 'Oshav'));
dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice');
dinner.inviteGuests('Georgi', 'Peppers filled with beans');

console.log(dinner.showAttendance());
