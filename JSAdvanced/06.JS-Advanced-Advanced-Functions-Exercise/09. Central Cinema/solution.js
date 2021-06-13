function solve() {
    const [nameField, hallField, priceField] =
        document.querySelectorAll('#container input');
    const onScreenBtn = document.querySelector('#container button');
    const onScreenUlEl = document.querySelector('#movies ul');
    const archiveUlEl = document.querySelector('#archive ul');
    const clearBtn = document.querySelector('#archive button:last-of-type');

    onScreenBtn.addEventListener('click', addMovieOnScreen);

    function addMovieOnScreen(e) {
        e.preventDefault();

        const name = nameField.value;
        const hall = hallField.value;
        const ticketPrice = Number(priceField.value);

        nameField.value = '';
        hallField.value = '';
        priceField.value = '';

        if (!name || !hall || !ticketPrice) return;

        const liEl = document.createElement('li');
        const spanTitle = document.createElement('span');
        const strongHall = document.createElement('strong');

        spanTitle.textContent = name;
        strongHall.textContent = `Hall: ${hall}`;

        const divEl = document.createElement('div');
        const strongPrice = document.createElement('strong');
        const inputTickets = document.createElement('input');
        const buttonArchive = document.createElement('button');

        strongPrice.textContent = ticketPrice.toFixed(2);
        inputTickets.setAttribute('placeholder', 'Tickets Sold');
        buttonArchive.textContent = 'Archive';
        buttonArchive.addEventListener('click', addToArchive);

        divEl.appendChild(strongPrice);
        divEl.appendChild(inputTickets);
        divEl.appendChild(buttonArchive);

        liEl.appendChild(spanTitle);
        liEl.appendChild(strongHall);
        liEl.appendChild(divEl);

        onScreenUlEl.appendChild(liEl);
    }

    function addToArchive(e) {
        let ticketsCount = e.target.previousElementSibling.value;
        if (Number.isNaN(Number(ticketsCount)) || ticketsCount.trim() === '')
            return;

        ticketsCount = Number(ticketsCount);
        archiveUlEl.appendChild(e.target.parentElement.parentElement);

        const ticketsPrice = Number(
            e.target.parentElement.children[0].textContent
        );
        e.target.parentElement.parentElement.children[1].textContent = `Total amount: ${(
            ticketsCount * ticketsPrice
        ).toFixed(2)}`;

        const btnDelete = document.createElement('button');
        btnDelete.textContent = 'Delete';
        btnDelete.addEventListener('click', deleteFromArchive);

        e.target.parentElement.parentElement.appendChild(btnDelete);

        e.target.parentElement.remove();
    }

    function deleteFromArchive(e) {
        e.target.parentElement.remove();
    }

    clearBtn.addEventListener('click', (e) => {
        Array.from(e.target.parentElement.children[1].children).forEach((li) =>
            li.remove()
        );
    });
}
