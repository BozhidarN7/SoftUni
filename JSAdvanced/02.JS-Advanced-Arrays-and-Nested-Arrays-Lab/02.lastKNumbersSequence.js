function solve(n, k) {
    const result = [];
    result.push(1);
    for (let i = 1; i < n; i++) {
        let sum = 0;
        for (let j = 0; j < k; j++) {
            if (i - j - 1 >= 0) {
                sum += result[i - j - 1];
            }
        }
        result.push(sum);
    }

    return result;
}

// solve(6, 3);
solve(8, 2);
