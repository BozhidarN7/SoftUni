import './Post.css';

const Post = ({ content, author }) => {
    return (
        <div className="post-container">
            <img src="/blue-origami-bird.png" alt="blue-bird"></img>
            <p className="post-description">{content}</p>
            <div>
                <span>
                    <smal>Author: {author}</smal>
                </span>
            </div>
        </div>
    );
};

export default Post;
