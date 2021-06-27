window.addEventListener('load', solution);

function solution() {
    const nameField = document.querySelector('#fname');
    const emailField = document.querySelector('#email');
    const phoneField = document.querySelector('#phone');
    const addressField = document.querySelector('#address');
    const postCodeField = document.querySelector('#code');
    const submitBtn = document.querySelector('#submitBTN');
    const editBtn = document.querySelector('#editBTN');
    const continueBtn = document.querySelector('#continueBTN');
    const ulPreview = document.querySelector('#infoPreview');
    const blockDiv = document.querySelector('#block');

    submitBtn.addEventListener('click', (e) => {
        const fullName = nameField.value;
        const email = emailField.value;
        const phone = phoneField.value;
        const address = addressField.value;
        const code = postCodeField.value;

        if (!email || !fullName) {
            return;
        }

        const liName = document.createElement('li');
        liName.textContent = `Full Name: ${fullName}`;

        const liEmail = document.createElement('li');
        liEmail.textContent = `Email: ${email}`;

        const liPhone = document.createElement('li');
        liPhone.textContent = `Phone Number: ${phone}`;

        const liAddress = document.createElement('li');
        liAddress.textContent = `Address: ${address}`;

        const liCode = document.createElement('li');
        liCode.textContent = `Postal Code: ${code}`;

        ulPreview.appendChild(liName);
        ulPreview.appendChild(liEmail);
        ulPreview.appendChild(liPhone);
        ulPreview.appendChild(liAddress);
        ulPreview.appendChild(liCode);

        nameField.value = '';
        emailField.value = '';
        phoneField.value = '';
        addressField.value = '';
        postCodeField.value = '';

        submitBtn.disabled = true;
        editBtn.disabled = false;
        continueBtn.disabled = false;
    });

    editBtn.addEventListener('click', () => {
        nameField.value = ulPreview.children[0].textContent.split(':')[1];
        emailField.value = ulPreview.children[1].textContent.split(':')[1];
        phoneField.value = Number(
            ulPreview.children[2].textContent.split(':')[1]
        );
        addressField.value = ulPreview.children[3].textContent.split(':')[1];
        postCodeField.value = Number(
            ulPreview.children[4].textContent.split(':')[1]
        );

        submitBtn.disabled = false;
        editBtn.disabled = true;
        continueBtn.disabled = true;

        Array.from(ulPreview.children).forEach((li) => li.remove());
    });

    continueBtn.addEventListener('click', () => {
        blockDiv.innerHTML = '';
        const heading = document.createElement('h3');
        heading.textContent = 'Thank you for your reservation!';

        blockDiv.appendChild(heading);
    });
}
