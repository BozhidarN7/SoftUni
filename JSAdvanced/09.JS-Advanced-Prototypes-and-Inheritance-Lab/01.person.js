function Person(first, last) {
    this.firstName = first;
    this.lastName = last;

    Object.defineProperty(this, 'fullName', {
        set: function (fullName) {
            const pattern = /(?<firstName>\w+) (?<lastName>\w+)/;
            const mathResult = fullName.match(pattern);

            if (mathResult) {
                this.firstName = mathResult.groups.firstName;
                this.lastName = mathResult.groups.lastName;
            }
        },
        get: function () {
            return `${this.firstName} ${this.lastName}`;
        },
    });
}

let person = new Person('Peter', 'Ivanov');
console.log(person.fullName); //Peter Ivanov
person.firstName = 'George';
console.log(person.fullName); //George Ivanov
person.lastName = 'Peterson';
console.log(person.fullName); //George Peterson
person.fullName = 'Nikola Tesla';
console.log(person.firstName); //Nikola
console.log(person.lastName); //Tesla
