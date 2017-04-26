import * as React from 'react';
import { Link } from 'react-router';
import cx from 'classnames';
export default class Menu extends React.Component {
    constructor(props) {
        super(props);
    }
    render() {
        return (<div className="aside">
        <div className="aside-menu">
          <ul>
            <li className={cx({ 'current': this.props.location.pathname === '/profile/avatar' })}><Link to="/profile/avatar"><i className="ico ico-1"></i>我的头像</Link> </li>
            <li className={cx({ 'current': this.props.location.pathname === '/profile/basic' })}><Link to="/profile/basic"><i className="ico ico-2"></i>基本资料</Link> </li>
            <li className={cx({ 'current': this.props.location.pathname === '/profile/detail' })}><Link to="/profile/detail"><i className="ico ico-3"></i>详细资料</Link> </li>
            
          </ul>
        </div>
      </div>);
    }
}
//# sourceMappingURL=index.jsx.map