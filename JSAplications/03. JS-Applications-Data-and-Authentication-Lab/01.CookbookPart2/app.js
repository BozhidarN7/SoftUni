const guestDiv = document.querySelector('#guest');
const userDiv = document.querySelector('#user');
const logoutBtn = document.querySelector('#logoutBtn');
const mainEl = document.querySelector('main');

const baseUrl = 'http://localhost:3030';

function getToken() {
    return localStorage.getItem('auth_token');
}

if (getToken()) {
    userDiv.style.display = 'inline-block';
    guestDiv.style.display = 'none';
} else {
    guestDiv.style.display = 'inline-block';
    userDiv.style.display = 'none';
}

function logout() {
    fetch(`${baseUrl}/users/logout`, {
        method: 'GET',
        headers: {
            'X-Authorization': getToken(),
        },
    })
        .then((response) => {
            if (response.status === 200) {
                localStorage.removeItem('auth_token');
                window.location.pathname = 'index.html';
            }
            return response.json();
        })
        .catch((error) => {
            console.log(error);
        });
}

logoutBtn.addEventListener('click', logout);

async function showRecipes() {
    const recipes = await getRecipes();
    Object.keys(recipes).forEach((id) => {
        const recipe = recipes[id];
        const articleEl = document.createElement('article');
        articleEl.classList.add('preview');
        articleEl.addEventListener('click', showInfo);

        const titleDiv = document.createElement('div');
        titleDiv.classList.add('title');

        const headingEl = document.createElement('h2');
        headingEl.textContent = `${recipe.name}`;
        titleDiv.appendChild(headingEl);

        const imgDiv = document.createElement('div');
        imgDiv.classList.add('small');

        const imgEl = document.createElement('img');
        imgEl.src = recipe.img;

        imgDiv.appendChild(imgEl);

        articleEl.appendChild(titleDiv);
        articleEl.appendChild(imgDiv);

        mainEl.appendChild(articleEl);
    });
    mainEl.children[0].remove();
}

function getRecipes() {
    return fetch('http://localhost:3030/data/recipes').then((response) =>
        response.json()
    );
}
async function showInfo(e) {
    const recipeArticle = e.currentTarget;
    const recipeName = recipeArticle.children[0].children[0].textContent;
    const recipe = Object.values(await getRecipes()).find(
        (curr) => Object.values(curr)[1] === recipeName
    );
    const id = recipe['_id'];
    const recipeDetailsUrl = `http://localhost:3030/data/recipes/${id}`;
    const recipeDetails = await (await fetch(recipeDetailsUrl)).json();

    const articleEl = document.createElement('article');

    const titleHeading = document.createElement('h2');
    titleHeading.textContent = `${recipe.name}`;
    articleEl.appendChild(titleHeading);

    const bandDiv = document.createElement('div');
    bandDiv.classList.add('band');

    const thumbDiv = document.createElement('div');
    thumbDiv.classList.add('thumb');

    const imgEl = document.createElement('img');
    imgEl.src = recipe.img;

    thumbDiv.appendChild(imgEl);

    const ingredientsDiv = document.createElement('div');
    ingredientsDiv.classList.add('ingredients');

    const ingredientsHeading = document.createElement('h3');
    ingredientsHeading.textContent = 'Ingredients:';

    const ulEl = document.createElement('ul');

    if (typeof recipeDetails.ingredients == 'string') {
        recipeDetails.ingredients.split('\n').forEach((ingr) => {
            const liEl = document.createElement('li');
            liEl.textContent = ingr;
            ulEl.appendChild(liEl);
        });
    } else {
        recipeDetails.ingredients.forEach((ingr) => {
            const liEl = document.createElement('li');
            liEl.textContent = ingr;
            ulEl.appendChild(liEl);
        });
    }
    ingredientsDiv.appendChild(ulEl);

    bandDiv.appendChild(thumbDiv);
    bandDiv.appendChild(ingredientsDiv);

    const descriptionDiv = document.createElement('div');
    descriptionDiv.classList.add('description');

    const preperationHeading = document.createElement('h3');
    preperationHeading.textContent = 'Preperation:';

    descriptionDiv.appendChild(preperationHeading);

    if (typeof recipeDetails.ingredients == 'string') {
        recipeDetails.steps.split('\n').forEach((step) => {
            const pEl = document.createElement('p');
            pEl.textContent = step;
            descriptionDiv.appendChild(pEl);
        });
    } else {
        recipeDetails.steps.forEach((step) => {
            const pEl = document.createElement('p');
            pEl.textContent = step;
            descriptionDiv.appendChild(pEl);
        });
    }

    articleEl.appendChild(bandDiv);
    articleEl.appendChild(descriptionDiv);

    recipeArticle.insertAdjacentElement('afterend', articleEl);
    recipeArticle.remove();
}

showRecipes();
