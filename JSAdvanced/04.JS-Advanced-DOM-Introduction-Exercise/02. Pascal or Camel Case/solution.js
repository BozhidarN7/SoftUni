function solve() {
    const textEl = document.querySelector('#text');
    const namingConventionEl = document.querySelector('#naming-convention');
    const resultEl = document.querySelector('#result');

    const convention = namingConventionEl.value;
    if (convention !== 'Camel Case' && convention !== 'Pascal Case') {
        resultEl.textContent = 'Error!';
        return;
    }

    let text = textEl.value
        .toLowerCase()
        .split(' ')
        .reduce((acc, word) => {
            const newWord = word[0].toUpperCase() + word.slice(1);
            acc += newWord;
            return acc;
        }, '');
    if (convention === 'Camel Case') {
        text = text[0].toLowerCase() + text.slice(1);
    }

    resultEl.textContent = text;
}
