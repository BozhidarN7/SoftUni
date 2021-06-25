function solution() {
    const giftNameField = document.querySelector(
        '.card:nth-of-type(1) input[type="text"]'
    );
    const addGiftBtn = document.querySelector('.card:nth-of-type(1) button');

    addGiftBtn.addEventListener('click', (e) => {
        const liEl = document.createElement('li');
        liEl.classList.add('gift');

        liEl.textContent = giftNameField.value;

        const sendBtn = document.createElement('button');
        sendBtn.setAttribute('id', 'sendButton');
        sendBtn.textContent = 'Send';
        sendBtn.addEventListener('click', moveGift.bind(sendBtn, 3));

        const discardBtn = document.createElement('button');
        discardBtn.setAttribute('id', 'discardButton');
        discardBtn.textContent = 'Discard';
        discardBtn.addEventListener('click', moveGift.bind(discardBtn, 4));

        liEl.appendChild(sendBtn);
        liEl.appendChild(discardBtn);

        ulEl = document.querySelector('.card:nth-of-type(2) ul');
        ulEl.appendChild(liEl);

        const sorted = Array.from(ulEl.children).sort((a, b) =>
            a.textContent.localeCompare(b.textContent)
        );

        Array.from(ulEl.children).forEach((li) => li.remove());
        sorted.forEach((li) => ulEl.appendChild(li));

        giftNameField.value = '';
    });

    function moveGift(type) {
        const liEl = this.parentElement;
        Array.from(liEl.children).forEach((child) => child.remove());

        const newLiEl = document.createElement('li');
        newLiEl.textContent = liEl.textContent;

        liEl.remove();

        document
            .querySelector(`.card:nth-of-type(${type}) ul`)
            .appendChild(newLiEl);
    }
}
