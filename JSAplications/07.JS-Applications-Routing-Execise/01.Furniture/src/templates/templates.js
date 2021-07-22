import { html } from '../../node_modules/lit-html/lit-html.js';
import { ifDefined } from '../../node_modules/lit-html/directives/if-defined.js';
import auth from '../services/authService.js';

export const homeTemplate = (furnitures) => html`
    <div class="row space-top">
        <div class="col-md-12">
            <h1>Welcome to Furniture System</h1>
            <p>Select furniture from the catalog to view details.</p>
        </div>
        <div class="row space-top">
            ${furnitures.map((f) => furnitureTemplate(f))}
        </div>
    </div>
`;

export const furnitureTemplate = (furniture) => html`
    <div data-id="${furniture._id}" class="col-md-4">
        <div class="card text-white bg-primary">
            <div class="card-body">
                <img
                    src="${furniture.img.startsWith('./')
                        ? `../../${furniture.img.slice(2)}`
                        : furniture.img}"
                />
                <p>Description here</p>
                <footer>
                    <p>Price: <span>${furniture.price} $</span></p>
                </footer>
                <div>
                    <a href="/details/${furniture._id}" class="btn btn-info"
                        >Details</a
                    >
                </div>
            </div>
        </div>
    </div>
`;

export const detailsTemplate = (furniture) => html`
    <div class="row space-top">
        <div class="col-md-12">
            <h1>Furniture Details</h1>
        </div>
    </div>
    <div class="row space-top">
        <div data-id="${furniture._id}" class="col-md-4">
            <div class="card text-white bg-primary">
                <div class="card-body">
                    <img
                        src="${furniture.img.startsWith('./')
                            ? `../../${furniture.img.slice(2)}`
                            : furniture.img}"
                    />
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <p>Make: <span>${furniture.make}</span></p>
            <p>Model: <span>${furniture.model}</span></p>
            <p>Year: <span>${furniture.year}</span></p>
            <p>Description: <span>${furniture.description}</span></p>
            <p>Price: <span>${furniture.price}</span></p>
            <p>Material: <span>${furniture.material}</span></p>
            <div
                class="${furniture._ownerId === auth.getUserId()
                    ? ''
                    : 'hidden'}"
            >
                <a href="/edit/${furniture._id}" class="btn btn-info">Edit</a>
                <a href="/delete/${furniture._id}" class="btn btn-red"
                    >Delete</a
                >
            </div>
        </div>
    </div>
`;

export const createTemplate = (furniture, isEdit) => html`
    <div class="row space-top">
        <div class="col-md-12">
            <h1>Create New Furniture</h1>
            <p>Please fill all fields.</p>
        </div>
    </div>
    <form>
        <div class="row space-top">
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-control-label" for="new-make"
                        >Make</label
                    >
                    <input
                        class="form-control valid"
                        id="new-make"
                        type="text"
                        name="make"
                        .value="${ifDefined(furniture?.make)}"
                    />
                </div>
                <div class="form-group has-success">
                    <label class="form-control-label" for="new-model"
                        >Model</label
                    >
                    <input
                        class="form-control is-valid"
                        id="new-model"
                        type="text"
                        name="model"
                        .value="${ifDefined(furniture?.model)}"
                    />
                </div>
                <div class="form-group has-danger">
                    <label class="form-control-label" for="new-year"
                        >Year</label
                    >
                    <input
                        class="form-control is-invalid"
                        id="new-year"
                        type="number"
                        name="year"
                        .value="${ifDefined(furniture?.year)}"
                    />
                </div>
                <div class="form-group">
                    <label class="form-control-label" for="new-description"
                        >Description</label
                    >
                    <input
                        class="form-control"
                        id="new-description"
                        type="text"
                        name="description"
                        .value="${ifDefined(furniture?.description)}"
                    />
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-control-label" for="new-price"
                        >Price</label
                    >
                    <input
                        class="form-control"
                        id="new-price"
                        type="number"
                        name="price"
                        .value="${ifDefined(furniture?.price)}"
                    />
                </div>
                <div class="form-group">
                    <label class="form-control-label" for="new-image"
                        >Image</label
                    >
                    <input
                        class="form-control"
                        id="new-image"
                        type="text"
                        name="img"
                        .value="${ifDefined(furniture?.img)}"
                    />
                </div>
                <div class="form-group">
                    <label class="form-control-label" for="new-material"
                        >Material (optional)</label
                    >
                    <input
                        class="form-control"
                        id="new-material"
                        type="text"
                        name="material"
                        .value="${ifDefined(furniture?.material)}"
                    />
                </div>
                <input
                    type="submit"
                    class="btn btn-primary"
                    .value="${isEdit ? 'Edit' : 'Create'}"
                />
            </div>
        </div>
    </form>
`;

export const loginTemplate = () => html`
    <div class="row space-top">
        <div class="col-md-12">
            <h1>Login User</h1>
            <p>Please fill all fields.</p>
        </div>
    </div>
    <form>
        <div class="row space-top">
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-control-label" for="email">Email</label>
                    <input
                        class="form-control"
                        id="email"
                        type="text"
                        name="email"
                    />
                </div>
                <div class="form-group">
                    <label class="form-control-label" for="password"
                        >Password</label
                    >
                    <input
                        class="form-control"
                        id="password"
                        type="password"
                        name="password"
                    />
                </div>
                <input type="submit" class="btn btn-primary" value="Login" />
            </div>
        </div>
    </form>
`;

export const registerTemplate = () => html`
    <div class="row space-top">
        <div class="col-md-12">
            <h1>Register New User</h1>
            <p>Please fill all fields.</p>
        </div>
    </div>
    <form>
        <div class="row space-top">
            <div class="col-md-4">
                <div class="form-group">
                    <label class="form-control-label" for="email">Email</label>
                    <input
                        class="form-control"
                        id="email"
                        type="text"
                        name="email"
                    />
                </div>
                <div class="form-group">
                    <label class="form-control-label" for="password"
                        >Password</label
                    >
                    <input
                        class="form-control"
                        id="password"
                        type="password"
                        name="password"
                    />
                </div>
                <div class="form-group">
                    <label class="form-control-label" for="rePass"
                        >Repeat</label
                    >
                    <input
                        class="form-control"
                        id="rePass"
                        type="password"
                        name="rePass"
                    />
                </div>
                <input type="submit" class="btn btn-primary" value="Register" />
            </div>
        </div>
    </form>
`;
