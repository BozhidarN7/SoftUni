import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import carService from '../services/carService.js';

const detailsTemplate = (info) => html` <section id="listing-details">
    <h1>Details</h1>
    <div class="details-info">
        <img src="${info.car.imageUrl}" />
        <hr />
        <ul class="listing-props">
            <li><span>Brand:</span>${info.car.brand}</li>
            <li><span>Model:</span>${info.car.model}</li>
            <li><span>Year:</span>${info.car.year}</li>
            <li><span>Price:</span>${info.car.price}$</li>
        </ul>

        <p class="description-para">${info.car.description}</p>
        ${info.userId === info.car._ownerId
            ? html` <div class="listings-buttons">
                  <a href="/edit/${info.car._id}" class="button-list">Edit</a>
                  <a
                      href="javascript:void(0)"
                      @click=${info.deleteHandler}
                      class="button-list"
                      >Delete</a
                  >
              </div>`
            : ''}
    </div>
</section>`;

async function deleteHandler(context, e) {
    e.preventDefault();

    if (confirm('Are you sure you want to delete this car ad')) {
        try {
            await carService.del(context.params.id);
            context.page.redirect('/allListings');
        } catch (err) {
            alert(err);
            console.log(err);
        }
    }
}

export async function getDetailsPage(context) {
    const car = await carService.getById(context.params.id);
    const info = {
        deleteHandler: deleteHandler.bind(null, context),
        car,
        userId: authService.getUserId(),
    };
    const templateResult = detailsTemplate(info);
    context.renderView(templateResult);
}
