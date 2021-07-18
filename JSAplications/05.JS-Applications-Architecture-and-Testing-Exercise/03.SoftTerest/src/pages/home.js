let section = undefined;

export function initialize(domSection) {
    section = domSection;
}

export async function getView() {
    return section;
}

const homePage = {
    initialize,
    getView,
};

export default homePage;
