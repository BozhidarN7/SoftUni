function solve(steps, footprint, speed) {
    const distance = steps * footprint;
    const speedInMps = speed / 3.6;
    let time = distance / speedInMps;
    const breaks = Math.trunc(distance / 500);
    time += breaks * 60;

    const hours = Math.trunc(time / 3600);
    const minutes = Math.trunc((time % 3600) / 60);
    const seconds = Math.round(time % 60);

    console.log(hours);
    console.log(minutes);
    console.log(seconds);

    let result = '';

    if (hours) {
        if (hours < 10) {
            result += `0${hours}`;
        } else {
            result += hours;
        }
    } else {
        result += '00';
    }
    result += ':';

    if (minutes) {
        if (minutes < 10) {
            result += `0${minutes}`;
        } else {
            result += minutes;
        }
    } else {
        result += '00';
    }
    result += ':';

    if (seconds) {
        if (seconds < 10) {
            result += `0${seconds}`;
        } else {
            result += seconds;
        }
    } else {
        result += '00';
    }

    console.log(result);
}

solve(4000, 0.6, 5);
solve(2564, 0.7, 5.5);
