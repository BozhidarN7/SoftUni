import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import memberService from '../services/memberService.js';
import teamService from '../services/teamService.js';

const detailsTemplate = (info) => html`
    <section id="team-home">
        <article class="layout">
            <img src="${info.team.logoUrl}" class="team-logo left-col" />
            <div class="tm-preview">
                <h2>${info.team.name}</h2>
                <p>${info.team.description}</p>
                <span class="details">${info.team.membersCount}</span>
                <div>
                    ${info.team._ownerId === info.ownerId
                        ? html`<a href="/edit/${info.team._id}" class="action"
                              >Edit team</a
                          >`
                        : html`<a href="#" class="action">Join team</a>`}

                    <a href="#" class="action invert">Leave team</a>
                    Membership pending.
                    <a href="#">Cancel request</a>
                </div>
            </div>
            <div class="pad-large">
                <h3>Members</h3>
                <ul class="tm-members">
                    <li>My Username</li>
                    <li>
                        James<a href="#" class="tm-control action"
                            >Remove from team</a
                        >
                    </li>
                    <li>
                        Meowth<a href="#" class="tm-control action"
                            >Remove from team</a
                        >
                    </li>
                </ul>
            </div>
            <div class="pad-large">
                <h3>Membership Requests</h3>
                <ul class="tm-members">
                    <li>
                        John<a href="#" class="tm-control action">Approve</a
                        ><a href="#" class="tm-control action">Decline</a>
                    </li>
                    <li>
                        Preya<a href="#" class="tm-control action">Approve</a
                        ><a href="#" class="tm-control action">Decline</a>
                    </li>
                </ul>
            </div>
        </article>
    </section>
`;

export async function getDetailsPage(context) {
    const team = await teamService.getById(context.params.id);
    const members = await memberService.getAll();
    team.membersCount = members.filter((m) => m.teamId === team._id).length;
    const info = {
        team,
        ownerId: authService.getUserId(),
    };
    const templateResult = detailsTemplate(info);
    context.renderView(templateResult);
}
