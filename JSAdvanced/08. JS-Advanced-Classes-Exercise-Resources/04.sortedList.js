class List {
    constructor() {
        this.arr = [];
        this.size = 0;
    }

    // get size() {
    //     return this.arr.length;
    // }

    add(element) {
        this.arr.push(element);
        this.arr.sort((a, b) => a - b);
        this.size++;
    }
    remove(index) {
        this._isInRange(index);
        this.arr.splice(index, 1);
        this.size--;
    }
    get(index) {
        this._isInRange(index);
        return this.arr[index];
    }

    _isInRange(index) {
        if (index < 0 || index >= this.size) {
            throw new Erro('Index is out of range');
        }
    }
}

const list = new List();
list.add(5);
list.add(6);
list.add(7);

console.log(list.get(1));
list.remove(1);
console.log(list.get(1));
console.log(list.size);
console.log(list.hasOwnProperty('size'));
