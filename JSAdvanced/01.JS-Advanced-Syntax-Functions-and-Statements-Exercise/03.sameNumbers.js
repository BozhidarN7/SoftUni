function solve(number) {
    const digits = String(number).split('');
    const set = new Set(digits);

    if (set.size === 1) {
        console.log(true);
    } else {
        console.log(false);
    }
    console.log(digits.reduce((sum, x) => (sum += +x), 0));
}

solve(222222);
solve(1234);
