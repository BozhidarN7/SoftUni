function solve(input) {
    const matrix = [];

    input.forEach((line, i) => {
        matrix[i] = line.split(' ').map((x) => Number(x));
    });

    const n = matrix.length;

    let mainDiagonalSum = 0;
    for (let i = 0; i < n; i++) {
        mainDiagonalSum += matrix[i][i];
    }

    let secondaryDiagonalSum = 0;
    for (let i = 0; i < n; i++) {
        secondaryDiagonalSum += matrix[i][n - i - 1];
    }

    if (mainDiagonalSum === secondaryDiagonalSum) {
        for (let i = 0; i < n; i++) {
            for (let j = 0; j < n; j++) {
                if (j === i) {
                    continue;
                }
                if (j === n - i - 1) {
                    continue;
                }

                matrix[i][j] = mainDiagonalSum;
            }
        }
    }

    matrix.forEach((row) => console.log(row.join(' ')));
}

solve([
    '5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1',
]);
