import { html } from '../../node_modules/lit-html/lit-html.js';

export const homeTemplate = () => html`
    <div class="row space-top">
        <div class="col-md-12">
            <h1>Welcome to Furniture System</h1>
            <p>Select furniture from the catalog to view details.</p>
        </div>
    </div>
`;

export const furnitureTemplate = (furniture) => html`
    <div class="col-md-4">
        <div class="card text-white bg-primary">
            <div class="card-body">
                <img src="./images/table.png" />
                <p>Description here</p>
                <footer>
                    <p>Price: <span>235 $</span></p>
                </footer>
                <div>
                    <a href="#" class="btn btn-info">Details</a>
                </div>
            </div>
        </div>
    </div>
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