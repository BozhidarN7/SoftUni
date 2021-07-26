import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import carService from '../services/carService.js';

const myListingsTemplate = (cars) => html`
    <section id="my-listings">
        <h1>My car listings</h1>
        <div class="listings">
            ${cars.length > 0
                ? cars.map((c) => carTemplate(c))
                : html` <p class="no-cars">
                      You haven't listed any cars yet.
                  </p>`}
        </div>
    </section>
`;

const carTemplate = (car) => html`
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
`;

export async function getMyListingsPage(context) {
    const cars = await carService.getMyCars(authService.getUserId());
    const templateResult = myListingsTemplate(cars);
    context.renderView(templateResult);
}
