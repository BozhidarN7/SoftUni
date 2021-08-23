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
                <span class="details">${info.team.membersCount} members</span>
                ${info.isLoggedIn
                    ? html`
                          <div>
                              ${info.team._ownerId === info.ownerId
                                  ? html`<a
                                        href="/edit/${info.team._id}"
                                        class="action"
                                        >Edit team</a
                                    >`
                                  : html`${info.canJoin
                                        ? html`<a
                                              href="#"
                                              @click=${info.joinHandler}
                                              class="action"
                                              >Join team</a
                                          >`
                                        : ''}`}
                              ${info.canLeave
                                  ? html`<a href="#" class="action invert"
                                        >Leave team</a
                                    >`
                                  : ''}
                              ${info.canCancel
                                  ? html` Membership pending.
                                        <a href="#">Cancel request</a>`
                                  : ''}
                          </div>
                      `
                    : ''}
            </div>
            <div class="pad-large">
                <h3>Members</h3>
                <ul class="tm-members">
                    ${info.joindedMembers.map(
                        (m) => html`<li>${m.user.username}</li>`
                    )}
                </ul>
            </div>
            ${info.isLoggedIn
                ? html`${info.pendingMembers.length > 0
                      ? html` <div class="pad-large">
                            <h3>Membership Requests</h3>
                            <ul class="tm-members">
                                ${info.pendingMembers.map((m) =>
                                    pendingMembersTemplate(m)
                                )}
                            </ul>
                        </div>`
                      : ''}`
                : ''}
        </article>
    </section>
`;

const pendingMembersTemplate = (member) => html`
    <li>
        ${member.user.username}<a href="#" class="tm-control action">Approve</a
        ><a href="#" class="tm-control action">Decline</a>
    </li>
`;

async function joinHandler(context, teamId, e) {
    e.preventDefault();

    const res = await memberService.join(teamId);
    console.log(res);
}

export async function getDetailsPage(context) {
    const team = await teamService.getById(context.params.id);
    const members = await memberService.getAllMemberships(team._id);
    const joindedMembers = members.filter((m) => m.status === 'member');
    const pendingMembers = members.filter((m) => m.status === 'pending');

    const canJoin = members.find((m) => m.user._id === authService.getUserId())
        ? false
        : true;

    const canLeave = members.find(
        (m) => m.user._id === authService.getUserId() && m.status !== 'pending'
    )
        ? true
        : false;

    const canCancel = members.find(
        (m) => m.user._id === authService.getUserId() && m.status === 'pending'
    );

    console.log(members);

    team.membersCount = joindedMembers.length;
    const info = {
        team,
        joindedMembers,
        pendingMembers,
        ownerId: authService.getUserId(),
        isLoggedIn: authService.isLoggeddIn(),
        canJoin,
        canLeave,
        canCancel,
        joinHandler: joinHandler.bind(null, context, team._id),
    };
    const templateResult = detailsTemplate(info);
    context.renderView(templateResult);
}
