function solve() {
    const [checkBtn, clearBtn] = document.querySelectorAll('button');
    const tableRows = Array.from(document.querySelectorAll('tbody tr'));
    const checkDiv = document.querySelector('#check');
    const table = document.querySelector('table');

    checkBtn.addEventListener('click', () => {
        if (isTableEmpty()) {
            setNotReady();
        }

        if (isFilledCorrectly()) {
            setReady();
        } else {
            setNotReady();
        }
    });

    clearBtn.addEventListener('click', () => {
        for (let i = 0; i < tableRows.length; i++) {
            for (let j = 0; j < tableRows.length; j++) {
                tableRows[i].children[j].children[0].value = '';
            }
        }
        table.style.border = 'none';
        const resultP = checkDiv.children[0];
        resultP.textContent = '';
    });

    function isTableEmpty() {
        for (let i = 0; i < tableRows.length; i++) {
            for (let j = 0; j < tableRows.length; j++) {
                if (tableRows[i].children[j].children[0].value === '') {
                    return true;
                }
            }
        }
        return false;
    }

    function isFilledCorrectly() {
        for (let i = 0; i < tableRows.length; i++) {
            const values = new Set();
            for (let j = 0; j < tableRows.length; j++) {
                values.add(tableRows[i].children[j].children[0].value);
            }

            if (values.size !== 3) {
                return false;
            }
        }

        for (let j = 0; j < tableRows[0].children.length; j++) {
            const values = new Set();
            for (let i = 0; i < tableRows.length; i++) {
                values.add(tableRows[i].children[j].children[0].value);
            }
            if (values.size !== 3) {
                return false;
            }
        }

        return true;
    }

    function setReady() {
        table.style.border = '2px solid green';
        const resultP = checkDiv.children[0];
        resultP.textContent = 'You solve it! Congratulations!';
        resultP.style.color = 'green';
    }

    function setNotReady() {
        table.style.border = '2px solid red';
        const resultP = checkDiv.children[0];
        resultP.textContent = 'NOP! You are not done yet...';
        resultP.style.color = 'red';
    }
}
