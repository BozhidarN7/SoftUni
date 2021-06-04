function solve() {
    const toSelector = document.querySelector('#selectMenuTo');
    const inputEl = document.querySelector('#input');
    const button = document.querySelector('button');
    const resultEl = document.querySelector('#result');

    toSelector.children[0].value = 'binary';
    toSelector.children[0].textContent = 'Binary';
    toSelector.innerHTML += '<option value="hexadecimal">Hexadecimal</option>';

    button.addEventListener('click', () => {
        if (toSelector.value === 'binary') {
            const number = Number(inputEl.value);
            console.log(number);
            resultEl.value = number.toString(2);
        } else if (toSelector.value === 'hexadecimal') {
            resultEl.value = Number(inputEl.value).toString(16).toUpperCase();
        }
    });
}
