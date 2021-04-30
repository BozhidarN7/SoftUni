import style from './NavigationItem.module.css';

const NavigationItem = (props) => {
    return (
        <li className={style.listItem}>
            <a className={style.navListItem} href="#">
                {props.children}
            </a>
        </li>
    );
};

export default NavigationItem;
