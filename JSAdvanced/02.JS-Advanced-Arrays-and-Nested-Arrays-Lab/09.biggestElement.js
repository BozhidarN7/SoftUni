function solve(arr) {
    let result = -1000000;
    for (let i = 0; i < arr.length; i++) {
        for (let j = 0; j < arr[i].length; j++) {
            result = Math.max(result, arr[i][j]);
        }
    }
    return result;
}

console.log(
    solve([
        [-1, -2, -3],
        [-6, -7],
    ])
);
