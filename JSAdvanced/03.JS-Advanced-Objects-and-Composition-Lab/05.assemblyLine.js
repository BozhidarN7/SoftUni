function createAssemblyLine() {
    return {
        hasClima(car) {
            car.temp = 21;
            car.tempSettings = 21;
            car.adjustTemp = function () {
                if (this.temp < this.tempSettings) {
                    this.temp++;
                } else if (this.temp > this.tempSettings) {
                    this.temp--;
                }
            };
        },
        hasAudio(car) {
            car.currentTrack = {
                name: null,
                artist: null,
            };
            car.nowPlaying = function () {
                if (car.currentTrack) {
                    console.log(
                        `Now playing ${this.currentTrack.name} by ${this.currentTrack.artist}`
                    );
                }
            };
        },
        hasParktronic(car) {
            car.checkDistance = function (distance) {
                if (distance < 0.1) {
                    console.log('Beep! Beep! Beep!');
                } else if (distance >= 0.1 && distance < 0.25) {
                    console.log('Beep! Beep!');
                } else if (distance >= 0.25 && distance < 0.5) {
                    console.log('Beep!');
                } else {
                    console.log('');
                }
            };
        },
    };
}

const assemblyLine = createAssemblyLine();

const myCar = {
    make: 'Toyoata',
    model: 'Avensis',
};

assemblyLine.hasParktronic(myCar);
myCar.checkDistance(0.4);
myCar.checkDistance(0.2);
