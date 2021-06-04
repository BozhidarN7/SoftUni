function solve() {
    const inputEl = document.querySelector('#input');
    const outputEl = document.querySelector('#output');

    let paragraph = '<p>';
    inputEl.value
        .split('.')
        .filter((p) => p.trim().length > 0)
        .forEach((sentence, i, arr) => {
            paragraph += `${sentence}.`;

            if ((i + 1) % 3 === 0 || i === arr.length - 1) {
                paragraph += '</p>';
                outputEl.insertAdjacentHTML('beforeend', paragraph);
                paragraph = '<p>';
            }
        });
}
