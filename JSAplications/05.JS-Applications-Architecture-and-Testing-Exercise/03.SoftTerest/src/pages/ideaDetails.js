import { jsonRequest } from '../services/httpService.js';
import { ce } from '../helpers/htmlHelper.js';
import auth from '../services/authService.js';
import viewFinder from '../viewFinder.js';

let section = undefined;
let linkClass = undefined;

export function initialize(domSection, viewLinkClass) {
    section = domSection;
    linkClass = viewLinkClass;
}

export async function getView(ideaId) {
    const idea = await jsonRequest(
        `http://localhost:3030/data/ideas/${ideaId}`
    );
    [...section.children].forEach((el) => el.remove());
    createIdeaInfo(idea);

    return section;
}

export async function deleteIdea(ideaId) {
    try {
        let deleteResult = await jsonRequest(
            `http://localhost:3030/data/ideas/${ideaId}`,
            'DELETE',
            undefined,
            true
        );
        return viewFinder.redirectTo('dashboard');
    } catch (err) {
        console.error(err);
        alert(err);
    }
}

function createIdeaInfo(idea) {
    console.log(idea);
    const img = ce('img', { class: 'det-img', src: `${idea.img}` });
    const descDiv = ce('div', { class: 'desc' });
    const headingEl = ce('h2', { class: 'display-5' }, idea.title);
    const descParagraph = ce('p', { class: 'infoType' }, 'Description');
    const descParagraphContent = ce(
        'p',
        { class: 'idea-description' },
        idea.description
    );
    const deleteDiv = ce('div', { class: 'text-center' });
    if (idea._ownerId === auth.getUserId()) {
        const aEl = ce(
            'a',
            {
                'class': 'btn detb link',
                'href': `#/delete/${idea._id}`,
                'data-route': `delete/${idea._id}`,
            },
            'Delete'
        );
        aEl.addEventListener('click', viewFinder.navigationHangler);
        deleteDiv.appendChild(aEl);
    }

    descDiv.appendChild(headingEl);
    descDiv.appendChild(descParagraph);
    descDiv.appendChild(descParagraphContent);

    section.appendChild(img);
    section.appendChild(descDiv);
    section.appendChild(deleteDiv);
}
const ideaDetailsPage = {
    initialize,
    getView,
    deleteIdea,
};

export default ideaDetailsPage;
