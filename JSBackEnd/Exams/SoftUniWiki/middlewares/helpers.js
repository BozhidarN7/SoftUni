function takeFiftyWords(articles) {
    articles.forEach(x => {
        x.description = x.description.split(' ', 50).join(' ');
    });
}

module.exports = {
    takeFiftyWords
}