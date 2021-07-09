const formEl = document.querySelector('form');
const tableEl = document.querySelector('#results');

const baseUrl = 'http://localhost:3030/jsonstore/collections/students';

formEl.addEventListener('submit', (e) => {
    e.preventDefault();

    const data = new FormData(e.currentTarget);
    const firstName = data.get('firstName');
    const lastName = data.get('lastName');
    const facultyNumber = data.get('facultyNumber');
    const grade = Number(data.get('grade'));

    if (!firstName || !lastName || !facultyNumber || !grade) {
        return;
    }

    fetch(baseUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/josn',
        },
        body: JSON.stringify({
            firstName,
            lastName,
            facultyNumber,
            grade,
        }),
    })
        .then((response) => response.json())
        .then((entry) => {
            const trEl = document.createElement('tr');

            const thFirstName = document.createElement('th');
            thFirstName.textContent = entry.firstName;

            const thLastName = document.createElement('th');
            thLastName.textContent = entry.lastName;

            const thFaculyNumber = document.createElement('th');
            thFaculyNumber.textContent = entry.facultyNumber;

            const thGrade = document.createElement('th');
            thGrade.textContent = entry.grade;

            trEl.appendChild(thFirstName);
            trEl.appendChild(thLastName);
            trEl.appendChild(thFaculyNumber);
            trEl.appendChild(thGrade);

            tableEl.appendChild(trEl);
        })
        .catch((error) => console.log(error));
});

window.addEventListener('load', () => {
    fetch(baseUrl)
        .then((response) => response.json())
        .then((entries) => {
            Object.keys(entries).forEach((id) => {
                createEntry(entries[id]);
            });
        })
        .catch((error) => console.log(error));
});

function createEntry(entry) {
    const trEl = document.createElement('tr');

    const thFirstName = document.createElement('th');
    thFirstName.textContent = entry.firstName;

    const thLastName = document.createElement('th');
    thLastName.textContent = entry.lastName;

    const thFaculyNumber = document.createElement('th');
    thFaculyNumber.textContent = entry.facultyNumber;

    const thGrade = document.createElement('th');
    thGrade.textContent = entry.grade;

    trEl.appendChild(thFirstName);
    trEl.appendChild(thLastName);
    trEl.appendChild(thFaculyNumber);
    trEl.appendChild(thGrade);

    tableEl.querySelector('tbody').appendChild(trEl);
}
