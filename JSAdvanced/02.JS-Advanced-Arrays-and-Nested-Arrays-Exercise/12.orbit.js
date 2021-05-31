function solve(input) {
    const rows = input[0];
    const cols = input[1];
    let startRow = input[2];
    let startCol = input[3];
    let maxValue = 1;
    const matrix = [];
    for (let i = 0; i < rows; i++) {
        matrix[i] = new Array(cols).fill(0);
    }
    matrix[startRow][startCol] = 1;

    for (let i = 0; i < rows; i++) {
        for (let j = 0; j < cols; j++) {
            if (!matrix[i][j]) {
                matrix[i][j] =
                    Math.max(Math.abs(i - startRow), Math.abs(j - startCol)) +
                    1;
            }
        }
    }

    matrix.forEach((row) => console.log(row.join(' ')));
}

// solve([4, 4, 0, 0]);
solve([5, 5, 2, 2]);
solve([3, 3, 2, 2]);
