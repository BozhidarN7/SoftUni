function addItem() {
    const list = document.querySelector('#items');
    const inputField = document.querySelector('#newItemText');

    const newLi = document.createElement('li');
    newLi.textContent = inputField.value;

    list.appendChild(newLi);
}
