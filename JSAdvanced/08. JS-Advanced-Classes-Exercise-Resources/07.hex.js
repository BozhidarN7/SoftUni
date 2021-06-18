class Hex {
    constructor(value) {
        this.value = value;
    }

    valueOf() {
        return this.value;
    }
    toString() {
        return `0x${this.value.toString(16).toUpperCase()}`;
    }
    plus(number) {
        return new Hex(this.value + Number(number.valueOf()));
    }
    minus(number) {
        return new Hex(this.value - Number(number.valueOf()));
    }
    parse(hexNumber) {
        return Number.parseInt(hexNumber, 16);
    }
}

let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString() === '0xF');
