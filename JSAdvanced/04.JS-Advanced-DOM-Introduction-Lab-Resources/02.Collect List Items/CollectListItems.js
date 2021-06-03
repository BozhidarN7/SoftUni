function extractText() {
    const listEl = document.querySelector('#items');
    const textareaEl = document.querySelector('#result');
    for (const liEl of Array.from(listEl.children)) {
        textareaEl.textContent += liEl.textContent + '\n';
    }
    textareaEl.textContent = textareaEl.textContent.trim();
}
