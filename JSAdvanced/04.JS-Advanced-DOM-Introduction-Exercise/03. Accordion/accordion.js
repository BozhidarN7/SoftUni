function toggle() {
    const buttonEl = document.querySelector('.button');
    const extraDiv = document.querySelector('#extra');

    if (extraDiv.style.display === 'none') {
        extraDiv.style.display = 'block';
        buttonEl.textContent = 'Less';
    } else {
        extraDiv.style.display = 'none';
        buttonEl.textContent = 'More';
    }
}
