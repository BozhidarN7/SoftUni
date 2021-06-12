function solve(commands) {
    const objects = {};

    function getProperties(obj = {}) {
        const output = [];
        for (const prop in obj) {
            output.push(`${prop}:${obj[prop]}`);
        }
        return output.join(', ');
    }

    const processor = {
        create(name1, inherit, name2) {
            let obj = {};
            if (inherit) {
                obj = objects[name2];
            }
            objects[name1] = Object.create(obj);
        },
        set(name, prop, value) {
            objects[name][prop] = value;
        },
        print(name) {
            console.log(getProperties(objects[name]));
        },
    };

    commands.forEach((command) => {
        const [cmd, ...args] = command.split(' ');
        processor[cmd](...args);
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
