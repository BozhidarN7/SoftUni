function solve() {
    const departButton = document.querySelector('#depart');
    const arriveButton = document.querySelector('#arrive');
    const infoSpan = document.querySelector('#info .info');

    let stopId = 'depot';
    let baseUrl = `http://localhost:3030/jsonstore/bus/schedule/`;
    function depart() {
        const nextStopUrl = baseUrl + stopId;
        fetch(nextStopUrl)
            .then((response) => response.json())
            .then((stop) => {
                departButton.disabled = true;
                infoSpan.textContent = `Next stop ${stop.name}`;
                stopId = stop.next;
                arriveButton.disabled = false;
            })
            .catch((error) => {
                infoSpan.textContent = 'Error';
                arriveButton.disabled = true;
                departButton.disabled = true;
            });
    }

    function arrive() {
        const nextStopUrl = baseUrl + stopId;
        fetch(nextStopUrl)
            .then((response) => response.json())
            .then((stop) => {
                arriveButton.disabled = true;
                departButton.disabled = false;
                infoSpan.textContent = `Arriving at ${stop.name}`;
                stopId = stop.next;
            })
            .catch((error) => {
                infoSpan.textContent = 'Error';
                arriveButton.disabled = true;
                departButton.disabled = true;
            });
    }

    return {
        depart,
        arrive,
    };
}

let result = solve();
