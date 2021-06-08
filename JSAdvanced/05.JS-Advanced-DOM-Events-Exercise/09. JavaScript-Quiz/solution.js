function solve() {
    const questionSections = Array.from(
        document.querySelectorAll('#quizzie section')
    );

    const rightAnswers = [
        'onclick',
        'JSON.stringify()',
        'A programming API for HTML and XML documents',
    ];
    const userAnswers = [];
    questionSections.forEach((section, i, arr) => {
        if (i === arr.length - 1) {
            section.children[0].children[1].addEventListener('click', () => {
                takeAnswer(arr, i, 1);
                showResults();
            });
            section.children[0].children[2].addEventListener('click', () => {
                takeAnswer(arr, i, 2);
                showResults();
            });
        } else {
            section.children[0].children[1].addEventListener('click', () => {
                showNextQuestion(arr, i, 1);
            });
            section.children[0].children[2].addEventListener('click', () => {
                showNextQuestion(arr, i, 2);
            });
        }
    });

    function showNextQuestion(arr, i, li) {
        arr[i].style.display = 'none';
        arr[i + 1].style.display = 'block';
        takeAnswer(arr, i, li);
    }
    function showResults() {
        questionSections[questionSections.length - 1].style.display = 'none';

        let rightAnswersCount = 0;
        userAnswers.forEach((ans) => {
            if (rightAnswers.includes(ans)) {
                rightAnswersCount++;
            }
        });

        const ul = document.querySelector('#results');
        const h1 = document.querySelector('#results h1');
        ul.style.display = 'block';
        if (rightAnswersCount === 3) {
            console.log('You are recognized as top JavaScript fan!');
            h1.textContent = 'You are recognized as top JavaScript fan!';
        } else {
            h1.textContent = `You have ${rightAnswersCount} right answers`;
        }
    }
    function takeAnswer(arr, i, li) {
        const answer =
            arr[i].children[0].children[li].querySelector('p').textContent;
        userAnswers.push(answer);
    }
}
