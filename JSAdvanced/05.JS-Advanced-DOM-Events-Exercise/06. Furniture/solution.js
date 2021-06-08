function solve() {
    const [inputTextarea, outputTextarea] =
        document.querySelectorAll('textarea');
    const [generateButton, buyButton] = document.querySelectorAll('button');
    const tableBody = document.querySelector('tbody');

    generateButton.addEventListener('click', () => {
        const arr = JSON.parse(inputTextarea.value);
        const tableRows = arr.reduce((acc, furniture) => {
            acc += '<tr>';
            acc += `<td><img src="${furniture.img}"></td>`;
            acc += `<td><p>${furniture.name}</p></td>`;
            acc += `<td><p>${furniture.price}</p></td>`;
            acc += `<td><p>${furniture.decFactor}</p></td>`;
            acc += `<td><input type="checkbox"></td>`;
            acc += '</tr>';
            return acc;
        }, '');

        tableBody.insertAdjacentHTML('beforeend', tableRows);
    });

    buyButton.addEventListener('click', () => {
        const names = [];
        const prices = [];
        const decorationFactors = [];
        Array.from(document.querySelectorAll('input[type="checkbox"]')).forEach(
            (input) => {
                if (input.checked) {
                    names.push(
                        input.parentElement.parentElement.children[1]
                            .children[0].textContent
                    );
                    prices.push(
                        Number(
                            input.parentElement.parentElement.children[2]
                                .children[0].textContent
                        )
                    );
                    decorationFactors.push(
                        Number(
                            input.parentElement.parentElement.children[3]
                                .children[0].textContent
                        )
                    );
                }
            }
        );
        outputTextarea.value = `Bought furnitures: ${names.join(', ')}\n`;
        outputTextarea.value += `Total price: ${prices
            .reduce((acc, x) => (acc += x))
            .toFixed(2)}\n`;
        outputTextarea.value += `Average decoration factor: ${
            decorationFactors.reduce((acc, x) => (acc += x)) /
            decorationFactors.length
        }`;
    });
}
