import logo from '../../png/logo.png';
const React = require('react');

export default class About extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return <div className="container">
            <h1 className="py-3 text-center">О компании</h1>
            <div className="row">
                <div className="col-12 col-md-4">
                    <img className="img-fluid" src={logo}></img>
                </div>
                <div className="col-12 col-md-8">
                    <p>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Sit amet risus nullam eget felis eget nunc. Mattltrices vitae auctor. Libero nunc consequat interdum varius.
                    </p>

                    <p>
                        Ullamcorper eget nulla facilisi etiam dignissim diam. Purus sit amet volutpat consequat mauris nunc congue nisi vitae. Irmentum uate enim nulla aliquet porttitor. Ac tortor dignissim convallis aenean et. Fames ac turpis egestas integer eget.</p>

                    <p>
                        Aliquam ut porttitor leosequat id. Adipiscing tristique risus nec feugiat. Ornare massa eget egestas purus viverra accumsan in. Pell nunc sed. Praesent tristique magna sit amet purus. Duis tristique sollicitudin nibh sit cum. Purus faucibus ornare suspendisse sed nisi lacus sed. Sapien nec sagittis aliquam malesuada bibendum arcu.
                    </p>
                </div>
            </div>
        </div>
    }

}
