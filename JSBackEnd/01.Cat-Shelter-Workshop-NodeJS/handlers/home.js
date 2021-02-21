const url = require('url');
const fs = require('fs');
const path = require('path');

const cats = require('../data/cats');
const breeds = require('../data/breeds');

module.exports = (req, res) => {
    const pathname = url.parse(req.url).pathname;

    if (pathname === '/' && req.method === 'GET') {
        let filePath = path.normalize(path.join(__dirname, '../views/home/index.html'));
        fs.readFile(filePath, (err, data) => {
            if (err) {
                res.writeHead(404, { 'Content-Type': 'text/plain' });

                res.write('Page not found!');
                res.end();
                return;
            }
            const modifiedCats = cats.map(cat =>
                `
                 <li>
                    <img src="${path.join('../content/images/' + cat.image)}" alt="${cat.name}">
                    <h3>${cat.name}</h3>
                    <p><span>Breed: </span>${cat.breed}</p>
                    <p><span>Description: </span>${cat.description}</p>
                    <ul class="buttons">
                        <li class="btn edit"><a href="/cats-edit/${cat.id}">Change Info</a></li>
                        <li class="btn delete"><a href="/cats-find-new-home/${cat.id}">New Home</a></li>
                    </ul>
                    </li>
                `);
            const modifiedData = data.toString().replace('{{cats}}', modifiedCats);
            res.writeHead(200, { 'Content-Type': 'text/html' });
            res.write(modifiedData);
            res.end();
        });
    } else {
        return true;
    }
}