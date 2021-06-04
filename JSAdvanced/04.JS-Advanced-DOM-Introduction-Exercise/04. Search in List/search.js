function search() {
    const liEls = document.getElementsByTagName('li');
    const searchTextInput = document.querySelector('#searchText');
    const resultEl = document.querySelector('#result');

    let matches = 0;
    Array.from(liEls).forEach((li) => {
        if (li.textContent.includes(searchTextInput.value)) {
            li.style.textDecoration = 'underline';
            li.style.fontWeight = 'bold';
            matches++;
        }
    });

    resultEl.textContent = `${matches} matches found`;
}
