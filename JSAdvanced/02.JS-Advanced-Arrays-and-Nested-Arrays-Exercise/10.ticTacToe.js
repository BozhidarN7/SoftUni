function solve(moves) {
    const board = [
        [false, false, false],
        [false, false, false],
        [false, false, false],
    ];

    let turn = 0;
    let hasWinner = true;
    for (let m = 0; m < moves.length; m++) {
        const move = moves[m];
        const pair = move.split(' ');
        const row = Number(pair[0]);
        const col = Number(pair[1]);

        if (board[row][col] !== false && m < 9) {
            console.log('This place is already taken. Please choose another!');
        } else if (turn === 0) {
            board[row][col] = 'X';
            turn ^= 1;
        } else if (turn === 1) {
            board[row][col] = 'O';
            turn ^= 1;
        }
        for (let i = 0; i < 3; i++) {
            hasWinner = true;
            let player = board[i][0];
            if (player === false) {
                hasWinner = false;
                continue;
            }
            for (let j = 1; j < 3; j++) {
                if (player !== false && board[i][j] !== player) {
                    hasWinner = false;
                    break;
                }
            }
            if (hasWinner) {
                break;
            }
        }
        if (hasWinner) {
            break;
        }
        hasWinner = true;
        for (let j = 0; j < 3; j++) {
            hasWinner = true;
            let player = board[j][0];
            if (player === false) {
                hasWinner = false;
                continue;
            }
            for (let i = 0; i < 3; i++) {
                if (player !== false && board[i][j] !== player) {
                    hasWinner = false;
                    break;
                }
            }
            if (hasWinner) {
                break;
            }
        }
        if (hasWinner) {
            break;
        }
        hasWinner = true;
        let player = board[0][0];
        for (let i = 1; i < 3; i++) {
            if (board[i][i] === false) {
                hasWinner = false;
                break;
            }
            if (player !== false && board[i][i] !== player) {
                hasWinner = false;
                break;
            }
        }
        if (hasWinner) {
            break;
        }
        hasWinner = true;
        player = board[0][2];
        for (let i = 1; i < 3; i++) {
            if (board[i][3 - i - 1] === false) {
                hasWinner = false;
                break;
            }
            if (player !== false && board[i][3 - i - 1] !== player) {
                hasWinner = false;
                break;
            }
        }
        if (hasWinner) {
            break;
        }
    }
    if (hasWinner) {
        if (turn === 0) {
            console.log('Player O wins!');
        } else {
            console.log('Player X wins!');
        }

        for (let i = 0; i < 3; i++) {
            console.log(board[i].join('\t'));
        }
    } else {
        console.log('The game ended! Nobody wins :(');
        for (let i = 0; i < 3; i++) {
            console.log(board[i].join('\t'));
        }
    }
}

// solve(['0 1', '0 0', '0 2', '2 0', '1 0', '1 1', '1 2', '2 2', '2 1', '0 0']);
// solve(['0 0', '0 0', '1 1', '0 1', '1 2', '0 2', '2 2', '1 2', '2 2', '2 1']);
solve(['0 1', '0 0', '0 2', '2 0', '1 0', '1 2', '1 1', '2 1', '2 2', '0 0']);
