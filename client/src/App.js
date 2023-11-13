import Header from "./components/header/header";
import { Outlet } from "react-router-dom";
import React from "react";

class App extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return <div>
            <Header />
            <div className="container-fluid">
                <Outlet />
            </div>
        </div>
    }
}

export default App;
