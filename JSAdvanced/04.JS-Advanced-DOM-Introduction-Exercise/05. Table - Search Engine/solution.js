function solve() {
    document.querySelector('#searchBtn').addEventListener('click', onClick);
    const searchField = document.querySelector('#searchField');
    const rowEls = document.querySelectorAll('tbody > tr');
    function onClick() {
        Array.from(rowEls).forEach((row) => row.classList.remove('select'));
        Array.from(rowEls).forEach((row) => {
            if (row.textContent.includes(searchField.value)) {
                row.classList.add('select');
            }
        });
        searchField.value = '';
    }
}
