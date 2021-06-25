function solve() {
    const taskField = document.querySelector('#task');
    const descriptionField = document.querySelector('#description');
    const dateField = document.querySelector('#date');
    const addBtn = document.querySelector('#add');

    addBtn.addEventListener('click', (e) => {
        e.preventDefault();

        if (!taskField.value || !descriptionField.value || !dateField.value) {
            return;
        }

        const articleEl = document.createElement('article');

        const titleHeading = document.createElement('h3');
        titleHeading.textContent = taskField.value;

        const descriptionParagraph = document.createElement('p');
        descriptionParagraph.textContent = `Description: ${descriptionField.value}`;

        const dateParagraph = document.createElement('p');
        dateParagraph.textContent = `Due Date: ${dateField.value}`;

        const buttonsDiv = document.createElement('div');
        buttonsDiv.classList.add('flex');

        const startBtn = document.createElement('button');
        startBtn.textContent = 'Start';
        startBtn.classList.add('green');
        startBtn.addEventListener('click', moveToInProgress);

        const deleteBtn = document.createElement('button');
        deleteBtn.textContent = 'Delete';
        deleteBtn.classList.add('red');
        deleteBtn.addEventListener('click', deleteTask);

        buttonsDiv.appendChild(startBtn);
        buttonsDiv.appendChild(deleteBtn);

        articleEl.appendChild(titleHeading);
        articleEl.appendChild(descriptionParagraph);
        articleEl.appendChild(dateParagraph);
        articleEl.appendChild(buttonsDiv);

        document
            .querySelector('section:nth-of-type(2) div:nth-of-type(2)')
            .appendChild(articleEl);
    });

    function deleteTask(e) {
        e.target.parentElement.parentElement.remove();
    }

    function moveToInProgress(e) {
        e.target.nextElementSibling.remove();

        const btnFinish = document.createElement('button');
        btnFinish.textContent = 'Finish';
        btnFinish.classList.add('orange');
        btnFinish.addEventListener('click', moveToComplete);

        e.target.removeEventListener('click', moveToInProgress);
        e.target.textContent = 'Delete';
        e.target.classList.remove('green');
        e.target.classList.remove('red');
        e.target.classList.add('red');
        e.target.addEventListener('click', deleteTask);

        e.target.parentElement.appendChild(btnFinish);

        document
            .querySelector('section:nth-of-type(3) div:nth-of-type(2)')
            .appendChild(e.target.parentElement.parentElement);
    }

    function moveToComplete(e) {
        document
            .querySelector('section:nth-of-type(4) div:nth-of-type(2)')
            .appendChild(e.target.parentElement.parentElement);
        e.target.parentElement.remove();
    }
}
