function solve(arr) {
    let result = 0;
    for (let i = 0; i < arr.length; i++) {
        for (let j = 0; j < arr[i].length; j++) {
            const rows = [1, -1, 0, 0];
            const cols = [0, 0, -1, 1];

            for (let k = 0; k < 4; k++) {
                const nextRow = rows[k] + i;
                const nextCol = cols[k] + j;

                if (
                    nextRow >= 0 &&
                    nextRow < arr.length &&
                    nextCol >= 0 &&
                    nextCol < arr[i].length &&
                    arr[nextRow][nextCol] === arr[i][j]
                ) {
                    result++;
                }
            }
        }
    }
    return result / 2;
}

console.log(
    solve([
        ['2', '3', '4', '7', '0'],
        ['4', '0', '5', '3', '4'],
        ['2', '3', '5', '4', '2'],
        ['9', '8', '7', '5', '4'],
    ])
);
