function solve(input) {
    const result = input.reduce((obj, el, i, arr) => {
        if (i % 2) {
            return obj;
        }
        obj[arr[i]] = Number(arr[i + 1]);
        return obj;
    }, {});

    console.log(result);
}

solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);
