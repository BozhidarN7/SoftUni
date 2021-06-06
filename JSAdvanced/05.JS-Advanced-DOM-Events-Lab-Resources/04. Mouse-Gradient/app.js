function attachGradientEvents() {
    const gradientElement = document.querySelector('#gradient');
    const resultDiv = document.querySelector('#result');

    gradientElement.addEventListener('mousemove', (e) => {
        let poewr = e.offsetX / (e.target.clientWidth - 1);
        power = Math.trunc(poewr * 100);
        resultDiv.textContent = `${power}%`;
    });

    gradientElement.addEventListener('mouseout', () => {
        resultDiv.textContent = '';
    });
}
