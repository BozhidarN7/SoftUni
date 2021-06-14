function validate() {
    const usernameField = document.querySelector('#username');
    const emailField = document.querySelector('#email');
    const passwordField = document.querySelector('#password');
    const confirmPasswordField = document.querySelector('#confirm-password');
    const companyNumberField = document.querySelector('#companyNumber');
    const companyCheckbox = document.querySelector('#company');
    const submitBtn = document.querySelector('#submit');
    const companyFieldset = document.querySelector('#companyInfo');
    const validDiv = document.querySelector('#valid');

    companyCheckbox.addEventListener('change', () => {
        if (companyCheckbox.checked) {
            companyFieldset.style.display = 'block';
        } else {
            companyFieldset.style.display = 'none';
        }
    });

    submitBtn.addEventListener('click', (e) => {
        e.preventDefault();
        let hasInvalidField = false;
        if (!isUsernameValid()) {
            usernameField.style.borderColor = 'red';
            hasInvalidField = true;
        } else {
            usernameField.style.borderColor = '';
        }

        if (!isEmailValid()) {
            emailField.style.borderColor = 'red';
            hasInvalidField = true;
        } else {
            emailField.style.borderColor = '';
        }

        if (!isPasswordValid()) {
            passwordField.style.borderColor = 'red';
            confirmPasswordField.style.borderColor = 'red';
            hasInvalidField = true;
        } else {
            passwordField.style.borderColor = '';
            confirmPasswordField.style.borderColor = '';
        }

        if (companyCheckbox.checked && !isCompanyNumberValid()) {
            companyNumberField.style.borderColor = 'red';
            hasInvalidField = true;
        } else {
            companyNumberField.style.borderColor = '';
        }

        if (!hasInvalidField) {
            validDiv.style.display = 'block';
        } else {
            validDiv.style.display = 'none';
        }
    });

    function isUsernameValid() {
        const username = usernameField.value;
        const pattern = /\b([a-zA-Z0-9]{3,20})\b/;
        if (!username.match(pattern)) {
            return false;
        }
        return true;
    }

    function isPasswordValid() {
        const password = passwordField.value;
        const confirmPassword = confirmPasswordField.value;

        const pattern = /\b([\w]{5,15})\b/;

        if (
            !password.match(pattern) ||
            !confirmPassword.match(pattern) ||
            confirmPassword !== password
        ) {
            return false;
        }
        return true;
    }

    function isEmailValid() {
        const email = emailField.value;
        const indexOfAtSign = email.indexOf('@');
        const indexOfLastDot = email.lastIndexOf('.');

        if (indexOfAtSign === -1 || indexOfAtSign > indexOfLastDot) {
            return false;
        }
        return true;
    }

    function isCompanyNumberValid() {
        const number = Number(companyNumberField.value);

        if (!number || number < 1000 || number > 9999) {
            return false;
        }
        return true;
    }
}
