function addItem() {
    const list = document.querySelector('#items');
    const inputField = document.querySelector('#newItemText');

    const newLi = document.createElement('li');
    newLi.textContent = inputField.value;

    const deleteButton = document.createElement('a');
    deleteButton.textContent = '[Delete]';
    deleteButton.setAttribute('href', '#');

    newLi.appendChild(deleteButton);
    list.appendChild(newLi);

    deleteButton.addEventListener('click', (e) => {
        e.currentTarget.parentNode.remove();
    });
}
