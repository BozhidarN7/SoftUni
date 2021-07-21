import { render } from './node_modules/lit-html/lit-html.js';
import bookService from './services/bookService.js';
import {
    allBooksTemplate,
    allFormsTemplate,
    bookLibaryTemplate,
    formTemplate,
} from './templates/bookTemplates.js';

const body = document.body;

const addForm = {
    id: 'add-form',
    type: 'add',
    title: 'Add book',
    submitText: 'Submit',
    authorValue: '',
    titleValue: '',
    submitHandler: createBook,
};

const editForm = {
    id: 'edit-form',
    type: 'edit',
    title: 'Edit Book',
    submitText: 'Save',
    class: 'hidden',
    submitHandler: editBook,
    idValue: '',
    authorValue: '',
    titleValue: '',
};

const forms = [addForm, editForm];
let books = [];

render(bookLibaryTemplate([], forms, loadBooks, prepareEdit, deleteBook), body);

const booksContainer = document.querySelector('#books-container');

async function loadBooks() {
    const booksObj = await bookService.getAllBooks();
    books = Object.entries(booksObj).map(([key, val]) => {
        val._id = key;
        return val;
    });
    render(allBooksTemplate(books, prepareEdit, deleteBook), booksContainer);
}

async function createBook(e) {
    e.preventDefault();
    const form = e.target;
    const formData = new FormData(form);
    const newBook = {
        author: formData.get('author'),
        title: formData.get('title'),
    };

    const createResult = await bookService.createBook(newBook);
    books.push(createResult);

    render(allBooksTemplate(books, prepareEdit, deleteBook), booksContainer);
}

async function prepareEdit(e) {
    const book = e.target.closest('.book');
    const id = book.dataset.id;

    const bookSource = await bookService.getBook(id);

    addForm.class = 'hidden';
    editForm.class = undefined;
    editForm.idValue = id;
    editForm.authorValue = bookSource.author;
    editForm.titleValue = bookSource.title;
    render(
        bookLibaryTemplate(books, forms, loadBooks, prepareEdit, deleteBook),
        body
    );
}

async function deleteBook(e) {
    const book = e.target.closest('.book');
    const id = book.dataset.id;

    await bookService.deleteBook(id);
    books = books.filter((x) => x._id !== id);
    render(allBooksTemplate(books, prepareEdit, deleteBook), booksContainer);
}

async function editBook(e) {
    e.preventDefault();
    const form = e.target;
    const formData = new FormData(form);
    const id = formData.get('id');
    const newBook = {
        author: formData.get('author'),
        title: formData.get('title'),
    };

    const createResult = await bookService.editBook(id, newBook);
    books = books.filter((x) => x._id !== id);
    books.push(createResult);

    document.querySelector('#add-form').classList.remove('hidden');
    document.querySelector('#edit-form').classList.add('hidden');

    render(allBooksTemplate(books, prepareEdit, deleteBook), booksContainer);
}
