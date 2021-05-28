function solve(rows, cols) {
    const matrix = [];
    for (let i = 0; i < rows; i++) {
        matrix[i] = new Array(cols).fill(0);
    }

    let number = 1;
    let row = 0;
    let col = 0;
    let direction = 'right';
    while (number <= rows * cols) {
        if (direction === 'right') {
            while (col < cols && matrix[row][col] === 0) {
                matrix[row][col] = number++;
                col++;
            }
            direction = 'bottom';
            row += 1;
            col--;
        } else if (direction === 'bottom') {
            while (row < rows && matrix[row][col] === 0) {
                matrix[row][col] = number++;
                row += 1;
            }
            direction = 'left';
            col -= 1;
            row--;
        } else if (direction === 'left') {
            while (col >= 0 && matrix[row][col] === 0) {
                matrix[row][col] = number++;
                col--;
            }
            direction = 'up';
            row -= 1;
            col++;
        } else if (direction === 'up') {
            while (row >= 0 && matrix[row][col] === 0) {
                matrix[row][col] = number++;
                row--;
            }
            direction = 'right';
            col += 1;
            row++;
        }
    }

    matrix.forEach((row) => console.log(row.join(' ')));
}

solve(5, 5);
