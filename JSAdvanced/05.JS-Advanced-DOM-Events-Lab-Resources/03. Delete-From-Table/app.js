function deleteByEmail() {
    const inputField = document.querySelector('input');
    const resultDiv = document.querySelector('#result');
    const tableRows = document.querySelectorAll('tbody tr');

    const email = inputField.value;
    let deleted = false;
    Array.from(tableRows).forEach((row) => {
        if (row.textContent.includes(email)) {
            row.remove();
            resultDiv.textContent = 'Deleted';
            deleted = true;
        }
    });
    if (deleted) {
        return;
    }
    resultDiv.textContent = 'Not found.';
}
