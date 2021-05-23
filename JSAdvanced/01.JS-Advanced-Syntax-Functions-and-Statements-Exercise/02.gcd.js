function solve(a, b) {
    while (a !== 0) {
        const temp = a;
        a = b % a;
        b = temp;
    }

    console.log(b);
}

solve(2154, 458);
