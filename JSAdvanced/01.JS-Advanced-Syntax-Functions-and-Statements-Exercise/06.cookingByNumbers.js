function solve(number, opr1, opr2, oper3, opr4, opr5) {
    const [, ...operations] = [...arguments];
    operations.forEach((opr) => {
        if (opr === 'chop') {
            number /= 2;
        } else if (opr === 'dice') {
            number = Math.sqrt(number);
        } else if (opr === 'spice') {
            number += 1;
        } else if (opr === 'bake') {
            number *= 3;
        } else {
            number -= number * 0.2;
        }
        console.log(number);
    });
    console.log(operations);
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');
