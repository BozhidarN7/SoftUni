function solve(fruit, grams, price) {
    const kg = grams / 1000;
    const totalPrice = price * kg;

    console.log(
        `I need $${totalPrice.toFixed(2)} to buy ${kg.toFixed(
            2
        )} kilograms ${fruit}.`
    );
}

solve('orange', 2500, 1.8);
