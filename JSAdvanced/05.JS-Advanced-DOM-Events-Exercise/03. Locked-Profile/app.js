function lockedProfile() {
    const btnEls = document.querySelectorAll('button');

    Array.from(btnEls).forEach((btn) => {
        const profileDiv = btn.parentElement;
        btn.addEventListener('click', () => {
            const hiddenInfoDiv = profileDiv.querySelector('div');
            const radioButtons = profileDiv.querySelectorAll(
                'input[type="radio"]'
            );
            if (btn.textContent === 'Show more' && radioButtons[1].checked) {
                hiddenInfoDiv.style.display = 'block';
                btn.textContent = 'Hide it';
            } else if (
                btn.textContent === 'Hide it' &&
                radioButtons[1].checked
            ) {
                hiddenInfoDiv.style.display = 'none';
                btn.textContent = 'Show more';
            }
        });
    });
}
