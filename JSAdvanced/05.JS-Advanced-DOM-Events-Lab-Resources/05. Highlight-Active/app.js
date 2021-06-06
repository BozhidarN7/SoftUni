function focused() {
    const inputEls = document.querySelectorAll('input');

    Array.from(inputEls).forEach((input) => {
        input.addEventListener('focus', () => {
            input.parentNode.classList.add('focused');
        });
        input.addEventListener('blur', () => {
            input.parentNode.classList.remove('focused');
        });
    });
}
