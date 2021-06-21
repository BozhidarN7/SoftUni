(function solve() {
    String.prototype.ensureStart = function (str) {
        if (!this.startsWith(str)) {
            return str + this.toString();
        }
        return this.toString();
    };

    String.prototype.ensureEnd = function (str) {
        if (!this.endsWith(str)) {
            return this.toString() + str;
        }
        return this.toString();
    };

    String.prototype.isEmpty = function () {
        return this.length === 0;
    };

    String.prototype.truncate = function (n) {
        if (this.length <= n) {
            return this.toString();
        }
        if (n < 4) {
            return new Array(n).fill('.').join('');
        }
        if (!this.includes(' ')) {
            return this.slice(0, n - 3) + '...';
        }
        const cur = this.split(' ').slice(0, -1).join(' ') + '...';
        return cur.truncate(n);
    };

    String.format = function (string, ...params) {
        const pattern = /{[0-9]+}/;
        let matches = string.match(pattern);
        while (matches) {
            if (!params[Number(matches[0][1])]) break;

            string = string.replace(matches[0], params[Number(matches[0][1])]);
            matches = string.match(pattern);
        }
        return string;
    };
})();

let str = 'I am computer programmer';
console.log(str.isEmpty());

let str2 = '';
console.log(str2.isEmpty());

str2 = str2.ensureStart('programmer');
console.log(str2);

str = str.truncate(5);
console.log(str);

str = str.truncate(1);
console.log(str);
