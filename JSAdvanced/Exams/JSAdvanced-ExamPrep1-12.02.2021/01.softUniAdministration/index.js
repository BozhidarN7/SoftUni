function solve() {
    const lectureField = document.querySelector('input[type="text"');
    const dateField = document.querySelector('input[type="datetime-local"]');
    const selectModuleEl = document.querySelector('select');
    const addBtn = document.querySelector('button');
    const modulesDiv = document.querySelector('.modules');

    const registeredModules = new Set();

    addBtn.addEventListener('click', (e) => {
        e.preventDefault();
        if (
            lectureField.value === '' ||
            dateField.value === '' ||
            selectModuleEl.value === 'Select module'
        ) {
            return;
        }

        if (!registeredModules.has(selectModuleEl.value.toLowerCase())) {
            const moduleDiv = document.createElement('div');
            moduleDiv.classList.add('module');

            const headingModuleEl = document.createElement('h3');
            headingModuleEl.textContent =
                `${selectModuleEl.value}-MODULE`.toUpperCase();

            const ulEl = document.createElement('ul');
            const liEl = buildLi();
            ulEl.appendChild(liEl);
            moduleDiv.appendChild(headingModuleEl);
            moduleDiv.appendChild(ulEl);
            modulesDiv.appendChild(moduleDiv);

            sortLiEl(ulEl);

            registeredModules.add(selectModuleEl.value.toLowerCase());
        } else {
            const liEl = buildLi();
            const ulEl = Array.from(document.querySelectorAll('.module'))
                .map((module) => module.querySelector('h3'))
                .filter(
                    (heading) =>
                        heading.textContent.split('-')[0].toLowerCase() ===
                        selectModuleEl.value.toLowerCase()
                )[0].nextElementSibling;
            ulEl.appendChild(liEl);
            sortLiEl(ulEl);
        }
    });

    function buildDate(date) {
        const dateNumber =
            Number(date.getDate()) < 10 ? `0${date.getDate()}` : date.getDate();
        const month =
            Number(date.getMonth() + 1) < 10
                ? `0${date.getMonth() + 1}`
                : date.getMonth() + 1;
        const year = date.getFullYear();
        const hour =
            Number(date.getHours()) < 10
                ? `0${date.getHours()}`
                : date.getHours();
        const minutes =
            Number(date.getMinutes()) < 10
                ? `0${date.getMinutes()}`
                : date.getMinutes();

        return `${year}/${month}/${dateNumber} - ${hour}:${minutes}`;
    }

    function buildLi() {
        const liEl = document.createElement('li');
        liEl.classList.add('flex');

        const headingLectureEl = document.createElement('h4');
        const date = buildDate(new Date(dateField.value));

        headingLectureEl.textContent = `${lectureField.value} - ${date}`;

        const deleteBtn = document.createElement('button');
        deleteBtn.classList.add('red');
        deleteBtn.textContent = 'Del';
        deleteBtn.addEventListener('click', deleteLecture);

        liEl.appendChild(headingLectureEl);
        liEl.appendChild(deleteBtn);

        return liEl;
    }

    function sortLiEl(ulEl) {
        const sorted = Array.from(ulEl.children).sort((a, b) => {
            const firstDate = a.children[0].textContent
                .split(' - ')
                .slice(1)
                .join(' - ');
            const secondDate = b.children[0].textContent
                .split(' - ')
                .slice(1)
                .join(' - ');
            return firstDate.localeCompare(secondDate);
        });
        Array.from(ulEl.children).forEach((li) => li.remove());
        sorted.forEach((li) => ulEl.appendChild(li));
    }

    function deleteLecture(e) {
        if (e.target.parentElement.parentElement.children.length === 1) {
            registeredModules.delete(
                e.target.parentElement.parentElement.parentElement.children[0].textContent
                    .split('-')[0]
                    .toLowerCase()
            );
            e.target.parentElement.parentElement.parentElement.remove();
        } else {
            e.target.parentElement.remove();
        }
    }
}
