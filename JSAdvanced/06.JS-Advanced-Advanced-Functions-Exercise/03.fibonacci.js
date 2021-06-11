function getFibonator() {
    let count = 1;
    let fibNum1 = 0;
    let fibNum2 = 1;
    let nextFibNum = 1;
    return () => {
        if (!fibNum1 && count) {
            count--;
            return 1;
        }

        nextFibNum = fibNum1 + fibNum2;
        fibNum1 = fibNum2;
        fibNum2 = nextFibNum;
        return nextFibNum;
    };
}

const fib = getFibonator();
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
