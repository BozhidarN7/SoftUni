const formEl = document.querySelector('form');
const loadBooksBtn = document.querySelector('#loadBooks');
const tbodyEl = document.querySelector('tbody');
// const submitBtn = document.querySelector('form button');

const baseUrl = 'http://localhost:3030/jsonstore/collections/books';

formEl.addEventListener('submit', submitBook);

loadBooksBtn.addEventListener('click', async () => {
    Array.from(tbodyEl.children).forEach((tr) => tr.remove());

    const books = await (await fetch(baseUrl)).json();

    for (const id in books) {
        const book = books[id];

        createBook(book);
    }
});

function submitBook(e) {
    if (e.currentTarget.dataset.isEdit) {
        editBook(e);
    } else {
        addBook(e);
    }
}

async function addBook(e) {
    e.preventDefault();

    const data = new FormData(e.currentTarget);
    const author = data.get('author');
    const title = data.get('title');

    if (!author || !title) {
        return;
    }

    const res = await fetch(`${baseUrl}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            author,
            title,
        }),
    });
    const newBook = await res.json();
    createBook(newBook);
    e.target.reset();
}

function handleEdit(e) {
    formEl.children[0].textContent = 'Edit FORM';
    const titleField = document.querySelector('input[name="title"]');
    const authorField = document.querySelector('input[name="author"]');

    titleField.value = e.target.closest('tr').children[0].textContent;
    authorField.value = e.target.closest('tr').children[1].textContent;

    formEl.dataset.isEdit = true;
    formEl.dataset.bookId = e.target.closest('tr').dataset.bookId;
}

async function editBook(e) {
    e.preventDefault();
    const data = new FormData(e.currentTarget);
    const author = data.get('author');
    const title = data.get('title');

    const res = await fetch(`${baseUrl}/${formEl.dataset.bookId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            author,
            title,
        }),
    });

    // Clicking load buttons is requried to see the update

    e.target.reset();
}

async function deleteBook(e) {
    const trEl = e.target.closest('tr');
    const id = trEl.dataset.bookId;

    const res = await fetch(`${baseUrl}/${id}`, {
        method: 'DELETE',
    });
    const deletedBook = await res.json();
    trEl.remove();
}

function createBook(book) {
    const trEl = document.createElement('tr');
    trEl.dataset.bookId = book._id;

    const tdTitle = document.createElement('td');
    tdTitle.textContent = book.title;

    const tdAuthor = document.createElement('td');
    tdAuthor.textContent = book.author;

    const tdButtons = document.createElement('td');

    const editBtn = document.createElement('button');
    editBtn.textContent = 'Edit';
    editBtn.addEventListener('click', handleEdit);

    const deleteBtn = document.createElement('button');
    deleteBtn.textContent = 'Delete';
    deleteBtn.addEventListener('click', deleteBook);

    tdButtons.appendChild(editBtn);
    tdButtons.appendChild(deleteBtn);

    trEl.appendChild(tdTitle);
    trEl.appendChild(tdAuthor);
    trEl.appendChild(tdButtons);

    tbodyEl.appendChild(trEl);
}
