function solve(arr) {
    arr.sort((a, b) => a - b);
    console.log(arr[0]);
    console.log(arr[1]);
}

solve([30, 15, 50, 5]);
