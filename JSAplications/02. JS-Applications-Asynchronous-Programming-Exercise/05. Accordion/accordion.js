const mainEl = document.querySelector('#main');

function solution() {
    (async function () {
        const listUrl = `http://localhost:3030/jsonstore/advanced/articles/list`;
        const articlesList = await (await fetch(listUrl)).json();
        createAccordion(articlesList);
    })();

    async function createAccordion(articlesList) {
        for (const index in articlesList) {
            const article = articlesList[index];
            const accordionDiv = document.createElement('div');
            accordionDiv.classList.add('accordion');

            const headDiv = document.createElement('div');
            headDiv.classList.add('head');

            const titleSpan = document.createElement('span');
            titleSpan.textContent = article.title;

            const moreBtn = document.createElement('button');
            moreBtn.textContent = 'MORE';
            moreBtn.classList.add('button');
            moreBtn.id = article._id;
            moreBtn.addEventListener('click', toggleMoreInfo);

            headDiv.appendChild(titleSpan);
            headDiv.appendChild(moreBtn);

            accordionDiv.appendChild(headDiv);

            mainEl.appendChild(accordionDiv);

            const extraDiv = document.createElement('div');
            extraDiv.classList.add('extra');

            const infoParagraph = document.createElement('p');

            const infoUrl = `http://localhost:3030/jsonstore/advanced/articles/details/${article._id}`;
            const articleInfo = await (await fetch(infoUrl)).json();

            infoParagraph.textContent = articleInfo.content;
            extraDiv.appendChild(infoParagraph);

            accordionDiv.appendChild(extraDiv);
        }
    }

    function toggleMoreInfo(e) {
        e.target.parentElement.parentElement
            .querySelector('div:nth-of-type(2)')
            .classList.toggle('extra');
    }
}

solution();
