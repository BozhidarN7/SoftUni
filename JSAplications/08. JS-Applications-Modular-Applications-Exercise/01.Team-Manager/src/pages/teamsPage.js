import { html } from '../../node_modules/lit-html/lit-html.js';
import authService from '../services/authService.js';
import memberService from '../services/memberService.js';
import teamService from '../services/teamService.js';

const allTeamsTeamplate = (info) => html`<section id="browse">
    <article class="pad-med">
        <h1>Team Browser</h1>
    </article>

    ${info.isLoggedIn
        ? html` <article class="layout narrow">
              <div class="pad-small">
                  <a href="#" class="action cta">Create Team</a>
              </div>
          </article>`
        : ''}
    ${info.teams.map((t) => teamTemplate(t))}
</section> `;

const teamTemplate = (team) => html`
    <article class="layout">
        <img src="${team.logoUrl}" class="team-logo left-col" />
        <div class="tm-preview">
            <h2>${team.name}</h2>
            <p>${team.description}</p>
            <span class="details">${team.membersCount}</span>
            <div>
                <a href="#" class="action">See details</a>
            </div>
        </div>
    </article>
`;

export async function getTeamsPage(context) {
    let teams = await teamService.getAll();
    const members = await memberService.getAll();
    teams = teams.map((t) => {
        const teamMembers = members.filter((m) => m.teamId === t._id);
        t.membersCount = teamMembers.length;
        return t;
    });
    const info = {
        teams,
        isLoggedIn: authService.isLoggeddIn(),
    };
    const templateResult = allTeamsTeamplate(info);

    context.renderView(templateResult);
}
