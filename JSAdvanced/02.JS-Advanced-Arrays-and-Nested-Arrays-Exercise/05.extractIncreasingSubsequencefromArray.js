function solve(arr) {
    const result = [];
    arr.reduce((max, x) => {
        if (x >= max) {
            max = x;
            result.push(max);
        }
        return max;
    }, arr[0]);
    return result;
}

console.log(solve([1, 3, 8, 4, 10, 12, 3, 2, 24]));
