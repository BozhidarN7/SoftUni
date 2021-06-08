function attachEventsListeners() {
    const convertBtn = document.querySelector('#convert');
    const inputDistance = document.querySelector('#inputDistance');
    const outputDistance = document.querySelector('#outputDistance');
    const inputUnits = document.querySelector('#inputUnits');
    const outputUnits = document.querySelector('#outputUnits');

    const converter = {
        km: {
            toMeters: (value) => value * 1000,
            toOther: (value) => value / 1000,
        },
        m: { toMetres: (value) => value, toOther: (value) => value },
        cm: {
            toMeters: (value) => value * 0.01,
            toOther: (value) => value / 0.01,
        },
        mm: {
            toMeters: (value) => value * 0.001,
            toOther: (value) => value / 0.001,
        },
        mi: {
            toMeters: (value) => value * 1609.34,
            toOther: (value) => value / 1609.34,
        },
        yrd: {
            toMeters: (value) => value * 0.9144,
            toOther: (value) => value / 0.9144,
        },
        ft: {
            toMeters: (value) => value * 0.3048,
            toOther: (value) => value / 0.3048,
        },
        in: {
            toMeters: (value) => value * 0.0254,
            toOther: (value) => value / 0.0254,
        },
    };

    convertBtn.addEventListener('click', () => {
        const number = Number(inputDistance.value);
        const inputUnit = inputUnits.value;
        const outputUnit = outputUnits.value;

        const inMeters = convertInputUnitToMetres(number, inputUnit);
        outputDistance.value = converter[outputUnit]['toOther'](inMeters);
    });

    function convertInputUnitToMetres(number, inputUnit) {
        return converter[inputUnit]['toMeters'](number);
    }
}
