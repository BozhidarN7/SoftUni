import { html } from '../../node_modules/lit-html/lit-html.js';
import jobService from '../services/jobService.js';

const allJobsTeamplate = (info) => html`<section id="browse">
    <article class="pad-med">
        <h1>Job Browser</h1>
    </article>
    ${info.jobs.map((j) => jobTemplate(j))}
</section> `;

const jobTemplate = (job) => html`
    <article class="layout">
        <img src="${job.imageUrl}" class="team-logo left-col" />
        <div class="tm-preview">
            <h2>${job.title}</h2>
            <div>
                <a href="/details/${job._id}" class="action">See details</a>
            </div>
        </div>
    </article>
`;

export async function getJobsPage(context) {
    let jobs = await jobService.getAll();

    const info = {
        jobs,
    };
    const templateResult = allJobsTeamplate(info);

    context.renderView(templateResult);
}
