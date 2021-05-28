function solve(arr, rotation) {
    rotation %= arr.length;
    for (let i = 0; i < rotation; i++) {
        const temp = arr[arr.length - 1];
        for (let j = arr.length - 2; j >= 0; j--) {
            arr[j + 1] = arr[j];
        }
        arr[0] = temp;
    }

    console.log(arr.join(' '));
}

solve(['1', '2', '3', '4'], 2);
solve(['Banana', 'Orange', 'Coconut', 'Apple'], 15);
