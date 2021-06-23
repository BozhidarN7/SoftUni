function solve() {
    class Employee {
        constructor(name, age) {
            if (this.constructor === Employee) {
                throw new Error('Cannot instantiate abstract class');
            }

            this.name = name;
            this.age = age;
            this.salary = 0;
            this.tasks = [];
            this._currentTask = 0;
        }

        work() {
            const task = this.tasks[this._currentTask++];
            this._currentTask = this._currentTask % this.tasks.length;
            console.log(task);
        }
        collectSalary() {
            console.log(
                `${this.name} received ${this._calculateSalary()} this month.`
            );
        }
        _calculateSalary() {
            return this.salary;
        }
    }

    class Junior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks.push(`${this.name} is working on a simple task.`);
        }
    }
    class Senior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks.push(
                `${this.name} is working on a complicated task.`,
                `${this.name} is taking time off work.`,
                `${this.name} is supervising junior workers.`
            );
        }
    }

    class Manager extends Employee {
        constructor(name, age) {
            super(name, age);
            this.dividend = 0;
            this.tasks.push(
                `${this.name} scheduled a meeting.`,
                `${this.name} is preparing a quarterly report.`
            );
        }

        _calculateSalary() {
            return this.salary + this.dividend;
        }
    }

    return {
        Employee,
        Junior,
        Senior,
        Manager,
    };
}

const classes = solve();
const junior = new classes.Junior('Ivan', 25);

junior.work();
junior.work();

junior.salary = 5811;
junior.collectSalary();

const senior = new classes.Senior('Alex', 31);
senior.work();
senior.work();
senior.work();
senior.work();

senior.salary = 12050;
senior.collectSalary();

const manager = new classes.Manager('Tom', 55);

manager.salary = 15000;
manager.collectSalary();
manager.dividend = 2500;
manager.collectSalary();

console.log(manager.hasOwnProperty('salary'));
