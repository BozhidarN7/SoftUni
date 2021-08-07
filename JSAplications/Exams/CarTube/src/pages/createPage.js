import { html } from '../../node_modules/lit-html/lit-html.js';
import carService from '../services/carService.js';

const createTemplate = (formInfo) => html`
    <section id="create-listing">
        <div class="container">
            <form @submit=${formInfo.submitHandler} id="create-form">
                <h1>Create Car Listing</h1>
                <p>Please fill in this form to create an listing.</p>
                <hr />

                <p>Car Brand</p>
                <input type="text" placeholder="Enter Car Brand" name="brand" />

                <p>Car Model</p>
                <input type="text" placeholder="Enter Car Model" name="model" />

                <p>Description</p>
                <input
                    type="text"
                    placeholder="Enter Description"
                    name="description"
                />

                <p>Car Year</p>
                <input type="number" placeholder="Enter Car Year" name="year" />

                <p>Car Image</p>
                <input
                    type="text"
                    placeholder="Enter Car Image"
                    name="imageUrl"
                />

                <p>Car Price</p>
                <input
                    type="number"
                    placeholder="Enter Car Price"
                    name="price"
                />

                <hr />
                <input
                    type="submit"
                    class="registerbtn"
                    value="Create Listing"
                />
            </form>
        </div>
    </section>
`;

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
        await carService.create({
            brand,
            model,
            description,
            year,
            imageUrl,
            price,
        });
        context.page.redirect('/allListings');
    } catch (err) {
        alert(err);
        console.log(err);
    }
}

export function getCreatePage(context) {
    const formInfo = {
        submitHandler: submitHandler.bind(null, context),
    };
    const templateResult = createTemplate(formInfo);
    context.renderView(templateResult);
}
