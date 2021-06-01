function solve(arr) {
    const calculator = {
        '+': function (a, b) {
            return a + b;
        },
        '-': function (a, b) {
            return a - b;
        },
        '*': function (a, b) {
            return a * b;
        },
        '/': function (a, b) {
            return a / b;
        },
    };

    while (true) {
        const operationIndex = arr.indexOf(
            arr.find((x) => typeof x === 'string')
        );
        if (operationIndex !== -1) {
            if (arr.length <= 2) {
                console.log('Error: not enough operands!');
                return;
            }
            const startIndex = operationIndex - 2;
            const part = arr.slice(startIndex, operationIndex + 1);
            const result = calculator[part[2]](part[0], part[1]);
            arr.splice(startIndex, 3);
            arr.splice(startIndex, 0, result);

            if (arr.length === 1) {
                break;
            }
        } else {
            console.log('Error: too many operands!');
            return;
        }
    }
    console.log(arr[0]);
}

solve([3, 4, '+']);
solve([5, 3, 4, '*', '-']);
solve([7, 33, 8, '-']);
solve([15, '/']);
