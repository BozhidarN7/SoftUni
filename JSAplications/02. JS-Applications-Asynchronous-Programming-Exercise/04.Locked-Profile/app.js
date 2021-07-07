function lockedProfile() {
    const mainEl = document.querySelector('#main');

    const url = 'http://localhost:3030/jsonstore/advanced/profiles';
    fetch(url)
        .then((response) => response.json())
        .then((profiles) => {
            let count = 1;
            for (const id in profiles) {
                const profile = profiles[id];
                console.log(profile);

                const profileDiv = document.createElement('div');
                profileDiv.classList.add('profile');

                const img = document.createElement('img');
                img.src = './iconProfile2.png';
                img.classList.add('userIcon');

                const lockLabel = document.createElement('label');
                lockLabel.textContent = 'Lock';

                const lockRadioButton = document.createElement('input');
                lockRadioButton.type = 'radio';
                lockRadioButton.name = `user${count}Locked`;
                lockRadioButton.value = 'lock';
                lockRadioButton.checked = true;

                const unlockLabel = document.createElement('label');
                unlockLabel.textContent = 'Unlock';

                const unlockRadioButton = document.createElement('input');
                unlockRadioButton.type = 'radio';
                unlockRadioButton.name = `user${count}Locked`;
                unlockRadioButton.value = 'unlock';

                const br1 = document.createElement('br');

                const hr1 = document.createElement('hr');

                const usernameLabel = document.createElement('label');
                usernameLabel.textContent = profile.username;

                const usernameField = document.createElement('input');
                usernameField.type = 'text';
                usernameField.name = `user${count}Username`;
                usernameField.value = '';
                usernameField.disabled = true;
                usernameField.readOnly = true;

                const hiddenDiv = document.createElement('div');
                hiddenDiv.id = `user${1}HiddenFields`;

                const hr2 = document.createElement('hr');

                const emailLabel = document.createElement('label');
                emailLabel.textContent = 'Email:';

                const emailField = document.createElement('input');
                emailField.type = 'email';
                emailField.name = `user${count}Email`;
                emailField.value = profile.email;
                emailField.disabled = true;
                emailField.readOnly = true;

                const ageLabel = document.createElement('label');
                ageLabel.textContent = 'Age:';

                const ageField = document.createElement('input');
                ageField.type = 'email';
                ageField.name = `user${count}Age`;
                ageField.value = profile.age;
                ageField.disabled = true;
                ageField.readOnly = true;

                hiddenDiv.appendChild(hr2);
                hiddenDiv.appendChild(emailLabel);
                hiddenDiv.appendChild(emailField);
                hiddenDiv.appendChild(ageLabel);
                hiddenDiv.appendChild(ageField);

                const showMoreBtn = document.createElement('button');
                showMoreBtn.textContent = 'Show more';

                profileDiv.appendChild(img);
                profileDiv.appendChild(lockLabel);
                profileDiv.appendChild(lockRadioButton);
                profileDiv.appendChild(unlockLabel);
                profileDiv.appendChild(unlockRadioButton);
                profileDiv.appendChild(br1);
                profileDiv.appendChild(hr1);
                profileDiv.appendChild(usernameLabel);
                profileDiv.appendChild(usernameField);
                profileDiv.appendChild(hiddenDiv);
                profileDiv.appendChild(showMoreBtn);

                mainEl.appendChild(profileDiv);

                count++;
            }
            const btnEls = document.querySelectorAll('button');

            Array.from(btnEls).forEach((btn) => {
                const profileDiv = btn.parentElement;
                btn.addEventListener('click', () => {
                    const hiddenInfoDiv = profileDiv.querySelector('div');
                    const radioButtons = profileDiv.querySelectorAll(
                        'input[type="radio"]'
                    );
                    if (
                        btn.textContent === 'Show more' &&
                        radioButtons[1].checked
                    ) {
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
        })
        .catch((error) => {
            window.alert('Error');
        });
}
