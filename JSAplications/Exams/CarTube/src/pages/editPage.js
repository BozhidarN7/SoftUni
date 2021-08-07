import { html } from '../../node_modules/lit-html/lit-html.js';
import carService from '../services/carService.js';

const editTemplate = (formInfo) => html` <section id="edit-listing">
    <div class="container">
        <form @submit=${formInfo.submitHandler} id="edit-form">
            <h1>Edit Car Listing</h1>
            <p>Please fill in this form to edit an listing.</p>
            <hr />

            <p>Car Brand</p>
            <input
                type="text"
                placeholder="Enter Car Brand"
                name="brand"
                .value=${formInfo.car.brand}
            />

            <p>Car Model</p>
            <input
                type="text"
                placeholder="Enter Car Model"
                name="model"
                .value=${formInfo.car.model}
            />

            <p>Description</p>
            <input
                type="text"
                placeholder="Enter Description"
                name="description"
                .value=${formInfo.car.description}
            />

            <p>Car Year</p>
            <input
                type="number"
                placeholder="Enter Car Year"
                name="year"
                .value=${formInfo.car.year}
            />

            <p>Car Image</p>
            <input
                type="text"
                placeholder="Enter Car Image"
                name="imageUrl"
                .value=${formInfo.car.imageUrl}
            />

            <p>Car Price</p>
            <input
                type="number"
                placeholder="Enter Car Price"
                name="price"
                .value=${formInfo.car.price}
            />

            <hr />
            <input type="submit" class="registerbtn" value="Edit Listing" />
        </form>
    </div>
</section>`;

async function submitHandler(context, e) {
    e.preventDefault();

    const data = new FormData(e.currentTarget);
    const brand = data.get('brand');
    const model = data.get('model');
    const description = data.get('description');
    const year = Number(data.get('year'));
    const imageUrl = data.get('imageUrl');
    const price = Number(data.get('price'));

    if (!model || !brand || !description || !price || !imageUrl || !year) {
        alert('All fields are required!');
        return;
    }

    if (price < 0) {
        alert('Price must be positive value!');
        return;
    }
    if (year < 0) {
        alert('Year must be positive value');
        return;
    }

    try {
        await carService.edit(context.params.id, {
            brand,
            model,
            description,
            year,
            imageUrl,
            price,
        });
        context.page.redirect(`/details/${context.params.id}`);
    } catch (err) {
        alert(err);
        console.log(err);
    }
}

export async function getEditPage(context) {
    const id = context.params.id;
    const car = await carService.getById(id);
    const formInfo = {
        submitHandler: submitHandler.bind(null, context),
        car,
    };
    const templateResult = editTemplate(formInfo);
    context.renderView(templateResult);
}
