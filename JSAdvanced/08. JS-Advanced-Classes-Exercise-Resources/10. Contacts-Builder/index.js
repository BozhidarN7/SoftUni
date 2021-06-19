class Contact {
    constructor(firstName, lastName, phone, email) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.email = email;
        this.isOnline = false;
    }

    render(id) {
        const parent = document.getElementById(id);

        const articleEl = document.createElement('article');

        const titleDiv = document.createElement('div');
        titleDiv.classList.add('title');
        titleDiv.textContent = `${this.firstName} ${this.lastName}`;
        if (this.online) {
            titleDiv.classList.add('online');
        }

        const buttonEl = document.createElement('button');
        buttonEl.textContent = '\u2139';
        buttonEl.addEventListener('click', this._showInfo.bind(this));

        titleDiv.appendChild(buttonEl);

        const infoDiv = document.createElement('div');
        infoDiv.style.display = 'none';
        infoDiv.classList.add('info');

        const phoneSpan = document.createElement('span');
        phoneSpan.textContent = '\u260E' + ` ${this.phone}`;

        const emailSpan = document.createElement('span');
        emailSpan.textContent = '\u2709' + ` ${this.email}`;

        infoDiv.appendChild(phoneSpan);
        infoDiv.appendChild(emailSpan);

        articleEl.appendChild(titleDiv);
        articleEl.appendChild(infoDiv);

        parent.appendChild(articleEl);
    }

    _showInfo(e) {
        if (
            e.target.parentElement.nextElementSibling.style.display === 'none'
        ) {
            e.target.parentElement.nextElementSibling.style.display = 'block';
        } else {
            e.target.parentElement.nextElementSibling.style.display = 'none';
        }
    }

    set online(value) {
        this.isOnline = value;
        const titleDiv = Array.from(document.querySelectorAll('.title')).filter(
            (x) =>
                x.childNodes[0].textContent ===
                `${this.firstName} ${this.lastName}`
        )[0];

        if (!titleDiv) return;

        if (this.isOnline) {
            titleDiv.classList.add('online');
        } else {
            titleDiv.classList.remove('online');
        }
    }
    get online() {
        return this.isOnline;
    }
}

const contacts = [
    new Contact('Ivan', 'Ivanov', '0888 123 456', 'i.ivanov@gmail.com'),
    new Contact('Maria', 'Petrova', '0899 987 654', 'mar4eto@abv.bg'),
    new Contact('Jordan', 'Kirov', '0988 456 789', 'jordk@gmail.com'),
];
contacts.forEach((c) => c.render('main'));

setTimeout(() => (contacts[1].online = true), 2000);
