function printDeckOfCards(cards) {
    function createCard(face, suit) {
        let faces = [
            '2',
            '3',
            '4',
            '5',
            '6',
            '7',
            '8',
            '9',
            '10',
            'J',
            'Q',
            'K',
            'A',
        ];
        let suits = new Map();
        suits.set('S', '\u2660');
        suits.set('H', '\u2665');
        suits.set('D', '\u2666');
        suits.set('C', '\u2663');

        if (!faces.includes(face) || !suits.has(suit)) {
            console.log(`Invalid card: ${face + suit}`);
        }
        return {
            face,
            suit,
            toString: function () {
                return this.face + suits.get(this.suit);
            },
        };
    }

    const result = [];
    cards.forEach((currCard) => {
        const face = currCard.substring(0, currCard.length - 1);
        const suit = currCard.substring(currCard.length - 1);
        const card = createCard(face, suit);
        result.push(card);
    });

    console.log(result.join(', '));
}

printDeckOfCards(['AS', '10D', 'KH', '2C']);
