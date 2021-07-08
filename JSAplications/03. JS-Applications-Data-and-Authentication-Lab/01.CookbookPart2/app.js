const guestDiv = document.querySelector('#guest');
const userDiv = document.querySelector('#user');
const logoutBtn = document.querySelector('#logoutBtn');

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
