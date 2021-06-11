function solve(...input) {
    const result = {};
    const occs = {};

    input.forEach((arg) => {
        const type = typeof arg;
        if (!occs[type]) {
            occs[type] = 0;
        }
        occs[type] += 1;
        console.log(`${type}: ${arg}`);
    });

    for (const [key, value] of Object.entries(occs).sort(
        (a, b) => b[1] - a[1]
    )) {
        console.log(`${key} = ${value}`);
    }
}

// solve('cat', 42, function () {
//     console.log('Hello world!');
// });

solve(
    { name: 'bob' },
    { name: 'bob' },
    { name: 'bob' },
    1,
    'cat',
    3.333,
    9.999
);
