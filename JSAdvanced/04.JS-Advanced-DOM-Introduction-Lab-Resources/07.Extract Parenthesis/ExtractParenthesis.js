function extract(content) {
    const textEl = document.getElementById(content);
    const result = [];
    let text = textEl.textContent;
    for (let i = 0; i < text.length; i++) {
        const first = text.indexOf('(');
        const second = text.indexOf(')');
        result.push(text.substring(first + 1, second));
        text = text.slice(second + 1);
        if (first !== -1) {
            i = 0;
        }
    }

    return result.join('; ');
}
