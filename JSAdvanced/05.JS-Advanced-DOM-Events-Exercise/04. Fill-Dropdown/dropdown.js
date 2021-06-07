function addItem() {
    const selectEl = document.querySelector('#menu');
    const inputText = document.querySelector('#newItemText');
    const inputValue = document.querySelector('#newItemValue');
    const btnEl = document.querySelector('input[type="button"]');

    const text = inputText.value;
    const value = inputValue.value;

    const newOptionEl = document.createElement('option');
    newOptionEl.textContent = text;
    newOptionEl.setAttribute('value', value);
    selectEl.appendChild(newOptionEl);

    inputText.value = '';
    inputValue.value = '';
}
