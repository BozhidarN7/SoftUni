function extensibleObject() {
    return {
        extend: function (obj) {
            for (const key in obj) {
                if (typeof obj[key] === 'function') {
                    Object.getPrototypeOf(this)[key] = obj[key];
                } else {
                    this[key] = obj[key];
                }
            }
        },
    };
}

const myObj = extensibleObject();

const template = {
    extensionMethod: function () {},
    extensionProperty: 'someString',
};

// console.log(myObj);

myObj.extend(template);

console.log(myObj);
