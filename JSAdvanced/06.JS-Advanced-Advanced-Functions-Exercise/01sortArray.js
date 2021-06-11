function solve(arr, sortOrder) {
    const sorter = {
        asc: (arr) => {
            return arr.sort((a, b) => a - b);
        },
        desc: (arr) => {
            return arr.sort((a, b) => b - a);
        },
    };

    return sorter[sortOrder](arr);
}

solve([14, 7, 17, 6, 8], 'desc');
