import { html } from '../../node_modules/lit-html/lit-html.js';
import carService from '../services/carService.js';

const byYearTemplate = (searchHandler, cars) => html`
    <section id="search-cars">
        <h1>Filter by year</h1>

        <div class="container">
            <input
                id="search-input"
                type="text"
                name="search"
                placeholder="Enter desired production year"
            />
            <button @click=${searchHandler} class="button-list">Search</button>
        </div>

        <h2>Results:</h2>
        <div class="listings">
            ${cars.length > 0
                ? cars.map((c) => carTemplate(c))
                : html` <p class="no-cars">No results.</p>`}
        </div>
    </section>
`;

const carTemplate = (car) => html`
    <div class="listings">
        <div class="listing">
            <div class="preview">
                <img
                    src="${car.imageUrl.startsWith('/')
                        ? `../../${car.imageUrl}`
                        : `${car.imageUrl}`}"
                />
            </div>
            <h2>${car.brand} ${car.model}</h2>
            <div class="info">
                <div class="data-info">
                    <h3>Year: ${car.year}</h3>
                    <h3>Price: ${car.price} $</h3>
                </div>
                <div class="data-buttons">
                    <a href="/details/${car._id}" class="button-carDetails"
                        >Details</a
                    >
                </div>
            </div>
        </div>
    </div>
`;

let searchHandler = undefined;
async function search(context, e) {
    e.preventDefault();
    const year = Number(e.target.previousElementSibling.value);
    if (!year || year < 0) {
        alert('You must enter a valid year!');
        return;
    }

    const cars = await carService.getByYear(year);
    context.renderView(byYearTemplate(searchHandler, cars));
}

export function getByYearPage(context) {
    searchHandler = search.bind(null, context);
    const templateResult = byYearTemplate(searchHandler, []);
    context.renderView(templateResult);
}
