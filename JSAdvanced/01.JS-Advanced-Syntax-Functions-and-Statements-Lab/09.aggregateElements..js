function solve(a) {
    const sum = a.reduce((sum, x) => (sum += x), 0);
    const inverseSum = a.reduce((sum, x) => (sum += 1 / x), 0);
    const concat = a.join('');

    console.log(sum);
    console.log(inverseSum);
    console.log(concat);
}

solve([1, 2, 3]);
solve([2, 4, 8, 16]);
