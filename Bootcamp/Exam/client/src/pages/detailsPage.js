import { html } from '../../node_modules/lit-html/lit-html.js';
import candidateService from '../services/candidateService.js';
import interviewService from '../services/interviewService.js';
import jobService from '../services/jobService.js';

const detailsTemplate = (info) => html`
    <section id="team-home">
        <article class="layout">
            <img src="${info.job.imageUrl}" class="team-logo left-col" />
            <div class="tm-preview">
                <h2>${info.job.title}</h2>
                <p>${info.job.description}</p>
                <a href="/edit/${info.job._id}" class="action">Edit job</a>
                <a
                    href="javascript:void(0)"
                    @click="${info.deleteHandler}"
                    class="action"
                    >Delete job</a
                >
            </div>
            <div class="tm-preview">
                <label for="candidates">Choose candidates: </label>
                <select
                    @change=${info.joinToPotentialCandidatesHandler}
                    class="action"
                    name="candidates"
                    id="candidates"
                >
                    <option hidden disabled selected value>
                        -- select a candidate --
                    </option>
                    ${info.candidatesWhoCanApplyForThisJob.map((c) =>
                        optionTemplate(c)
                    )}
                </select>
            </div>
            <div class="tm-preview">
                <label for="candidates">Book interview with candidate: </label>
                <select
                    @change=${info.addToInterviewHandler}
                    class="action"
                    name="candidates"
                    id="candidates"
                >
                    <option hidden disabled selected value>
                        -- select a candidate for interview --
                    </option>
                    ${info.allCandidatesForThisJob.map((c) =>
                        optionTemplate(c)
                    )}
                </select>
            </div>

            ${info.candidatesInInterviewList.length > 0
                ? html`
                      <div class="pad-large">
                          <h3>Candidate for interview</h3>
                          <ul class="tm-members">
                              ${info.candidatesInInterviewList.map((c) =>
                                  candidateForInterviewTemplate(c, info)
                              )}
                          </ul>
                      </div>
                  `
                : ''}
        </article>
    </section>
`;

const optionTemplate = (candidate) => html`
    <option
        data-candidateid="${candidate?._id}"
        .value="${candidate?.firstName} ${candidate?.lastName}"
    >
        ${candidate?.firstName} ${candidate?.lastName}
    </option>
`;

const candidateForInterviewTemplate = (candidate, info) => html`
    <li>
        ${candidate.firstName} ${candidate.lastName}
        <a
            href="javascript:void(0)"
            @click=${info.approveCandidateHandler}
            class="tm-control action"
            data-candidateid="${candidate._id}"
            >Approve</a
        >
        <a
            href="javascript:void(0)"
            @click=${info.rejectCandidateHandler}
            class="tm-control action"
            data-candidateid="${candidate._id}"
            >Reject</a
        >
    </li>
`;

async function addToInterviewHandler(context, e) {
    e.preventDefault();
    const jobId = context.params.id;
    const option = Array.from(e.target.children).find(
        (x) => x.value === e.target.value
    );
    const candidateId = option.dataset.candidateid;
    const candidateInterviews = await candidateService.getInterviews(
        candidateId
    );

    if (candidateInterviews.length > 0) {
        alert(
            'This candidate already is chosen for interview for another job! Try again later'
        );
        return;
    }
    const jobInterviews = await jobService.getInterviews(jobId);

    const slot = Number(prompt('Please enter a number of slots [1-5]:')); // TODO Add validation

    const isSlotBooked = jobInterviews.find((i) => i.slot === slot)
        ? true
        : false;

    if (isSlotBooked) {
        alert(
            'You already has booked an interview with another candidate for this slot! Please finished it first!'
        );
        return;
    }
    const interview = await interviewService.create({
        jobId,
        candidateId,
        slot,
    });

    context.page.redirect(`/details/${jobId}`);
}

async function joinToPotentialCandidatesHandler(context, e) {
    e.preventDefault();
    const jobId = context.params.id;
    const option = Array.from(e.target.children).find(
        (x) => x.value === e.target.value
    );
    const candidateId = option.dataset.candidateid;
    const result = await jobService.addPotentialCandidate(jobId, {
        candidateId,
    });
    console.log(result);
    context.page.redirect(`/details/${jobId}`);
}

async function rejectCandidateHandler(context, e) {
    e.preventDefault();
    const jobId = context.params.id;
    const candidateId = e.target.dataset.candidateid;
    const candidateInterviews = await candidateService.getInterviews(
        candidateId
    );

    const currentInterView = candidateInterviews.find(
        (x) => x.candidateId === candidateId
    );

    const removeInterviewResponse = await interviewService.remove(
        currentInterView._id
    );

    const removeCandidateFromJobListResponse = await jobService.removeCandidate(
        jobId,
        candidateId
    );

    context.page.redirect(`/details/${jobId}`);
}

async function approveCandidateHandler(context, e) {
    e.preventDefault();
    const jobId = context.params.id;
    const candidateId = e.target.dataset.candidateid;

    const jobInterviews = await jobService.getInterviews(jobId);
    console.log(jobInterviews);
    for (const interview of jobInterviews) {
        await interviewService.remove(interview._id);
    }

    const removeCandidateFromJobListResponse = await jobService.removeCandidate(
        jobId,
        candidateId
    );
    const removeCandidateResponse = await candidateService.del(candidateId);
    const removeJobResposne = await jobService.del(jobId);

    context.page.redirect('/jobs');
}

async function deleteHandler(context, e) {
    e.preventDefault();

    if (confirm('Are you sure you want to delete this car ad')) {
        try {
            await jobService.del(context.params.id);
            context.page.redirect('/jobs');
        } catch (err) {
            alert(err);
            console.log(err);
        }
    }
}
//--------------------------------------------------------------------
// above getDetailsPage function are all handlers and templates

export async function getDetailsPage(context) {
    const job = await jobService.getById(context.params.id);

    let jobInterviews = await jobService.getInterviews(context.params.id); // These are all intewrviews for this job
    const candidatesInInterviewList = await populateJobInterviews(
        jobInterviews
    ); // These are all users how are going to interview

    const allCandidates = await candidateService.getAll(); // These are all candidates in the database
    let allCandidatesForThisJob = await jobService.getCandidates(
        context.params.id
    );

    let candidatesWhoCanApplyForThisJob =
        await getCandidatesWhoCanApplyForThisJob(
            allCandidates,
            allCandidatesForThisJob
        );

    allCandidatesForThisJob = await RemoveThoseWhoAreOnInterViewForThisJob(
        allCandidatesForThisJob
    );

    // candidatesWhoCanApplyForThisJob are those who are not in the list of potential candidate for this job and havent' booked any interviews
    // allCandidatesForThisJob are those who are chosen for potential candidates the next step for them is to be allowe for interview

    const info = {
        job,
        candidatesInInterviewList,
        candidatesWhoCanApplyForThisJob,
        allCandidatesForThisJob,
        deleteHandler: deleteHandler.bind(null, context),
        joinToPotentialCandidatesHandler: joinToPotentialCandidatesHandler.bind(
            null,
            context
        ),
        addToInterviewHandler: addToInterviewHandler.bind(null, context),
        rejectCandidateHandler: rejectCandidateHandler.bind(null, context),
        approveCandidateHandler: approveCandidateHandler.bind(null, context),
    };
    const templateResult = detailsTemplate(info);
    context.renderView(templateResult);
}

// bello the getThisPage function are all function that eliminate candidates in some way
//--------------------------------------------------------------------

async function populateJobInterviews(jobInterviews) {
    return await Promise.all(
        jobInterviews.map(async (x) => {
            const candidate = await candidateService.getById(x.candidateId);
            return candidate;
        })
    );
}

async function getCandidatesWhoCanApplyForThisJob(
    allCandidates,
    allCandidatesForThisJob
) {
    let candidatesWhoCanApplyForThisJob = allCandidates.map(async (c) => {
        if (allCandidatesForThisJob.find((x) => x._id == c._id)) {
            return undefined;
        }

        const candidateInterviews = await candidateService.getInterviews(c._id);

        if (candidateInterviews.length > 0) {
            return undefined;
        }

        return c;
    });

    candidatesWhoCanApplyForThisJob = await Promise.all(
        candidatesWhoCanApplyForThisJob
    );
    candidatesWhoCanApplyForThisJob = candidatesWhoCanApplyForThisJob.filter(
        (c) => c !== undefined
    );
    return candidatesWhoCanApplyForThisJob;
}

async function RemoveThoseWhoAreOnInterViewForThisJob(allCandidatesForThisJob) {
    allCandidatesForThisJob = await Promise.all(
        allCandidatesForThisJob.map(async (c) => {
            const interviews = await candidateService.getInterviews(c._id);
            if (interviews.length > 0) {
                return undefined;
            }
            return c;
        })
    );

    return allCandidatesForThisJob.filter((c) => c !== undefined);
}
