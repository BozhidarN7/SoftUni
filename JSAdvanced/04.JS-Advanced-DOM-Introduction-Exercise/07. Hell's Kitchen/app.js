function solve() {
    document.querySelector('#btnSend').addEventListener('click', onClick);
    const textareaEl = document.querySelector('#inputs textarea');
    const bestRestaurantEl = document.querySelector('#bestRestaurant p');
    const workersEl = document.querySelector('#workers p');

    function onClick() {
        const input = JSON.parse(textareaEl.value);
        const data = input.reduce((acc, cur) => {
            const obj = {};
            const tokens = cur.split(' - ');
            obj.restaurant = tokens[0];
            obj.workers = [];
            obj.highestSalary = 0;
            obj.averageSalary = 0;
            const workers = tokens[1].split(', ');
            for (let worker of workers) {
                let [name, salary] = worker.split(' ');
                salary = Number(salary);
                obj.workers.push({ name, salary });
                obj.averageSalary += salary;
                obj.highestSalary = Math.max(obj.highestSalary, salary);
            }
            if (acc.length === 0) {
                acc.push(obj);
                return acc;
            }
            const index = acc.findIndex(
                (res) => res.restaurant === obj.restaurant
            );
            if (index !== -1) {
                acc[index].highestSalary = Math.max(
                    acc[index].highestSalary,
                    obj.highestSalary
                );
                acc[index].workers.push(...obj.workers);
                acc[index].averageSalary += obj.averageSalary;
            } else {
                acc.push(obj);
            }

            return acc;
        }, []);
        console.log(data);
        const bestRestaurant = data.sort(
            (a, b) =>
                b.averageSalary / b.workers.length -
                a.averageSalary / a.workers.length
        )[0];
        bestRestaurantEl.textContent = `Name: ${
            bestRestaurant.restaurant
        } Average Salary: ${(
            bestRestaurant.averageSalary / bestRestaurant.workers.length
        ).toFixed(2)} Best Salary: ${bestRestaurant.highestSalary.toFixed(2)}`;

        bestRestaurant.workers
            .sort((a, b) => b.salary - a.salary)
            .forEach((worker) => {
                workersEl.textContent += `Name: ${worker.name} With Salary: ${worker.salary} `;
            });
    }
}
