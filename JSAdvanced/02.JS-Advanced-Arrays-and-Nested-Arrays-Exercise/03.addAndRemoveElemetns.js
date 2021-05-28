function solve(operations) {
    const result = [];

    let number = 1;
    operations.forEach((x) => {
        if (x === 'add') {
            result.push(number++);
        } else {
            result.pop();
            number++;
        }
    });

    if (!result.length) {
        console.log('Empty');
        return;
    }

    result.forEach((x) => console.log(x));
}

solve(['add', 'add', 'add', 'add']);
solve(['add', 'add', 'remove', 'add', 'add']);
solve(['remove', 'remove', 'remove']);
