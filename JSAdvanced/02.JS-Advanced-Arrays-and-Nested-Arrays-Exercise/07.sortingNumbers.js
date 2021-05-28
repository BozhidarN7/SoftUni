function solve(arr) {
    arr.sort((a, b) => a - b);
    const result = [];

    if (arr.length % 2) {
        for (let i = 0; i < parseInt(arr.length / 2); i++) {
            result.push(arr[i]);
            result.push(arr[arr.length - i - 1]);
        }
        result.push(arr[parseInt(arr.length / 2)]);
    } else {
        for (let i = 0; i < arr.length / 2; i++) {
            result.push(arr[i]);
            result.push(arr[arr.length - i - 1]);
        }
    }
    return result;
}

// console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));
console.log(solve([1, 2, 3, 4, 5]));
