const allRecipesUrl = `http://localhost:3030/jsonstore/cookbook/recipes`;
window.addEventListener('load', () => {
    const mainEl = document.querySelector('main');
    fetch(allRecipesUrl)
        .then((response) => response.json())
        .then((recipes) => {
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
        });
    mainEl.children[0].remove();
});

async function showInfo(e) {
    const recipeArticle = e.currentTarget;
    const recipeName = recipeArticle.children[0].children[0].textContent;
    const recipe = Object.values(
        await (await fetch(allRecipesUrl)).json()
    ).find((curr) => Object.values(curr)[1] === recipeName);
    const id = recipe['_id'];
    const recipeDetailsUrl = `http://localhost:3030/jsonstore/cookbook/details/${id}`;
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

    recipeDetails.ingredients.forEach((ingr) => {
        const liEl = document.createElement('li');
        liEl.textContent = ingr;
        ulEl.appendChild(liEl);
    });

    ingredientsDiv.appendChild(ulEl);

    bandDiv.appendChild(thumbDiv);
    bandDiv.appendChild(ingredientsDiv);

    const descriptionDiv = document.createElement('div');
    descriptionDiv.classList.add('description');

    const preperationHeading = document.createElement('h3');
    preperationHeading.textContent = 'Preperation:';

    descriptionDiv.appendChild(preperationHeading);

    recipeDetails.steps.forEach((step) => {
        const pEl = document.createElement('p');
        pEl.textContent = step;
        descriptionDiv.appendChild(pEl);
    });

    articleEl.appendChild(bandDiv);
    articleEl.appendChild(descriptionDiv);

    recipeArticle.insertAdjacentElement('afterend', articleEl);
    recipeArticle.remove();
}
