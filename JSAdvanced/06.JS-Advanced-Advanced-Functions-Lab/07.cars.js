function solve(commands) {
    const objects = [];

    const processor = {
        create(name) {
            objects.push({ name });
        },
        inherit(value1, value2) {
            const newObj = Object.create(
                objects.find((obj) => obj.name === value2)
            );
            newObj.name = value1;
            objects.push(newObj);
        },
        set(value1, opr2, value2) {
            const obj = objects.find((x) => x.name === value1);
            obj[opr2] = value2;
        },
        print(name) {
            const target = objects.find((obj) => obj.name === name);

            const result1 = Object.entries(target)
                .map(([key, value]) => {
                    if (key !== 'name') return `${key}:${value}`;
                    return '';
                })
                .filter((x) => x !== '')
                .join(', ');

            const result2 = Object.entries(target.__proto__)
                .map(([key, value]) => {
                    if (key !== 'name') return `${key}:${value}`;
                    return '';
                })
                .filter((x) => x !== '')
                .join(', ');

            if (result1 && result2) {
                console.log(`${result1}, ${result2}`);
            } else if (result1) {
                console.log(result1);
            } else {
                console.log(result2);
            }
        },
    };

    commands.forEach((command) => {
        const [opr1, value1, opr2, value2] = command.split(' ');

        if (opr2 && opr2 === 'inherit') {
            processor[opr2](value1, value2);
        } else if (opr1 === 'set') {
            processor[opr1](value1, opr2, value2);
        } else if (opr1 === 'print') {
            processor[opr1](value1);
        } else {
            processor[opr1](value1);
        }
    });
}

solve([
    'create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'set c1 brand tesla',
    'create c3 inherit c2',
    'print c1',
    'print c2',
    'print c3',
]);
