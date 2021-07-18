import { jsonRequest } from '../services/httpService.js';
import { ce } from '../helpers/htmlHelper.js';
import viewFinder from '../viewFinder.js';

let section = undefined;
let noIdeasEl = undefined;

export function initialize(domSection) {
    noIdeasEl = document.querySelector('#no-ideas');
    noIdeasEl.classList.add('hidden');
    section = domSection;
}

export async function getView() {
    await populateIdeas();
    return section;
}

async function populateIdeas() {
    try {
        const url =
            'http://localhost:3030/data/ideas?select=_id%2Ctitle%2Cimg&sortBy=_createdOn%20desc';
        const ideas = await jsonRequest(url, 'GET');
        if (ideas.length === 0) {
            noIdeasEl.classList.remove('hidden');
        } else {
            section.querySelectorAll('.idea').forEach((i) => i.remove());
            section.append(...ideas.map((i) => createHTMLIdea(i)));
        }
    } catch (err) {
        console.log(err);
        alert(err);
    }
}

function createHTMLIdea(idea) {
    // <div
    //     class="card overflow-hidden current-card details"
    //     style="width: 20rem; height: 18rem"
    // >
    //     <div class="card-body">
    //         <p class="card-text">Dinner Recipe</p>
    //     </div>
    //     <img
    //         class="card-image"
    //         src="./images/dinner.jpg"
    //         alt="Card image cap"
    //     />
    //     <a class="btn link" href="#">
    //         Details
    //     </a>
    // </div>;
    const ideaCardDiv = ce('div', {
        class: 'card overflow-hidden current-card details idea',
        style: 'width: 20rem; height: 18rem',
    });
    const ideaCardBodyDiv = ce('div', { class: 'card-body' });
    const titleP = ce('p', { class: 'card-text' }, idea.title);
    const imgEl = ce('img', {
        class: 'card-image',
        src: `${idea.img}`,
        alt: 'Card image cap',
    });
    const aEl = ce(
        'a',
        {
            'class': 'btn link',
            'href': `#/details/${idea._id}`,
            'data-route': `details/${idea._id}`,
        },
        'Details'
    );

    aEl.addEventListener('click', viewFinder.navigationHangler);

    ideaCardBodyDiv.appendChild(titleP);
    ideaCardDiv.appendChild(ideaCardBodyDiv);
    ideaCardDiv.appendChild(imgEl);
    ideaCardDiv.appendChild(aEl);

    return ideaCardDiv;
}

const dashboardPage = {
    initialize,
    getView,
};

export default dashboardPage;
