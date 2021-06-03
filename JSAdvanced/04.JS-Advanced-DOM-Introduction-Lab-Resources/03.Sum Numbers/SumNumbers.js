function calc() {
    const num1El = document.querySelector('#num1');
    const num2El = document.querySelector('#num2');
    const sumEl = document.querySelector('#sum');

    sumEl.value = Number(num1El.value) + Number(num2El.value);
}
