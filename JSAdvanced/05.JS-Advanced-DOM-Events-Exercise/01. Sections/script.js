function create(words) {
    const contentDiv = document.querySelector('#content');
    words.forEach((word) => {
        const innerDiv = document.createElement('div');
        const paragraph = document.createElement('p');
        paragraph.textContent = word;
        paragraph.style.display = 'none';
        innerDiv.appendChild(paragraph);
        contentDiv.appendChild(innerDiv);
        innerDiv.addEventListener('click', (e) => {
            e.target.children[0].style.display = 'block';
        });
    });
}
