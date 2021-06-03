function colorize() {
    const trEl = document.getElementsByTagName('tr');
    console.log(trEl);
    let index = 0;
    for (const el of Array.from(trEl)) {
        if (index % 2) {
            el.style.backgroundColor = 'teal';
        }
        index++;
    }
}
