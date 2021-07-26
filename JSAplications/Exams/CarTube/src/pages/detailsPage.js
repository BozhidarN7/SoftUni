import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import carService from '../services/carService.js';

const detailsTemplate = (car) => html`
    <section id="listing-details">
        <h1>Details</h1>
        <div class="details-info">
            <img
                src="${car.imageUrl.startsWith('/')
                    ? `../../${car.imageUrl}`
                    : `${car.imageUrl}`}"
            />
            <hr />
            <ul class="listing-props">
                <li><span>Brand:</span>${car.brand}</li>
                <li><span>Model:</span>${car.model}</li>
                <li><span>Year:</span>${car.year}</li>
                <li><span>Price:</span>${car.price}$</li>
            </ul>

            <p class="description-para">${car.description}</p>
            ${car._ownerId === authService.getUserId()
                ? html`<div class="listings-buttons">
                      <a href="/edit/${car._id}" class="button-list">Edit</a>
                      <a href="/delete/${car._id}" class="button-list"
                          >Delete</a
                      >
                  </div>`
                : ''}
        </div>
    </section>
`;

export async function getDetailsPage(context) {
    const car = await carService.getById(context.params.id);
    const templateResult = detailsTemplate(car);
    context.renderView(templateResult);
}
