const url = require('url');
const fs = require('fs');
const path = require('path');
const formidable = require('formidable');

const cats = require('../data/cats');
const breeds = require('../data/breeds');
const { serialize } = require('v8');
const { format } = require('path');

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
            const searchForCat =
                `
             <form action="/" method="POST" enctype="multipart/form-data">
                <input name="name" type="text">
                <button type="submit">Search</button>
             </form>
            `;

            let modifiedData = data.toString().replace('{{cats}}', modifiedCats);
            modifiedData = modifiedData.replace('{{searchForCat}}', searchForCat);

            res.writeHead(200, { 'Content-Type': 'text/html' });
            res.write(modifiedData);
            res.end();
        });
    } else if (pathname === '/' && req.method === 'POST') {
        const filePath = path.normalize(path.join(__dirname, '../views/home/index.html'));
        fs.readFile(filePath, (err, page) => {
            if (err) {
                res.writeHead(404, { 'Content-Type': 'text/plain' });

                res.write('Page not found!');
                res.end();
                return;
            }
            const form = new formidable.IncomingForm();
            form.parse(req, (err, fields, files) => {
                fs.readFile('./data/cats.json', 'utf-8', (err, data) => {
                    if (err) {
                        throw err;
                    }

                    const neededCast = JSON.parse(data).filter(cat => cat.name.toLowerCase().includes(fields.name.toLowerCase()));
                    const modifiedCats = neededCast.map(cat =>
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
                    const searchForCat =
                        `
                     <form action="/" method="POST" enctype="multipart/form-data">
                        <input name="name" type="text">
                        <button type="submit">Search</button>
                     </form>
                    `;
                    let modifiedData = page.toString().replace('{{cats}}', modifiedCats);
                    modifiedData = modifiedData.replace('{{searchForCat}}', searchForCat);
                    res.writeHead(200, { 'Content-Type': 'text/html' });
                    res.write(modifiedData);
                    res.end();
                });
            });
        });
    } else {
        return true;
    }
}