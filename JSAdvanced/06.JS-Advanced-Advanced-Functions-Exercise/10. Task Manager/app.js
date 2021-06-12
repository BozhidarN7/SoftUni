function solve() {
    const openSection = document.querySelector('section:nth-of-type(2)');
    const inPorgressSection = document.querySelector('section:nth-of-type(3)');
    const completeSection = document.querySelector('section:nth-of-type(4)');
    const taskField = document.querySelector('#task');
    const descriptionField = document.querySelector('#description');
    const dateField = document.querySelector('#date');
    const addBtn = document.querySelector('form button');

    addBtn.addEventListener('click', addTask);

    function addTask(e) {
        e.preventDefault();

        const task = taskField.value;
        const description = descriptionField.value;
        const date = dateField.value;

        if (!task || !description || !date) return;

        const articleTag = document.createElement('article');
        const heading = document.createElement('h3');
        const descriptionParagraph = document.createElement('p');
        const dateParagraph = document.createElement('p');

        heading.textContent = task;
        descriptionParagraph.textContent = `Description: ${description}`;
        dateParagraph.textContent = `Due Date: ${date}`;

        const buttonsDiv = document.createElement('div');
        buttonsDiv.classList.add('flex');

        const startButton = document.createElement('button');
        startButton.textContent = 'Start';
        startButton.addEventListener('click', addToProgressSection);

        const deleteButton = document.createElement('button');
        deleteButton.textContent = 'Delete';
        deleteButton.addEventListener('click', removeTask);

        startButton.classList.add('green');
        deleteButton.classList.add('red');

        buttonsDiv.appendChild(startButton);
        buttonsDiv.appendChild(deleteButton);

        articleTag.appendChild(heading);
        articleTag.appendChild(descriptionParagraph);
        articleTag.appendChild(dateParagraph);
        articleTag.appendChild(buttonsDiv);

        openSection.children[1].appendChild(articleTag);
    }

    function addToProgressSection(e) {
        e.preventDefault();
        inPorgressSection.children[1].appendChild(
            e.target.parentElement.parentElement
        );
        e.target.classList.remove('green');
        e.target.classList.add('red');
        e.target.textContent = 'Delete';
        e.target.removeEventListener('click', addToProgressSection);
        e.target.addEventListener('click', removeTask);

        e.target.nextElementSibling.classList.remove('red');
        e.target.nextElementSibling.classList.add('orange');
        e.target.nextElementSibling.textContent = 'Finish';
        e.target.nextElementSibling.removeEventListener('click', removeTask);
        e.target.nextElementSibling.addEventListener(
            'click',
            addToCompleteSection
        );
    }

    function removeTask(e) {
        e.target.parentElement.parentElement.remove();
    }

    function addToCompleteSection(e) {
        completeSection.children[1].appendChild(
            e.target.parentElement.parentElement
        );
        e.target.parentElement.remove();
    }
}
