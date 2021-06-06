function solve() {
    const addButtons = document.querySelectorAll('.add-product');
    const checkoutButton = document.querySelector('.checkout');
    const textarea = document.querySelector('textarea');

    const uniqueProducts = new Set();
    let totalPrice = 0;
    Array.from(addButtons).forEach((button) => {
        button.addEventListener('click', () => {
            const outestDiv = button.parentElement.parentElement;
            const product =
                outestDiv.querySelector('.product-title').textContent;
            const productPrice = Number(
                outestDiv.querySelector('.product-line-price').textContent
            );
            textarea.textContent += `Added ${product} for ${productPrice.toFixed(
                2
            )} to the cart.\n`;
            uniqueProducts.add(product);
            totalPrice += productPrice;
        });
    });

    checkoutButton.addEventListener('click', (e) => {
        textarea.textContent += `You bought ${new Array(...uniqueProducts).join(
            ', '
        )} for ${totalPrice.toFixed(2)}.`;
        e.target.setAttribute('disabled', true);
        Array.from(addButtons).forEach((button) =>
            button.setAttribute('disabled', true)
        );
    });
}
