function getArticleGenerator(articles) {
    const container = document.querySelector('#content');
    return () => {
        if (!articles.length) {
            return;
        }
        const newArticleEl = document.createElement('article');
        newArticleEl.textContent = articles.shift();
        container.appendChild(newArticleEl);
    };
}
