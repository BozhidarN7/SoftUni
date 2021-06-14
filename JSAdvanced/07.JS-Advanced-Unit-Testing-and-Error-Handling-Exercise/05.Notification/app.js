function notify(message) {
    const notificationDiv = document.querySelector('#notification');
    notificationDiv.textContent = message;
    notificationDiv.style.display = 'block';
    notificationDiv.addEventListener('click', () => {
        notificationDiv.style.display = 'none';
    });
}
