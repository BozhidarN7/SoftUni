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
                                  ? html`<a
                                        @click=${info.cancelHandler}
                                        href="#"
                                        class="action invert"
                                        >Leave team</a
                                    >`
                                  : ''}
                              ${info.canCancel
                                  ? html` Membership pending.
                                        <a @click=${info.cancelHandler} href="#"
                                            >Cancel request</a
                                        >`
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
                                    pendingMembersTemplate(m, info)
                                )}
                            </ul>
                        </div>`
                      : ''}`
                : ''}
        </article>
    </section>
`;

const pendingMembersTemplate = (member, info) => html`
    <li>
        ${member.user.username}
        ${info.team._ownerId === info.ownerId
            ? html`<a
                      @click=${info.approveHandler}
                      href="#"
                      class="tm-control action"
                      >Approve</a
                  >
                  <a
                      @click=${info.cancelHandler}
                      href="#"
                      class="tm-control action"
                      >Decline</a
                  >`
            : ''}
    </li>
`;

async function joinHandler(context, teamId, e) {
    e.preventDefault();

    const membershipResponse = await memberService.join(teamId);
    getData(context);
}

async function approveHandler(context, teamId, e) {
    e.preventDefault();

    const username = e.target.parentElement.innerText.split(' ')[0];
    const members = await memberService.getAllMemberships(teamId);
    const membershipRequestId = members.find(
        (m) => m.user.username === username
    )?._id;
    const approveResponse = await memberService.approve(membershipRequestId);
    getData(context);
}

async function cancelHandler(context, teamId, e) {
    e.preventDefault();
    if (
        e.target.textContent === 'Cancel request' ||
        e.target.textContent === 'Leave team'
    ) {
        const members = await memberService.getAllMemberships(teamId);
        const membershipRequestId = members.find(
            (m) => m.user.username === authService.getUsername()
        )?._id;
        const cancelResponse = await memberService.decline(membershipRequestId);
        getData(context);
    } else if (e.target.textContent === 'Decline') {
        const username = e.target.parentElement.innerText.split(' ')[0];
        const members = await memberService.getAllMemberships(teamId);
        const membershipRequestId = members.find(
            (m) => m.user.username === username
        )?._id;
        const declineResponse = await memberService.decline(
            membershipRequestId
        );
        getData(context);
    }
}

async function getData(context) {
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
        cancelHandler: cancelHandler.bind(null, context, team._id),
        approveHandler: approveHandler.bind(null, context, team._id),
    };
    const templateResult = detailsTemplate(info);
    context.renderView(templateResult);
}

export async function getDetailsPage(context) {
    getData(context);
}
