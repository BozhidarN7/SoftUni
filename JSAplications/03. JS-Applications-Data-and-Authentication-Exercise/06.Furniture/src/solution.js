const logoutBtn = document.querySelector('#logoutBtn');
const createForm = document.querySelector('form');
const buyBtn = document.querySelector('#buyBtn');
const allOrdersBtn = document.querySelector('#allOrdersBtn');
const baseUrl = 'http://localhost:3030';
const orderDetailsProducts = document.querySelector('#orderDetailsProducts');
const orderDetailsPrice = document.querySelector('#orderDetailsPrice');

window.addEventListener('load', async () => {
    const furnitures = await (await fetch(`${baseUrl}/data/furniture`)).json();
    furnitures.forEach((furniture) => {
        createProduct(furniture);
    });
});

logoutBtn.addEventListener('click', async () => {
    const res = fetch(`${baseUrl}/users/logout`, {
        method: 'GET',
        headers: {
            'X-Authorization': getToken(),
        },
    });
    removeToken();
    removeUserId();
    window.location.href = 'home.html';
});

createForm.addEventListener('submit', addNewProduct);

async function addNewProduct(e) {
    e.preventDefault();

    const data = new FormData(e.currentTarget);
    const name = data.get('name');
    const price = Number(data.get('price'));
    const factor = Number(data.get('factor'));
    const img = data.get('img');

    try {
        const res = await fetch(`${baseUrl}/data/furniture`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': getToken(),
            },
            body: JSON.stringify({ name, price, factor, img }),
        });
        const product = await res.json();
        createProduct(product);
        e.target.reset();
    } catch (error) {
        console.log(error);
    }
}

buyBtn.addEventListener('click', async () => {
    const tbody = document.querySelector('tbody');
    const orders = Array.from(tbody.children).reduce((acc, cur) => {
        const checkBoxEl = cur.querySelector('input');
        if (checkBoxEl.checked) {
            const trEl = checkBoxEl.closest('tr');
            const name =
                trEl.querySelector('td:nth-of-type(2)').children[0].textContent;
            const price =
                trEl.querySelector('td:nth-of-type(3)').children[0].textContent;
            acc.push({ name, price });
        }
        return acc;
    }, []);
    try {
        const res = await fetch(`${baseUrl}/data/orders`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': getToken(),
            },
            body: JSON.stringify({
                orders: orders,
            }),
        });
    } catch (error) {
        console.log(error);
    }
});

allOrdersBtn.addEventListener('click', async () => {
    const res = await fetch(
        `${baseUrl}/data/orders?where=_ownerId%3D%22${getUserId()}%22`
    );
    const data = await res.json();

    const furnitures = new Set();
    let totalPrice = 0;
    data.forEach((order) => {
        order.orders.forEach((furniture) => {
            console.log(furniture);
            furnitures.add(furniture.name);
            if (furniture.price) totalPrice += Number(furniture.price);
        });
    });

    orderDetailsProducts.textContent = 'Bought furniture: ';
    orderDetailsProducts.textContent += Array.from(furnitures)
        .filter((x) => x)
        .join(', ');

    orderDetailsPrice.textContent = 'Total price: ';
    orderDetailsPrice.textContent += `${totalPrice} $`;
});

function createProduct(product) {
    const trEl = ce('tr', undefined);

    const imgEl = ce('img', { src: product.img });
    const nameParagraph = ce('p', undefined, product.name);
    const priceParagraph = ce('p', undefined, product.price);
    const factorParagraph = ce('p', undefined, product.factor);

    const imgTd = ce('td', undefined, imgEl);
    const nameTd = ce('td', undefined, nameParagraph);
    const priceTd = ce('td', undefined, priceParagraph);
    const factorTd = ce('td', undefined, factorParagraph);

    const checkBoxEl = ce('input', { type: 'checkbox' });
    const checkBoxTd = ce('td', undefined, checkBoxEl);

    trEl.appendChild(imgTd);
    trEl.appendChild(nameTd);
    trEl.appendChild(priceTd);
    trEl.appendChild(factorTd);
    trEl.appendChild(checkBoxTd);

    trEl.dataset.ownerId = product._ownerId;

    if (product._ownerId === getUserId()) {
        checkBoxEl.disabled = true;
    }
    document.querySelector('tbody').appendChild(trEl);
}

function ce(tag, attributes, ...params) {
    const element = document.createElement(tag);
    const firstValue = params[0];

    if (params.length === 1 && typeof firstValue !== 'object') {
        if (['input', 'textarea'].includes(tag)) {
            element.value = firstValue;
        } else {
            element.textContent = firstValue;
        }
    } else {
        element.append(...params);
    }

    if (attributes) {
        Object.keys(attributes).forEach((key) => {
            element.setAttribute(key, attributes[key]);
        });
    }

    return element;
}

function getToken() {
    return localStorage.getItem('auth_token');
}

function removeToken() {
    localStorage.removeItem('auth_token');
}

function getUserId() {
    return localStorage.getItem('userId');
}

function removeUserId() {
    localStorage.removeItem('userId');
}
