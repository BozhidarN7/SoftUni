import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import memberService from '../services/memberService.js';

const myTeamsTemplate = (info) => html`
    <section id="my-teams">
        <article class="pad-med">
            <h1>My Teams</h1>
        </article>

        ${info.teams.length > 0
            ? html`${info.teams.map((t) => teamTemplate(t))}`
            : html`<article class="layout narrow">
                  <div class="pad-med">
                      <p>You are not a member of any team yet.</p>
                      <p>
                          <a href="/teams">Browse all teams</a> to join one, or
                          use the button bellow to cerate your own team.
                      </p>
                  </div>
                  <div class="">
                      <a href="/create" class="action cta">Create Team</a>
                  </div>
              </article>`}
    </section>
`;

const teamTemplate = (team) => html`
    <article class="layout">
        <img src="${team.team.logoUrl}" class="team-logo left-col" />
        <div class="tm-preview">
            <h2>${team.team.name}</h2>
            <p>${team.team.description}</p>
            <span class="details">${team.membersCount}</span>
            <div>
                <a href="/details/${team.team._id}" class="action"
                    >See details</a
                >
            </div>
        </div>
    </article>
`;

export async function getMyTeamsPage(context) {
    let teams = await memberService.getMyMemberships(authService.getUserId());
    const iDs = teams.map((t) => t.teamId);
    const iDsString = iDs
        .reduce((acc, cur) => {
            acc += `"${cur}",`;
            return acc;
        }, '')
        .slice(0, -1);
    const queryObj = `where=teamId IN (${iDsString}) AND status="member"`;
    const members = await memberService.getListOfAllMembersInTeams(
        encodeURIComponent(queryObj)
    );

    teams = teams.map((t) => {
        t.membersCount = members.filter((m) => m.teamId === t.teamId).length;
        return t;
    });

    const info = {
        teams,
    };
    const templateResult = myTeamsTemplate(info);
    context.renderView(templateResult);
}
