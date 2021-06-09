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
        const tableRows = Array.from(
            document.querySelectorAll('.table tbody tr')
        );
        const selectedRows = tableRows.filter((row) =>
            row.querySelector('input:checked')
        );

        const names = selectedRows
            .map((row) => row.querySelector('td:nth-of-type(2) p'))
            .map((x) => x.textContent)
            .join(', ');
        const prices = selectedRows
            .map((row) => row.querySelector('td:nth-of-type(3) p'))
            .map((x) => Number(x.textContent));
        const decFactors = selectedRows
            .map((row) => row.querySelector('td:nth-of-type(4) p'))
            .map((x) => Number(x.textContent));

        const totalPrice = prices.reduce((acc, el) => acc + el, 0).toFixed(2);
        const averageDecFactor =
            decFactors.reduce((acc, el) => acc + el, 0) / decFactors.length;

        const furnitureText = `Bought furniture: ${names}`;
        const priceText = `Total price: ${totalPrice}`;
        const decFactorText = `Average decoration factor: ${averageDecFactor}`;

        outputTextarea.textContent = `${furnitureText}\n${priceText}\n${decFactorText}`;
    });
}
