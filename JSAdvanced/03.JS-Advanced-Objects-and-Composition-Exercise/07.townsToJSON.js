function solve(input) {
    function clearStart(str) {
        return str.slice(str.indexOf(' ') + 1);
    }

    function clearEnd(str) {
        return str.substring(0, str.indexOf(' '));
    }

    let [town, latitude, longitude] = input[0].split(' | ');
    town = clearStart(town);
    longitude = clearEnd(longitude);

    const result = input.slice(1).reduce((arr, el) => {
        let [city, lat, lng] = el.split(' | ');
        city = clearStart(city);
        lng = clearEnd(lng);

        lat = Math.round((Number(lat) + Number.EPSILON) * 100) / 100;
        lng = Math.round((Number(lng) + Number.EPSILON) * 100) / 100;

        const obj = {};
        obj[`${town}`] = city;
        obj[`${latitude}`] = lat;
        obj[`${longitude}`] = lng;
        arr.push(obj);
        return arr;
    }, []);

    console.log(JSON.stringify(result));
}

solve([
    '| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |',
]);
