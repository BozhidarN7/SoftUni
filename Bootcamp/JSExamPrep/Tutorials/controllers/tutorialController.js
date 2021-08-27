const express = require('express');

const tutorialService = require('../services/tutorialService');
const isAuthenticated = require('../middlewares/isAuthenticated.js');

const router = express.Router();

module.exports = router;

router.route('/').get(async (req, res) => {
    if (req.user) {
        res.redirect('/userHome');
    }
    try {
        const tutorials =
            await tutorialService.getTutorialsOrderByEnrolledUsers();
        res.render('home', { title: 'Tutorials', tutorials });
    } catch (err) {
        console.log(err);
        res.render('home', { title: 'Tutorials', err });
    }
});

router.route('/userHome').get(isAuthenticated, async (req, res) => {
    try {
        console.log(req.query);
        const userTutorials =
            await tutorialService.getTutorialsOrderByCreatedTime(req.query);
        res.render('userHome', { title: 'Tutorials', userTutorials });
    } catch (err) {
        console.log(err);
        res.render('userHome', { title: 'Tutorials', err });
    }
});

router
    .route('/create')
    .get(isAuthenticated, (req, res) => {
        res.render('create', { title: 'Add Tutorial' });
    })
    .post((req, res) => {
        tutorialService
            .create(req.body, req)
            .then((response) => res.redirect('/userHome'))
            .catch((err) => {
                console.log(err.message);
                res.render('create', { title: 'Add Tutorial', err });
            });
    });

router.route('/details/:tutorialId').get(isAuthenticated, async (req, res) => {
    try {
        const tutorial = await tutorialService.getById(req.params.tutorialId);
        if (req.user.username === tutorial.owner) {
            res.locals.canDeleteAndEdit = true;
        }
        if (tutorial.usersEntrolled.find((x) => x == req.user.id)) {
            res.locals.enrolled = true;
        }
        res.render('details', {
            title: `${tutorial.title} Info`,
            tutorial,
        });
    } catch (err) {
        console.log(err);
    }
});

router.route('/:tutorialId/delete').get((req, res) => {
    tutorialService
        .deleteById(req.params.tutorialId)
        .then((response) => res.redirect('/userHome'))
        .catch((err) => {
            console.log(err);
        });
});

router
    .route('/:tutorialId/edit')
    .get(async (req, res) => {
        try {
            const tutorial = await tutorialService.findById(
                req.params.tutorialId
            );
            res.render('edit', { title: 'Edit Tutorial', tutorial });
        } catch (err) {
            console.log(err);
        }
    })
    .post(async (req, res) => {
        console.log(req.body);
        let tutorial = undefined;
        try {
            tutorial = await tutorialService.update(
                req.params.tutorialId,
                req.body,
                req
            );
            if (req.user.username === tutorial.owner) {
                res.locals.canDeleteAndEdit = true;
            }
            if (tutorial.usersEntrolled.find((x) => x === req.user.id)) {
                res.locals.entrolled = true;
            }
            res.render('details', {
                title: `${tutorial.title} Info`,
                tutorial,
            });
        } catch (err) {
            console.log(err);
            res.render('details', {
                title: `${tutorial.title} Info`,
                tutorial,
                err,
            });
        }
    });

router.route('/:tutorialId/enroll').get(async (req, res) => {
    try {
        tutorialService.enroll(req.params.tutorialId, req.user);
        const tutorial = await tutorialService.findById(req.params.tutorialId);
        res.redirect(`/details/${tutorial._id}`);
    } catch (err) {
        console.log(err);
    }
});
