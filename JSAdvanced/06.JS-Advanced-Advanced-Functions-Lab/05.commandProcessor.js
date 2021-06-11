function solve() {
    let resultStr = '';

    return {
        append(inputStr) {
            resultStr += inputStr;
        },
        removeStart(n) {
            resultStr = resultStr.replace(resultStr.slice(0, n), '');
        },
        removeEnd(n) {
            resultStr = resultStr.replace(resultStr.slice(-n), '');
        },
        print() {
            console.log(resultStr);
        },
    };
}

const firstZeroTest = solve();
firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();
