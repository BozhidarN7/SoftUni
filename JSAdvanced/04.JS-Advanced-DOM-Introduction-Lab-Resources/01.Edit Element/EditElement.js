function editElement(element, match, replacer) {
    const pattern = new RegExp(match, 'g');
    element.textContent = element.textContent.replace(pattern, replacer);
}
