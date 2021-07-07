function attachEvents() {
    const submitButton = document.querySelector('#submit');
    const locationField = document.querySelector('#location');
    const forecastsDiv = document.querySelector('#forecast');
    const currentDiv = document.querySelector('#current');
    const upcomingDiv = document.querySelector('#upcoming');

    submitButton.addEventListener('click', getWeather);

    function getWeather() {
        const locationUrl = `http://localhost:3030/jsonstore/forecaster/locations`;
        fetch(locationUrl)
            .then((response) => response.json())
            .then((locations) => {
                const location = locations.find(
                    (curr) => curr.name === locationField.value
                );
                return location?.code;
            })
            .then((code) => {
                const conditionsObj = {
                    'Sunny': '☀',
                    'Partly sunny': '⛅',
                    'Overcast': '☁',
                    'Rain': '☂',
                };

                const todayForecasterUrl = `http://localhost:3030/jsonstore/forecaster/today/${code}`;
                fetch(todayForecasterUrl)
                    .then((response) => response.json())
                    .then((forecast) => {
                        Array.from(currentDiv.children).forEach((child) =>
                            child.remove()
                        );

                        forecastsDiv.style.display = 'block';
                        const forecastDiv = document.createElement('div');
                        forecastDiv.classList.add('forecasts');

                        const conditionSymbolSpan =
                            document.createElement('span');
                        conditionSymbolSpan.classList.add('condition');
                        conditionSymbolSpan.classList.add('symbol');
                        conditionSymbolSpan.textContent =
                            conditionsObj[forecast.forecast.condition];

                        const wrapperConditionSpan =
                            document.createElement('span');
                        wrapperConditionSpan.classList.add('condition');

                        const citySpan = document.createElement('span');
                        citySpan.textContent = forecast.name;
                        citySpan.classList.add('forecast-data');

                        const degreeSpan = document.createElement('span');
                        degreeSpan.textContent = `${forecast.forecast.low}°/${forecast.forecast.high}°`;
                        degreeSpan.classList.add('forecast-data');

                        const conditionSpan = document.createElement('span');
                        conditionSpan.textContent = forecast.forecast.condition;
                        conditionSpan.classList.add('forecast-data');

                        wrapperConditionSpan.appendChild(citySpan);
                        wrapperConditionSpan.appendChild(degreeSpan);
                        wrapperConditionSpan.appendChild(conditionSpan);

                        forecastDiv.appendChild(conditionSymbolSpan);
                        forecastDiv.appendChild(wrapperConditionSpan);

                        currentDiv.appendChild(forecastDiv);
                    })
                    .catch((error) => {
                        forecastsDiv.style.display = 'block';
                        forecastsDiv.textContent = 'Error';
                    });

                const upcomingForecastUrl = `http://localhost:3030/jsonstore/forecaster/upcoming/${code}`;
                fetch(upcomingForecastUrl)
                    .then((response) => response.json())
                    .then((forecast) => {
                        Array.from(upcomingDiv.children).forEach((child) =>
                            child.remove()
                        );

                        const forecastDiv = document.createElement('div');
                        forecastDiv.classList.add('forecast-info');
                        forecast.forecast.forEach((day) => {
                            const wrapperConditionSpan =
                                document.createElement('span');
                            wrapperConditionSpan.classList.add('upcoming');

                            const conditionSymbolSpan =
                                document.createElement('span');
                            conditionSymbolSpan.classList.add('symbol');
                            conditionSymbolSpan.textContent =
                                conditionsObj[day.condition];

                            const degreeSpan = document.createElement('span');
                            degreeSpan.textContent = `${day.low}°/${day.high}°`;
                            degreeSpan.classList.add('forecast-data');

                            const conditionSpan =
                                document.createElement('span');
                            conditionSpan.textContent = day.condition;
                            conditionSpan.classList.add('forecast-data');

                            wrapperConditionSpan.appendChild(
                                conditionSymbolSpan
                            );
                            wrapperConditionSpan.appendChild(degreeSpan);
                            wrapperConditionSpan.appendChild(conditionSpan);

                            forecastDiv.appendChild(wrapperConditionSpan);

                            upcomingDiv.appendChild(forecastDiv);
                        });
                    })
                    .catch((error) => {
                        forecastsDiv.style.display = 'block';
                        forecastsDiv.textContent = 'Error';
                    });
            })
            .catch((error) => {
                forecastsDiv.style.display = 'block';
                forecastsDiv.textContent = 'Error';
            });
    }
}

attachEvents();
