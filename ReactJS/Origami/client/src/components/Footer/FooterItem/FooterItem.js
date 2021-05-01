import './FooterItem.css';

const FooterItem = (props) => {
    return (
        <li className="listItem">
            <a href="#">{props.children}</a>
        </li>
    );
};

export default FooterItem;
