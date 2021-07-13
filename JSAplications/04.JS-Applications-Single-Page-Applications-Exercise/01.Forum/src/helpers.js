function ce(tag, attributes, ...params) {
    const element = document.createElement(tag);
    const firstValue = params[0];
    if (params.length === 1 && typeof firstValue !== 'object') {
        if (['input', 'textarea'].includes(tag)) {
            element.value = firstValue;
        } else {
            element.textContent = firstValue;
        }
    } else {
        element.append(...params);
    }

    if (attributes) {
        Object.keys(attributes).forEach((key) => {
            element.setAttribute(key, attributes[key]);
        });
    }

    return element;
}
export default {
    baseUrl: 'http://localhost:3030/jsonstore/collections/myboard',
    ce,
};
