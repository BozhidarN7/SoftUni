function add(number) {
    let result = number;
    function inner(num) {
        result += num;
        return inner;
    }

    inner.toString = function () {
        return result;
    };

    return inner;
}

console.log(add(1)(6)(-3).toString());
