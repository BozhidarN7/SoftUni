function getInfo() {
    const inputField = document.querySelector('#stopId');
    const busesUl = document.querySelector('#buses');
    const stopNameDiv = document.querySelector('#stopName');

    const url = `http://localhost:3030/jsonstore/bus/businfo/${inputField.value}`;
    fetch(url)
        .then((response) => response.json())
        .then((busStops) => {
            Array.from(busesUl.children).forEach((li) => li.remove());

            Object.keys(busStops).forEach((stopId) => {
                const buses = busStops[stopId];
                stopNameDiv.textContent = busStops.name;
                for (const bus in buses) {
                    const liEl = document.createElement('li');
                    liEl.textContent = `Bus ${bus} arrives in ${buses[bus]} time`;
                    busesUl.appendChild(liEl);
                }
            });
        })
        .catch((error) => {
            Array.from(busesUl.children).forEach((li) => li.remove());
            stopNameDiv.textContent = 'Error';
        });
}
