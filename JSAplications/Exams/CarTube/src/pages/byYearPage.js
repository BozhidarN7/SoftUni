import { html } from '../../node_modules/lit-html/lit-html.js';
import carService from '../services/carService.js';

const byYearTemplate = (info) => html` <section id="search-cars">
    <h1>Filter by year</h1>

    <div class="container">
        <input
            id="search-input"
            type="text"
            name="search"
            placeholder="Enter desired production year"
        />
        <button @click=${info.searchHandler} class="button-list">Search</button>
    </div>

    <h2>Results:</h2>
    <div class="listings">
        ${info.cars && info.cars.length > 0
            ? info.cars.map((c) => carTemplate(c))
            : html`<p class="no-cars">No results.</p>`}
    </div>
</section>`;

const carTemplate = (car) => html`<div class="listing">
    <div class="preview">
        <img src="${car.imageUrl}" />
    </div>
    <h2>${car.brand} ${car.model}</h2>
    <div class="info">
        <div class="data-info">
            <h3>Year: ${car.year}</h3>
            <h3>Price: ${car.price} $</h3>
        </div>
        <div class="data-buttons">
            <a href="/details/${car._id}" class="button-carDetails">Details</a>
        </div>
    </div>
</div>`;

async function searchHandler(context, e) {
    e.preventDefault();
    const year = Number(e.target.previousElementSibling.value);

    const cars = await carService.getByYear(year);
    const info = {
        searchHandler: searchHandler.bind(null, context),
        cars,
    };
    const templateResult = byYearTemplate(info);
    context.renderView(templateResult);
}

export function getByYearPage(context) {
    const info = {
        searchHandler: searchHandler.bind(null, context),
        cars: undefined,
    };
    const templateResult = byYearTemplate(info);
    context.renderView(templateResult);
}
