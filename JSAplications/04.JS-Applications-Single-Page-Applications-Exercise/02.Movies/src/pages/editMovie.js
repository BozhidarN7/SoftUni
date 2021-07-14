let section = undefined;

export function initialize(domSection) {
    section = domSection;
}

export async function getView() {
    return section;
}

let editMoviePage = {
    initialize,
    getView,
};

export default editMoviePage;
