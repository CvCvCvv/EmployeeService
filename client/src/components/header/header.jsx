const React = require('react');


export default class Header extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <div className="container-fluid">
                <a className="navbar-brand" href="/">Корпорация</a>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse " id="navbarNavAltMarkup">
                    <div className="navbar-nav">
                        <a className="nav-link" href="/" aria-current="page" >О компании</a>
                        <a className="nav-link" href="/employees">Сотрудники</a>
                    </div>
                </div>
            </div>
        </nav>
    }

}

