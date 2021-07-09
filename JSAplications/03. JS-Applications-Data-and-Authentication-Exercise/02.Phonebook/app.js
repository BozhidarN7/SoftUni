function attachEvents() {
    const loadBtn = document.querySelector('#btnLoad');
    const createBtn = document.querySelector('#btnCreate');
    const phoneField = document.querySelector('#phone');
    const personField = document.querySelector('#person');
    const phoneBookEl = document.querySelector('#phonebook');

    const baseUrl = 'http://localhost:3030/jsonstore/phonebook';

    createBtn.addEventListener('click', async () => {
        const phone = phoneField.value;
        const person = personField.value;

        if (!phone || !person) {
            return;
        }

        const data = await (
            await fetch(`${baseUrl}`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    person,
                    phone,
                }),
            })
        ).json();

        phoneField.value = '';
        personField.value = '';
    });

    loadBtn.addEventListener('click', async () => {
        Array.from(phoneBookEl.children).forEach((li) => li.remove());

        const data = await (await fetch(baseUrl)).json();

        Object.keys(data).forEach((id) => {
            const phoneEntry = data[id];

            const liEl = document.createElement('li');
            liEl.textContent = `${phoneEntry.person}: ${phoneEntry.phone}`;

            const deleteBtn = document.createElement('button');
            deleteBtn.textContent = 'Delete';
            deleteBtn.addEventListener('click', deletePhoneEntry);

            liEl.appendChild(deleteBtn);

            phoneBookEl.appendChild(liEl);
        });
    });

    async function deletePhoneEntry(e) {
        const data = await (await fetch(baseUrl)).json();
        for (const id in data) {
            if (
                data[id].person ===
                e.target.parentElement.textContent.split(': ')[0]
            ) {
                const res = await fetch(`${baseUrl}/${id}`, {
                    method: 'DELETE',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                });
            }
        }
    }
}

attachEvents();
