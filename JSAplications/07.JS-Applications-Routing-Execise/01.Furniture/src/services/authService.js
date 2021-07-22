function register(e) {
    e.preventDefault();

    const data = new FormData(e.currentTarget);
    const email = data.get('emai');
    const password = data.get('password');
    const rePass = data.get('rePass');
}

function getUserId() {
    return localStorage.getItem('useId');
}

function getToken() {
    return localStorage.getItem('accessToken');
}

export default {
    getUserId,
    getToken,
    register,
};
