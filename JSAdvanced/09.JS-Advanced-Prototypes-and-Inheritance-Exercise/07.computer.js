function solve() {
    class Common {
        constructor(manufacturer) {
            if (this.constructor === Common) {
                throw new Error('Cannot instantiate abstract class');
            }

            this.manufacturer = manufacturer;
        }
    }

    class Keyboard extends Common {
        constructor(manufacturer, responseTime) {
            super(manufacturer);
            this.responseTime = responseTime;
        }
    }

    class Monitor extends Common {
        constructor(manufacturer, width, height) {
            super(manufacturer);
            this.width = width;
            this.height = height;
        }
    }
    class Battery extends Common {
        constructor(manufacturer, expectedLife) {
            super(manufacturer);
            this.expectedLife = expectedLife;
        }
    }
    class Computer extends Common {
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace) {
            super(manufacturer);
            if (this.constructor === Computer) {
                throw new Error('Cannot instantiate abstract class');
            }
            this.processorSpeed = processorSpeed;
            this.ram = ram;
            this.hardDiskSpace = hardDiskSpace;
        }
    }
    class Laptop extends Computer {
        constructor(
            manufacturer,
            processorSpeed,
            ram,
            hardDiskSpace,
            weight,
            color,
            battery
        ) {
            super(manufacturer, processorSpeed, ram, hardDiskSpace);
            this.weight = weight;
            this.color = color;
            this.battery = battery;
        }

        get battery() {
            return this._battery;
        }
        set battery(value) {
            if (!(value instanceof Battery)) {
                throw new TypeError('Battery is not instance of Battery class');
            }
            this._battery = value;
        }
    }
    class Desktop extends Computer {
        constructor(
            manufacturer,
            processorSpeed,
            ram,
            hardDiskSpace,
            keyboard,
            monitor
        ) {
            super(manufacturer, processorSpeed, ram, hardDiskSpace);
            this.keyboard = keyboard;
            this.monitor = monitor;
        }

        get monitor() {
            return this._monitor;
        }
        set monitor(value) {
            if (!(value instanceof Monitor)) {
                throw new TypeError('Monitor is not instance of Monitor class');
            }
            this._monitor = value;
        }

        get keyboard() {
            return this._keyboard;
        }
        set keyboard(value) {
            if (!(value instanceof Keyboard)) {
                throw new TypeError(
                    'Keyboard is not instance of Keyboard class'
                );
            }
            this._keyboard = value;
        }
    }

    return {
        Battery,
        Keyboard,
        Monitor,
        Computer,
        Laptop,
        Desktop,
    };
}

let classes = solve();
let Computer = classes.Computer;
let Laptop = classes.Laptop;
let Desktop = classes.Desktop;
let Monitor = classes.Monitor;
let Battery = classes.Battery;
let Keyboard = classes.Keyboard;

let keyboard = new Keyboard('Logitech', 70);
let monitor = new Monitor('Benq', 28, 18);
let desktop = new Desktop('JAR Computers', 3.3, 8, 1, keyboard, monitor);
