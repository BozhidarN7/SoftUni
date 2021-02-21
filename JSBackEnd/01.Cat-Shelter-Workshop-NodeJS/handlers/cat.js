const url = require('url');
const fs = require('fs');
const path = require('path');
const qs = require('querystring');
const formidable = require('formidable');

const breeds = require('../data/breeds');
const cats = require('../data/cats');

const globalPath = __dirname.toString().replace('handlers', '');

module.exports = (req, res) => {
    const pathname = url.parse(req.url).pathname;

    if (pathname === '/cats/add-cat' && req.method === 'GET') {
        const filePath = path.normalize(path.join(__dirname, '../views/addCat.html'));
        fs.readFile(filePath, (err, data) => {
            if (err) {
                res.writeHead(404, { 'Content-Type': 'text/plain' });

                res.write('Page not found!');
                res.end();
                return;
            }
            const catBreedPlaceholder = breeds.map((breed => `<option value="${breed}">${breed}</option>`));
            const modifiedData = data.toString().replace('{{catBreeds}}', catBreedPlaceholder);
            res.writeHead(200, { 'Content-Type': 'text/html' });
            res.write(modifiedData);
            res.end();
        });

    } else if (pathname === '/cats/add-breed' && req.method === 'GET') {
        const filePath = path.normalize(path.join(__dirname, '../views/addBreed.html'));
        fs.readFile(filePath, (err, data) => {
            if (err) {
                res.writeHead(404, { 'Content-Type': 'text/plain' });

                res.write('Page not found!');
                res.end();
                return;
            }
            res.writeHead(200, { 'Content-Type': 'text/html' });
            res.write(data);
            res.end();
        });
    } else if (pathname === '/cats/add-breed' && req.method === 'POST') {
        let formData = '';

        req.on('data', (data) => {
            formData += data;
        });
        console.log(formData);
        req.on('end', () => {
            let body = qs.parse(formData);

            fs.readFile('./data/breeds.json', (err, data) => {
                if (err) {
                    throw err;
                }
                let breeds = JSON.parse(data);
                breeds.push(body.breed);
                const json = JSON.stringify(breeds);

                fs.writeFile('./data/breeds.json', json, 'utf-8', () => console.log('The breed was uploaded successfully'));
            });

            res.writeHead(301, { 'location': '/' });
            res.end();
        });
    } else if (pathname === '/cats/add-cat' && req.method === 'POST') {
        let form = new formidable.IncomingForm();
        form.uploadDir = 'content/images';
        form.parse(req, (err, fields, files) => {
            const oldPath = files.upload.path;
            console.log(oldPath);
            const newPath = path.normalize(path.join(globalPath, '/content/images/' + files.upload.name));
            fs.rename(oldPath, newPath, (err) => {
                if (err) {
                    console.log(err);
                    throw err;
                }
            });

            fs.readFile('./data/cats.json', (err, data) => {
                if (err) {
                    throw err;
                }
                const allCats = JSON.parse(data);
                allCats.push({ id: (cats.length + 1).toString(), ...fields, image: files.upload.name });
                const json = JSON.stringify(allCats);

                fs.writeFile('./data/cats.json', json, (err) => {
                    if (err) {
                        throw err;
                    }
                });
            });
            res.writeHead(301, { 'location': '/' });
            res.end();
        });
    } else {
        return true;
    }
};