const yearsSection = document.querySelector('#years');

const monthNumber = {
    Jan: 1,
    Feb: 2,
    Mar: 3,
    Apr: 4,
    May: 5,
    Jun: 6,
    Jul: 7,
    Aug: 8,
    Sept: 9,
    Oct: 10,
    Nov: 11,
    Dec: 12,
};

yearsSection.addEventListener('click', (e) => {
    let year = '';
    if (e.target.tagName === 'TD') {
        year = e.target.children[0].textContent;
    } else if (e.target.tagName === 'DIV') {
        year = e.target.textContent;
    }
    const specificYearCection = document.querySelector(`#year-${year}`);
    window.scrollTo(0, specificYearCection.offsetTop);
});

document.querySelectorAll('.monthCalendar').forEach((monthCalendar) => {
    monthCalendar.querySelector('caption').addEventListener('click', () => {
        window.scrollTo(0, yearsSection.offsetTop);
    });
});

document.querySelectorAll('.monthCalendar').forEach((section) =>
    section.addEventListener('click', (e) => {
        const year = e.currentTarget.querySelector('caption').textContent;
        let month = '';
        if (e.target.tagName === 'TD') {
            month = e.target.children[0].textContent;
        } else if (e.target.tagName === 'DIV') {
            month = e.target.textContent;
        }
        const number = monthNumber[month];
        const id = `month-${year}-${number}`;

        window.scrollTo(0, document.querySelector(`#${id}`).offsetTop);
    })
);

document.querySelectorAll('.daysCalendar').forEach((section) => {
    section.querySelector('caption').addEventListener('click', (e) => {
        const year = e.target.textContent.split(' ')[1];
        window.scrollTo(0, document.querySelector(`#year-${year}`).offsetTop);
    });
});
