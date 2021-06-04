function subtract() {
    const firstNumberEl = document.querySelector('#firstNumber');
    const secondNumberEl = document.querySelector('#secondNumber');
    const resultEl = document.querySelector('#result');

    resultEl.textContent =
        Number(firstNumberEl.value) - Number(secondNumberEl.value);
}
