class Company {
    constructor() {
        this.departments = {};
    }

    addEmployee(username, salary, position, department) {
        if (!username || !salary || !position || !department || salary < 0) {
            throw new Error('Invalid input!');
        }
        if (!this.departments.hasOwnProperty(department)) {
            this.departments[department] = [];
        }
        this.departments[department].push({ username, salary, position });
        return `New employee is hired. Name: ${username}. Position: ${position}`;
    }
    bestDepartment() {
        const department = Object.entries(this.departments).sort(
            (a, b) =>
                b[1].reduce((acc, cur) => (acc += cur.salary), 0) /
                    b[1].length -
                a[1].reduce((acc, cur) => (acc += cur.salary), 0) / a[1].length
        )[0];
        let result = `Best Department is: ${department[0]}\n`;
        result += `Average salary: ${(
            department[1].reduce((acc, cur) => (acc += cur.salary), 0) /
            department[1].length
        ).toFixed(2)}\n`;
        department[1]
            .sort((a, b) => {
                if (a.salary === b.salary) {
                    return a.username.localeCompare(b.username);
                }
                return b.salary - a.salary;
            })
            .forEach((employee) => {
                result += `${employee.username} ${employee.salary} ${employee.position}\n`;
            });

        return result.trim();
    }
}

let c = new Company();

let actual1 = c.addEmployee('Stanimir', 2000, 'engineer', 'Human resources');

c.addEmployee('Pesho', 1500, 'electrical engineer', 'Construction');
c.addEmployee('Slavi', 500, 'dyer', 'Construction');
c.addEmployee('Stan', 2000, 'architect', 'Construction');
c.addEmployee('Stanimir', 1200, 'digital marketing manager', 'Marketing');
c.addEmployee('Pesho', 1000, 'graphical designer', 'Marketing');
c.addEmployee('Gosho', 1350, 'HR', 'Human resources');

let act = c.bestDepartment();
let exp =
    'Best Department is: Human resources\nAverage salary: 1675.00\nStanimir 2000 engineer\nGosho 1350 HR';
console.log(act);
