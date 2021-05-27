function solve(arr) {
    let mainDiagonalSum = 0;
    for (let i = 0; i < arr.length; i++) {
        mainDiagonalSum += arr[i][i];
    }

    let secondaryDiagonalSum = 0;
    for (let i = 0; i < arr.length; i++) {
        secondaryDiagonalSum += arr[i][arr.length - i - 1];
    }

    console.log(`${mainDiagonalSum} ${secondaryDiagonalSum}`);
}

solve([
    [20, 40],
    [10, 60],
]);
