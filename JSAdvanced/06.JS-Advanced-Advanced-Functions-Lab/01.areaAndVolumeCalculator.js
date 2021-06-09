function solve(area, vol, input) {
    const object = JSON.parse(input);

    return object.map(function (obj) {
        return {
            area: area.call(obj),
            volume: vol.call(obj),
        };
    });
}

function area() {
    return Math.abs(this.x * this.y);
}

function vol() {
    return Math.abs(this.x * this.y * this.z);
}

console.table(
    solve(
        area,
        vol,
        '[{"x":"1","y":"2","z":"10"},{"x":"7","y":"7","z":"10"},{"x":"5","y":"2","z":"10"}]'
    )
);
