function solve() {
    class Post {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            return `Post: ${this.title}\nContent: ${this.content}`;
        }
    }

    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content);
            this.likes = likes;
            this.dislikes = dislikes;
            this.comments = [];
        }
        addComment(commnet) {
            this.comments.push(commnet);
        }

        toString() {
            const baseToString = super.toString();
            const ratingString = `\nRating: ${this.likes - this.dislikes}`;
            if (this.comments.length) {
                let commentsString = '\nComments:\n';
                this.comments.forEach(
                    (comment) => (commentsString += ` * ${comment}\n`)
                );
                return (baseToString + ratingString + commentsString).trim();
            }

            return baseToString + ratingString;
        }
    }

    class BlogPost extends Post {
        constructor(title, content, views) {
            super(title, content);
            this.views = views;
        }
        view() {
            this.views++;
            return this;
        }
        toString() {
            const baseToString = super.toString();
            const viewsString = `\nViews: ${this.views}`;
            return baseToString + viewsString;
        }
    }

    return {
        Post,
        SocialMediaPost,
        BlogPost,
    };
}

const classes = solve();
let post = new classes.Post('Post', 'Content');

console.log(post.toString());

// Post: Post
// Content: Content

let scm = new classes.SocialMediaPost('TestTitle', 'TestContent', 25, 30);

scm.addComment('Good post');

console.log(scm.toString());

// Post: TestTitle
// Content: TestContent
// Rating: -5
// Comments:
//  * Good post
//  * Very good post
//  * Wow!

const bp = new classes.BlogPost('Programming', 'Programming is fun', 5);
console.log(bp.toString());

bp.view().view();

console.log(bp.toString());
