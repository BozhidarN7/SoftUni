function attachEvents() {
    const submitBtn = document.querySelector('#submit');
    const refreshBtn = document.querySelector('#refresh');
    const nameField = document.querySelector('input[name="author"]');
    const messageField = document.querySelector('input[name="content"]');
    const textAreaEl = document.querySelector('#messages');

    submitBtn.addEventListener('click', (e) => {
        const author = nameField.value;
        const content = messageField.value;

        if (!author || !content) {
            return;
        }

        fetch('http://localhost:3030/jsonstore/messenger', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                author,
                content,
            }),
        })
            .then((response) => response.json())
            .then((data) => console.log(data))
            .catch((error) => console.log(error));
    });

    refreshBtn.addEventListener('click', () => {
        fetch('http://localhost:3030/jsonstore/messenger')
            .then((response) => response.json())
            .then((data) => {
                console.log(data);
                Object.keys(data).forEach((id) => {
                    const message = data[id];
                    textAreaEl.value += `${message.author}: ${message.content}\n`;
                });
            })
            .catch((error) => console.log(error));
    });
}

attachEvents();
