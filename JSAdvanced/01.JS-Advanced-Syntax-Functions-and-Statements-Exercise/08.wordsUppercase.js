function solve(text) {
    const words = text
        .split(/\W+/g)
        .filter((x) => x)
        .map((x) => x.toUpperCase())
        .join(', ');
    console.log(words);
}

solve('Hi, how are you?');
solve('hello');
