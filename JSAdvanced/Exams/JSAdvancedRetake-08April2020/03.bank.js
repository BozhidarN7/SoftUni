class Bank {
    constructor(bankName) {
        this._bankName = bankName;
        this.allCustomers = [];
    }

    newCustomer(customer) {
        const existingCustomer = this.allCustomers.find(
            (x) => x.personalId === customer.personalId
        );
        if (existingCustomer) {
            throw new Error(
                `${customer.firstName} ${customer.lastName} is already our customer!`
            );
        }
        this.allCustomers.push(customer);
        return customer;
    }

    depositMoney(personalId, amount) {
        const customer = this.allCustomers.find(
            (x) => x.personalId === personalId
        );
        if (!customer) {
            throw new Error('We have no customer with this ID!');
        }

        if (!customer.totalMoney) {
            customer.totalMoney = 0;
        }
        customer.totalMoney += amount;

        if (!customer.transactions) {
            customer.transactions = [];
        }

        customer.transactions.push(
            `${customer.transactions.length + 1}. ${customer.firstName} ${
                customer.lastName
            } made deposit of ${amount}$!`
        );

        return `${customer.totalMoney}$`;
    }
    withdrawMoney(personalId, amount) {
        const customer = this.allCustomers.find(
            (x) => x.personalId === personalId
        );
        if (!customer) {
            throw new Error('We have no customer with this ID!');
        }

        if (!customer.totalMoney || customer.totalMoney < amount) {
            throw new Error(
                `${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`
            );
        }
        customer.totalMoney -= amount;
        customer.transactions.push(
            `${customer.transactions.length + 1}. ${customer.firstName} ${
                customer.lastName
            } withdrew ${amount}$!`
        );

        return `${customer.totalMoney}$`;
    }

    customerInfo(personalId) {
        const customer = this.allCustomers.find(
            (x) => x.personalId === personalId
        );
        if (!customer) {
            throw new Error('We have no customer with this ID!');
        }

        let result = `Bank name: ${this._bankName}\n`;
        result += `Customer name: ${customer.firstName} ${customer.lastName}\n`;
        result += `Customer ID: ${customer.personalId}\n`;
        result += `Total Money: ${customer.totalMoney}$\n`;
        result += 'Transactions:\n';

        result += customer.transactions.reverse().join('\n');

        return result.trim();
    }
}

let bank = new Bank('some');

bank.newCustomer({
    firstName: 'Svetlin',
    lastName: 'Nakov',
    personalId: 1111111,
});

bank.newCustomer({
    firstName: 'Svetlin',
    lastName: 'Nakov',
    personalId: 1111111,
});
