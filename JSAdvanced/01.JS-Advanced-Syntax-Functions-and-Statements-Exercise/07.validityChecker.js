function solve(x1, y1, x2, y2) {
    let a = Math.abs(x1 - 0);
    let b = Math.abs(y1 - 0);
    let distance = Math.sqrt(a * a + b * b);

    if (distance === parseInt(distance)) {
        console.log(`{${x1}, ${y1}} to {${0}, ${0}} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {${0}, ${0}} is invalid`);
    }

    a = Math.abs(x2 - 0);
    b = Math.abs(y2 - 0);
    distance = Math.sqrt(a * a + b * b);

    if (distance === parseInt(distance)) {
        console.log(`{${x2}, ${y2}} to {${0}, ${0}} is valid`);
    } else {
        console.log(`{${x2}, ${y2}} to {${0}, ${0}} is invalid`);
    }

    a = Math.abs(x1 - x2);
    b = Math.abs(y1 - y2);
    distance = Math.sqrt(a * a + b * b);

    if (distance === parseInt(distance)) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }
}

solve(3, 0, 0, 4);
solve(2, 1, 1, 1);
