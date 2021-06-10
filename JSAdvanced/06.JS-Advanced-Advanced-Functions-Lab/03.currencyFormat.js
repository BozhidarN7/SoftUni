function createFormatter(seperator, symbol, symbolFirst, formatter) {
    return (value) => {
        return formatter(seperator, symbol, symbolFirst, value);
    };
}

function currencyFormatter(seperator, symbol, symbolFirst, value) {
    let result = Math.trunc(value) + seperator;
    result += value.toFixed(2).substr(-2, 2);
    if (symbolFirst) return symbol + ' ' + result;
    else return result + ' ' + symbol;
}

const dollarFormatter = createFormatter(',', '$', true, currencyFormatter);
console.log(dollarFormatter(5435));
console.log(dollarFormatter(3.1429));
console.log(dollarFormatter(2.709));
