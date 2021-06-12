function solution(action) {
    if (action === 'upvote') {
        this.upvotes++;
    } else if (action === 'downvote') {
        this.downvotes++;
    } else {
        const result = [];
        const totalVotes = this.upvotes + this.downvotes;
        const balance = this.upvotes - this.downvotes;
        totalVotes > 50
            ? result.push(
                  Math.ceil(
                      0.25 * Math.max(this.upvotes, this.downvotes) +
                          this.upvotes
                  ),
                  Math.ceil(
                      0.25 * Math.max(this.upvotes, this.downvotes) +
                          this.downvotes
                  )
              )
            : result.push(this.upvotes, this.downvotes);

        result.push(balance);

        let rating = 'new';
        if (totalVotes < 10) {
            rating = 'new';
        } else if (this.upvotes / totalVotes > 0.66) {
            rating = 'hot';
        } else if (balance >= 0 && totalVotes > 100) {
            rating = 'controversial';
        } else if (balance < 0) {
            rating = 'unpopular';
        }
        result.push(rating);
        return result;
    }
}

var forumPost = {
    id: '1',
    author: 'pesho',
    content: 'hi guys',
    upvotes: 100,
    downvotes: 151,
};

solution.call(forumPost, 'upvote');
const answer = solution.call(forumPost, 'score');
console.log(answer);
