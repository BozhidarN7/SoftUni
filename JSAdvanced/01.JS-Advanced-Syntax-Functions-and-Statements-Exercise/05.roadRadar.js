function solve(speed, road) {
    if (road === 'motorway' && speed > 130) {
        let status = '';
        const speeding = speed - 130;
        if (speeding <= 20) {
            status = 'speeding';
        } else if (speeding > 20 && speeding <= 40) {
            status = 'excessive speeding';
        } else {
            status = 'reckless driving';
        }
        console.log(
            `The speed is ${
                speed - 130
            } km/h faster than the allowed speed of 130 - ${status}`
        );
    } else if (road === 'interstate' && speed > 90) {
        let status = '';
        const speeding = speed - 90;
        if (speeding <= 20) {
            status = 'speeding';
        } else if (speeding > 20 && speeding <= 40) {
            status = 'excessive speeding';
        } else {
            status = 'reckless driving';
        }
        console.log(
            `The speed is ${
                speed - 90
            } km/h faster than the allowed speed of 90 - ${status}`
        );
    } else if (road === 'city' && speed > 50) {
        let status = '';
        const speeding = speed - 50;
        if (speeding <= 20) {
            status = 'speeding';
        } else if (speeding > 20 && speeding <= 40) {
            status = 'excessive speeding';
        } else {
            status = 'reckless driving';
        }
        console.log(
            `The speed is ${
                speed - 50
            } km/h faster than the allowed speed of 50 - ${status}`
        );
    } else if (road === 'residential' && speed > 20) {
        let status = '';
        const speeding = speed - 20;
        if (speeding <= 20) {
            status = 'speeding';
        } else if (speeding > 20 && speeding <= 40) {
            status = 'excessive speeding';
        } else {
            status = 'reckless driving';
        }
        console.log(
            `The speed is ${
                speed - 20
            } km/h faster than the allowed speed of 20 - ${status}`
        );
    } else {
        let limit = 20;
        if (road === 'city') {
            limit = 50;
        } else if (road === 'interstate') {
            limit = 90;
        } else if (road === 'motorway') {
            limit = 130;
        }
        console.log(`Driving ${speed} km/h in a ${limit} zone`);
    }
}

solve(40, 'city');
solve(21, 'residential');
solve(120, 'interstate');
solve(200, 'motorway');
solve(10, 'residential');
