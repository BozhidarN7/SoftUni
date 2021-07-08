const createForm = document.querySelector('form');

createForm.addEventListener('submit', (e) => {
    e.preventDefault();

    const data = new FormData(e.currentTarget);

    const name = data.get('name');
    const img = data.get('img');
    const ingredients = data.get('ingredients');
    const steps = data.get('steps');

    fetch('http://localhost:3030/data/recipes', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': localStorage.getItem('auth_token'),
        },
        body: JSON.stringify({
            name,
            img,
            ingredients,
            steps,
        }),
    })
        .then((response) => response.json())
        .then((data) => console.log(data))
        .catch((error) => console.log(error));

    e.currentTarget.reset();
    window.location.pathname = 'index.html';
});
