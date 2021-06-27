const gameStart = document.querySelector('.game-start');
const gameArea = document.querySelector('.game-area');
const gameOver = document.querySelector('.game-over');
const gameScore = document.querySelector('.game-score');
const gamePoints = document.querySelector('.points');

gameStart.addEventListener('click', onGameStart);
gameOver.addEventListener('click', startGameFromBegining);

document.addEventListener('keydown', onKeyDown);
document.addEventListener('keyup', onKeyUp);

const keys = {};
const player = {
    x: 150,
    y: 100,
    width: 0,
    height: 0,
    lastTimeFiredFireball: 0,
};
const game = {
    speed: 2,
    movingMultiplier: 4,
    fireballMultiplier: 5,
    fireInterval: 1000,
    cloudSpawnInterval: 3000,
    bugSpawnInterval: 1000,
    bugKillBonus: 2000,
};

const scene = {
    score: 0,
    lastCloudSpawn: 0,
    lastBugSpawn: 0,
    isActiveGame: true,
};

function onGameStart() {
    gameStart.classList.add('hide');

    const wizard = document.createElement('div');
    wizard.classList.add('wizard');
    wizard.style.top = player.y + 'px';
    wizard.style.left = player.x + 'px';
    gameArea.appendChild(wizard);

    player.width = wizard.offsetWidth;
    player.height = wizard.offsetHeight;

    window.requestAnimationFrame(gameAction);
}

function onKeyDown(e) {
    e.preventDefault();
    keys[e.code] = true;
}

function onKeyUp(e) {
    e.preventDefault();
    keys[e.code] = false;
}

function gameAction(timestamp) {
    const wizard = document.querySelector('.wizard');

    const isInAir = player.y + player.height <= gameArea.offsetHeight;

    if (isInAir) {
        player.y += game.speed;
    }

    if (keys.ArrowUp && player.y > 0) {
        player.y -= game.speed * game.movingMultiplier;
    }
    if (keys.ArrowDown && isInAir) {
        player.y += game.speed * game.movingMultiplier;
    }
    if (keys.ArrowLeft && player.x > 0) {
        player.x -= game.speed * game.movingMultiplier;
    }
    if (keys.ArrowRight && player.x + player.width < gameArea.offsetWidth) {
        player.x += game.speed * game.movingMultiplier;
    }

    if (
        keys.Space &&
        timestamp - player.lastTimeFiredFireball > game.fireInterval
    ) {
        wizard.classList.add('wizard-fire');
        addFireball();
        player.lastTimeFiredFireball = timestamp;
    } else {
        wizard.classList.remove('wizard-fire');
    }
    const fireBalls = document.querySelectorAll('.fire-ball');
    FireAFireball(fireBalls);

    wizard.style.top = player.y + 'px';
    wizard.style.left = player.x + 'px';

    scene.score++;
    gamePoints.textContent = scene.score;

    // spawn clouds
    if (
        timestamp - scene.lastCloudSpawn >
        game.cloudSpawnInterval + 2000 * Math.random()
    ) {
        const cloud = document.createElement('div');
        cloud.classList.add('cloud');
        cloud.x = gameArea.offsetWidth - 200;
        cloud.style.left = cloud.x + 'px';
        cloud.style.top = (gameArea.offsetHeight - 200) * Math.random + 'px;';

        gameArea.appendChild(cloud);
        scene.lastCloudSpawn = timestamp;
    }
    const clouds = document.querySelectorAll('.cloud');
    clouds.forEach((cloud) => {
        cloud.x -= game.speed;
        cloud.style.left = cloud.x + 'px';

        if (cloud.x + cloud.offsetWidth <= 0) {
            cloud.parentElement.removeChild(cloud);
        }
    });

    // spawn bugs
    if (
        timestamp - scene.lastBugSpawn >
        game.bugSpawnInterval + 5000 * Math.random()
    ) {
        const bug = document.createElement('div');
        bug.classList.add('bug');
        bug.x = gameArea.offsetWidth - 60;
        bug.style.left = bug.x + 'px';
        bug.style.top = (gameArea.offsetHeight - 60) * Math.random() + 'px';
        gameArea.appendChild(bug);
        scene.lastBugSpawn = timestamp;
    }

    const bugs = document.querySelectorAll('.bug');
    bugs.forEach((bug) => {
        bug.x -= game.speed * 3;
        bug.style.left = bug.x + 'px';
        if (bug.x + bug.offsetWidth <= 0) {
            bug.parentElement.removeChild(bug);
        }
    });

    // check for collisions
    bugs.forEach((bug) => {
        if (isCollision(wizard, bug)) {
            gameOverAction();
        }

        fireBalls.forEach((fireBall) => {
            if (isCollision(fireBall, bug)) {
                scene.score += game.bugKillBonus;
                bug.parentElement.removeChild(bug);
                fireBall.parentElement.removeChild(fireBall);
            }
        });
    });

    if (scene.isActiveGame) {
        window.requestAnimationFrame(gameAction);
    }
}

function addFireball() {
    const fireBall = document.createElement('div');

    fireBall.classList.add('fire-ball');
    fireBall.style.top = player.y + player.height / 3 - 5 + 'px';
    fireBall.x = player.x + player.width;
    fireBall.style.left = fireBall.x + 'px';

    gameArea.appendChild(fireBall);
}

function FireAFireball(fireBalls) {
    fireBalls.forEach((fireBall) => {
        fireBall.x += game.speed * game.fireballMultiplier;
        fireBall.style.left = fireBall.x + 'px';

        if (fireBall.x + fireBall.offsetWidth > gameArea.offsetWidth) {
            fireBall.parentElement.removeChild(fireBall);
        }
    });
}

function isCollision(firstElment, secondElement) {
    const firstRect = firstElment.getBoundingClientRect();
    const secondRect = secondElement.getBoundingClientRect();

    return !(
        firstRect.top > secondRect.bottom ||
        firstRect.bottom < secondRect.top ||
        firstRect.right < secondRect.left ||
        firstRect.left > secondRect.right
    );
}

function gameOverAction() {
    scene.isActiveGame = false;
    gameOver.classList.remove('hide');
}

function startGameFromBegining() {
    scene.isActiveGame = true;
    scene.score = 0;
    scene.lastBugSpawn = 0;
    scene.lastCloudSpawn = 0;

    player.lastTimeFiredFireball = 0;
    player.x = 150;
    player.y = 100;
    player.width = 0;
    player.height = 0;

    document
        .querySelectorAll('.fire-ball')
        .forEach((fireball) => fireball.remove());
    document.querySelectorAll('.bug').forEach((bug) => bug.remove());
    document.querySelectorAll('.fire-ball').forEach((cloud) => cloud.remove());
    document.querySelector('.wizard').remove();

    gameOver.classList.add('hide');

    onGameStart();
}
