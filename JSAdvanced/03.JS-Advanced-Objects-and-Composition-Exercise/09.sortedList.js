function createSortedList() {
    return {
        arr: [],
        size: 0,
        add(element) {
            this.arr.push(element);
            this.size++;
            this.arr.sort((a, b) => a - b);
        },
        remove(index) {
            if (index >= 0 && index < this.size) {
                this.arr.splice(index, 1);
                this.size--;
            }
        },
        get(index) {
            if (index >= 0 && index < this.size) {
                return this.arr[index];
            }
        },
    };
}

const list = createSortedList();

list.add(5);
list.add(6);
list.add(7);

console.log(list.get(1));
list.remove(1);
console.log(list.get(1));
console.log(list.size);
console.log(list.arr);
