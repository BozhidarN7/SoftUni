function solve(matrix) {
    const n = matrix.length;

    const sum = matrix[0].reduce((sum, x) => (sum += x));
    let result = true;
    for (let i = 1; i < n; i++) {
        let curSum = 0;
        for (let j = 0; j < n; j++) {
            curSum += matrix[i][j];
        }

        if (curSum !== sum) {
            result = false;
            break;
        }
    }

    for (let j = 0; j < n; j++) {
        let curSum = 0;
        for (let i = 0; i < n; i++) {
            curSum += matrix[i][j];
        }
        if (curSum !== sum) {
            result = false;
            break;
        }
    }

    console.log(result);
}

solve([
    [4, 5, 6],
    [6, 5, 4],
    [5, 5, 5],
]);

solve([
    [11, 32, 45],
    [21, 0, 1],
    [21, 1, 1],
]);
