function solve(arr) {
    return arr
        .map((x, i) => {
            if (i % 2) {
                return x * 2;
            }
        })
        .filter((x) => x !== undefined)
        .reverse();
}

console.log(solve([10, 15, 20, 25]));
