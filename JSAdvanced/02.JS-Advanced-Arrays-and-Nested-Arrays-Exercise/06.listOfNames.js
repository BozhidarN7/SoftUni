function solve(arr) {
    arr.sort((a, b) => a.toLowerCase().localeCompare(b.toLowerCase()));
    arr.forEach((x, i) => console.log(`${i + 1}.${x}`));
}

solve(['John', 'Bob', 'christina', 'Ema']);
