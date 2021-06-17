function solve(arr, sortingCriteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    const tickets = arr.reduce((acc, curr) => {
        let [destination, price, status] = curr.split('|');
        price = Number(price);
        acc.push(new Ticket(destination, price, status));
        return acc;
    }, []);

    return tickets.sort((a, b) => {
        if (typeof a[sortingCriteria] === 'number') {
            return a[sortingCriteria] - b[sortingCriteria];
        }
        return a[sortingCriteria].localeCompare(b[sortingCriteria]);
    });
}

const result = solve(
    [
        'Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed',
    ],
    'destination'
);

console.table(result);
