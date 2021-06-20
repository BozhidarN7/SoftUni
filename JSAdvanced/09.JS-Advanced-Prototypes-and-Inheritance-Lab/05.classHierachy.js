function solve() {
    class Figure {
        constructor(unit = 'cm') {
            this.unit = unit;
        }
        get unit() {
            return this._unit;
        }
        set unit(value) {
            this._unit = value;
        }
        changeUnits(unit) {
            this.unit = unit;
        }
        unitMultiplier() {
            return {
                mm: () => {
                    return 10;
                },
                m: () => {
                    return 0.01;
                },
                cm: () => {
                    return 1;
                },
            };
        }
        get area() {}
        toString() {
            return `Figures units: ${this.unit}`;
        }
    }

    class Circle extends Figure {
        constructor(radius) {
            super();
            this.radius = radius;
        }
        get radius() {
            return this._radius;
        }
        set radius(value) {
            this._radius = value;
        }

        get area() {
            return (
                (this.radius * this.unitMultiplier()[this.unit]()) ** 2 *
                Math.PI
            );
        }

        toString() {
            return (
                super.toString() +
                ` Area: ${this.area} - radius: ${
                    this.radius * this.unitMultiplier()[this.unit]()
                }`
            );
        }
    }

    class Rectangle extends Figure {
        constructor(width, height, units) {
            super(units);
            this.width = width;
            this.height = height;
        }

        get width() {
            return this._width;
        }
        set width(value) {
            this._width = value;
        }

        get height() {
            return this._height;
        }
        set height(value) {
            this._height = value;
        }

        get area() {
            return (
                this.width *
                this.unitMultiplier()[this.unit]() *
                this.height *
                this.unitMultiplier()[this.unit]()
            );
        }

        toString() {
            return (
                super.toString() +
                ` Area: ${this.area} - width: ${
                    this.width * this.unitMultiplier()[this.unit]()
                }, height: ${this.height * this.unitMultiplier()[this.unit]()}`
            );
        }
    }

    return {
        Figure,
        Rectangle,
        Circle,
    };
}

let c = new Circle(5);
console.log(c.area); // 78.53981633974483
console.log(c.toString()); // Figures units: cm Area: 78.53981633974483 - radius: 5

let r = new Rectangle(3, 4, 'mm');
console.log(r.area); // 1200
console.log(r.toString()); //Figures units: mm Area: 1200 - width: 30, height: 40

r.changeUnits('cm');
console.log(r.area); // 12
console.log(r.toString()); // Figures units: cm Area: 12 - width: 3, height: 4

c.changeUnits('mm');
console.log(c.area); // 7853.981633974483
console.log(c.toString()); // Figures units: mm Area: 7853.981633974483 - radius: 50
