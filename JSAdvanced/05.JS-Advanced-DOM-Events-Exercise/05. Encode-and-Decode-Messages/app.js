function encodeAndDecodeMessages() {
    let textarea = document.getElementsByTagName('textarea');
    [...document.getElementsByTagName('button')].forEach((b) =>
        b.addEventListener('click', message)
    );

    function message(btn) {
        if (btn.target.textContent === 'Encode and send it') {
            let encoded = [...textarea[0].value]
                .map((e) => String.fromCharCode(e.charCodeAt(0) + 1))
                .join('');
            textarea[1].value = encoded;
            textarea[0].value = '';
        } else if (btn.target.textContent === 'Decode and read it') {
            let decoded = [...textarea[1].value]
                .map((e) => String.fromCharCode(e.charCodeAt(0) - 1))
                .join('');
            textarea[1].value = decoded;
        }
    }
}
