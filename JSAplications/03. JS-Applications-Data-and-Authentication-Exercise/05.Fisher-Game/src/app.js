const guestDiv = document.querySelector('#guest');
const catchesDiv = document.querySelector('#catches');
const loadBtn = document.querySelector('.load');
const addBtn = document.querySelector('.add');

const baseUrl = 'http://localhost:3030';

if (getToken()) {
    guestDiv.children[0].classList.toggle('hidden');
    guestDiv.children[1].classList.toggle('hidden');
    addBtn.disabled = false;
}

guestDiv.children[1].addEventListener('click', async (e) => {
    const res = await fetch(`${baseUrl}/users/logout`, {
        method: 'GET',
        headers: {
            'X-Authorization': getToken(),
        },
    });
    removeToken();
    removeUserId();
});

loadBtn.addEventListener('click', getAllCatches);
addBtn.addEventListener('click', submitNewCatchRecord);

async function getAllCatches() {
    Array.from(catchesDiv.children).forEach((child) => child.remove());

    const data = await (await fetch(`${baseUrl}/data/catches`)).json();

    data.forEach((curCatch) => {
        const catchDiv = createCatchRecord(curCatch);
        if (catchDiv.dataset.ownerId === getUserId()) {
            const editBtn = catchDiv.querySelector('.update');
            const delBtn = catchDiv.querySelector('.delete');

            editBtn.disabled = false;
            editBtn.classList.add('yellow');

            delBtn.disabled = false;
            delBtn.classList.add('red');
        }
    });
}

async function submitNewCatchRecord() {
    const addFormEl = document.querySelector('#addForm');

    const angler = addFormEl.querySelector('.angler').value;
    const weight = Number(addFormEl.querySelector('.weight').value);
    const species = addFormEl.querySelector('.species').value;
    const location = addFormEl.querySelector('.location').value;
    const bait = addFormEl.querySelector('.bait').value;
    const captureTime = Number(addFormEl.querySelector('.captureTime').value);

    const res = await fetch(`${baseUrl}/data/catches`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': getToken(),
        },
        body: JSON.stringify({
            angler,
            weight,
            species,
            location,
            bait,
            captureTime,
        }),
    });
    const newCatch = await res.json();
    createCatchRecord(newCatch);
}

function createCatchRecord(curCatch) {
    const catchDiv = ce('div', { class: 'catch' });

    const anglerLabel = ce('label', undefined, 'Angler');
    const anglerInput = ce('input', {
        type: 'text',
        class: 'angler',
        value: `${curCatch.angler}`,
    });

    const hr = ce('hr', undefined);

    const weightLabel = ce('label', undefined, 'Weight');
    const weightInput = ce('input', {
        type: 'number',
        class: 'weight',
        value: `${Number(curCatch.weight)}`,
    });

    const hr2 = ce('hr', undefined);

    const speciesLabel = ce('label', undefined, 'Species');
    const speciesInput = ce('input', {
        type: 'text',
        class: 'species',
        value: `${curCatch.species}`,
    });

    const hr3 = ce('hr', undefined);

    const locationLabel = ce('label', undefined, 'Location');
    const locationInput = ce('input', {
        type: 'text',
        class: 'location',
        value: `${curCatch.location}`,
    });

    const hr4 = ce('hr', undefined);

    const baitLabel = ce('label', undefined, 'Bait');
    const baitInput = ce('input', {
        type: 'text',
        class: 'bait',
        value: `${curCatch.bait}`,
    });

    const hr5 = ce('hr', undefined);

    const captureTimeLabel = ce('label', undefined, 'Capture Time');
    const captureTimeInput = ce('input', {
        type: 'number',
        class: 'captureTime',
        value: `${Number(curCatch.captureTime)}`,
    });

    const hr6 = ce('hr', undefined);

    const updateBtn = ce(
        'button',
        { class: 'update', disabled: true },
        'Update'
    );
    const deleteBtn = ce(
        'button',
        { class: 'delete', disabled: true },
        'Delete'
    );

    updateBtn.addEventListener('click', updateCatch);
    deleteBtn.addEventListener('click', deleteBtn);

    catchDiv.appendChild(anglerLabel);
    catchDiv.appendChild(anglerInput);
    catchDiv.appendChild(hr);

    catchDiv.appendChild(weightLabel);
    catchDiv.appendChild(weightInput);
    catchDiv.appendChild(hr);

    catchDiv.appendChild(speciesLabel);
    catchDiv.appendChild(speciesInput);
    catchDiv.appendChild(hr);

    catchDiv.appendChild(locationLabel);
    catchDiv.appendChild(locationInput);
    catchDiv.appendChild(hr);

    catchDiv.appendChild(baitLabel);
    catchDiv.appendChild(baitInput);
    catchDiv.appendChild(hr);

    catchDiv.appendChild(captureTimeLabel);
    catchDiv.appendChild(captureTimeInput);
    catchDiv.appendChild(hr);

    catchDiv.appendChild(updateBtn);
    catchDiv.appendChild(deleteBtn);

    catchDiv.dataset.ownerId = curCatch._ownerId;
    catchesDiv.appendChild(catchDiv);
    return catchDiv;
}

async function updateCatch() {}
async function deleteCatch() {
    // const res = await fetch(`${baseUrl}/data/catches/`)
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

    if (attributes !== undefined) {
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

function setUserId(id) {
    localStorage.setItem('userId', id);
}
function getUserId() {
    return localStorage.getItem('userId');
}
function removeUserId() {
    localStorage.removeItem('userId');
}
