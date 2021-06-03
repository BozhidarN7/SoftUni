function sumTable() {
    const tdEl = document.querySelectorAll('td');
    const sumEl = tdEl[tdEl.length - 1];
    let sum = 0;
    for (const el of Array.from(tdEl).slice(0, tdEl.length - 1)) {
        if (Number(el.textContent)) {
            sum += Number(el.textContent);
        }
    }

    sumEl.textContent = sum;
}
