function generateReport() {
    const checkboxEls = document.querySelectorAll('input');
    const textarea = document.querySelector('#output');
    const result = [];
    Array.from(document.querySelectorAll('tbody tr')).forEach((row) => {
        const obj = {};
        Array.from(row.children).forEach((col, i) => {
            if (checkboxEls[i].checked) {
                obj[checkboxEls[i].name] = col.textContent;
            }
        });
        result.push(obj);
    });
    console.log(result);
    textarea.textContent = JSON.stringify(result);
}
