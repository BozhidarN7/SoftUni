function validate() {
    const emailField = document.querySelector('#email');
    const pattern = /[a-z]+@[a-z]+\.[a-z]+/g;

    emailField.addEventListener('change', () => {
        if (!emailField.value.match(pattern)) {
            emailField.classList.add('error');
        } else {
            emailField.classList.remove('error');
        }
    });
}
