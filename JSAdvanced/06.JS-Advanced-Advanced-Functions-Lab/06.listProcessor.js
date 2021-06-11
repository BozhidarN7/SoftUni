function solve(commands) {
    let list = [];

    const listProcessor = {
        add(value) {
            list.push(value);
        },
        remove(value) {
            list = list.filter((x) => x !== value);
        },
        print() {
            console.log(list.join(','));
        },
    };
    commands.forEach((command) => {
        const [operation, value] = command.split(' ');
        listProcessor[operation](value);
    });
}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);
