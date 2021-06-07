function attachEventsListeners() {
    const divEls = document.querySelectorAll('div');
    const daysBtn = document.querySelector('#daysBtn');
    const hoursBtn = document.querySelector('#hoursBtn');
    const minutesBtn = document.querySelector('#minutesBtn');
    const secondsBtn = document.querySelector('#secondsBtn');

    const converter = {
        Days: function (value, unit) {
            if (unit === 'Hours') return value / 24;
            if (unit === 'Minutes') return value / 60 / 24;
            if (unit === 'Seconds') return value / 60 / 60 / 24;
        },
        Hours: function (value, unit) {
            if (unit === 'Days') return value * 24;
            if (unit === 'Minutes') return value / 60;
            if (unit === 'Seconds') return value / 60 / 60;
        },
        Minutes: function (value, unit) {
            if (unit === 'Days') return value * 24 * 60;
            if (unit === 'Hours') return value * 60;
            if (unit === 'Seconds') return value / 60;
        },
        Seconds: function (value, unit) {
            if (unit === 'Days') return value * 24 * 60 * 60;
            if (unit === 'Hours') return value * 60 * 60;
            if (unit === 'Minutes') return value * 60;
        },
    };

    daysBtn.addEventListener('click', () => {
        const inputField =
            daysBtn.parentElement.querySelector('input[type="text"]');
        convert('Days', Number(inputField.value));
    });
    hoursBtn.addEventListener('click', () => {
        const inputField =
            hoursBtn.parentElement.querySelector('input[type="text"]');
        convert('Hours', Number(inputField.value));
    });

    minutesBtn.addEventListener('click', () => {
        const inputField =
            minutesBtn.parentElement.querySelector('input[type="text"]');
        convert('Minutes', Number(inputField.value));
    });
    secondsBtn.addEventListener('click', () => {
        const inputField =
            secondsBtn.parentElement.querySelector('input[type="text"]');
        convert('Seconds', Number(inputField.value));
    });

    function convert(fieldName, value) {
        Array.from(divEls).forEach((div) => {
            const label = div.querySelector('label');
            const labelText = label.textContent;
            const unit = labelText.substring(0, labelText.indexOf(':'));
            const input = div.querySelector('input[type="text"]');
            if (fieldName !== unit) {
                input.value = converter[unit](value, fieldName);
            }
        });
    }
}
