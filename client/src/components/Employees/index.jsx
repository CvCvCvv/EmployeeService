import Table from "./table/table.jsx";
import FormEmployee from "./form/form.jsx";
import FormEditEmployee from "./form/formEdit.jsx";
import axios from 'axios';
const React = require('react');


export default class IndexEmployee extends React.Component {
    constructor(props) {
        super(props);
        this.apiUrl = props.configData.API_URL;
        this.state = {
            employees: [],
            jobPosts: [],
            countPages: 0,
            filter: {
                page: 0,
                countLoading: 5,
                jobPostId: 0,
                sortBy: "fio",
                sortDescending: false
            },
            employee: {
                id: "",
                firstname: "",
                surname: "",
                patronymic: "",
                dateOfBirth: "",
                dateOfEmployment: "",
                tariff: "",
                tariffEdit: 1,
                departmentId: 0,
                jobPostId: 0
            },
            warningError: ""
        };

        this.childWarning = React.createRef();
        

    }

    showError = (error) => {
        this.childWarning.current.showMessage(error);
    }

    componentDidMount() {
        this.getFilteredEmployees(this.state.filter);
        this.getAllJobPost();
    }

    getAllJobPost() {
        axios.get(`${this.apiUrl}/api/v1/JobPost/getall`)
            .then((response) => {
                this.setState({ jobPosts: response.data });
            })

            .catch((error) => {
                console.log("!!!!!!!!!!!+++");
                this.showError("err");
            });
    }

    sortClick = (e) => {
        e.target.parentElement.childNodes.forEach(elem => {
            elem.classList.remove("active");
        })
        e.target.classList.add("active");
        if (e.target.classList.contains("descending")) {
            let newFilter = this.state.filter;
            newFilter.sortDescending = true;
            this.setState({ filter: newFilter });
            this.loadingFilterEmployees();
        }
        else if (e.target.classList.contains("ascending")) {
            let newFilter = this.state.filter;
            newFilter.sortDescending = false;
            this.setState({ filter: newFilter });
            this.loadingFilterEmployees();
        }
    }

    loadingFilterEmployees = () => {
        let newFilter = this.state.filter;
        newFilter.page = 0;
        this.setState({ filter: newFilter });
        this.getFilteredEmployees(newFilter);

    }

    getFilteredEmployees(newFilter) {
        axios.post(`${this.apiUrl}/api/v1/Employee/filter`, newFilter)
            .then((response) => {
                this.setState({ employees: response.data.employees });
                this.setState({ countPages: response.data.pages });
            })

            .catch((error) => {
                this.showError("err");
            });
    }

    closeWarningWindow = () => {
        this.setState({ warningError: false });
    }

    selectedFilterJobPost = (e) => {
        let newFilter = this.state.filter;
        newFilter.jobPostId = e.target.value;
        this.setState({ filter: newFilter });
        this.loadingFilterEmployees();
    }

    createEmployeeClick = (event) => {
        event.preventDefault();
        const data = new FormData(event.target);
        var object = {};
        data.forEach(function (value, key) {
            object[key] = value;
        });
        var json = JSON.stringify(object);
        event.target.reset();
        axios.post(`${this.apiUrl}/api/v1/Employee/create`, json, {
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then((response) => {
                document.querySelector(".modal-close").click();
                this.getFilteredEmployees(this.state.filter);
            })
            .catch((error) => {
                console.log(error);
                this.showError(error);
            });

    }

    async getEmpoyeeId(element) {
        let editEmployee = {};
        await axios.post(`${this.apiUrl}/api/v1/Employee/get`,
            {
                id: element.target.id
            })
            .then((response) => {
                editEmployee = response.data;

                editEmployee.dateOfBirth = editEmployee.dateOfBirth.split('T')[0];
                editEmployee.dateOfEmployment = editEmployee.dateOfEmployment.split('T')[0];
                editEmployee.tariff = response.data.tariff;
            })

            .catch((error) => {
                this.showError("err");
            });
        this.setState({ employee: editEmployee });
    }

    updateItemInTable(object) {
        //let employeeEdit = this.state.employees.find((element) => element.id == object.id);
        axios.post(`${this.apiUrl}/api/v1/Employee/get`,
            {
                id: object.id
            })
            .then((response) => {
                let editEmployee = response.data;

                editEmployee.dateOfBirth = editEmployee.dateOfBirth.split('T')[0];
                editEmployee.dateOfEmployment = editEmployee.dateOfEmployment.split('T')[0];

                let data = this.state.employees;

                data.forEach(function (value, key) {
                    if (value.id == object.id) {
                        data[key] = response.data;
                    }
                });
                this.setState({ employees: data });
            })

            .catch((error) => {
                this.showError("err");
            });
    }

    loadPage = (e) => {
        let newFilter = this.state.filter;
        newFilter.page = e.target.id;
        this.setState({ filter: newFilter });
        this.getFilteredEmployees(newFilter);
    }

    editEmployeeClick = (event) => {
        event.preventDefault();
        const data = new FormData(event.target);
        var object = {};
        data.forEach(function (value, key) {
            object[key] = value;
        });
        var json = JSON.stringify(object);
        axios.post(`${this.apiUrl}/api/v1/Employee/edit`, json, {
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then((response) => {
                document.querySelector(".modal-close-edit").click();
                this.updateItemInTable(object);
            })
            .catch((error) => {
                this.showError("err");
            });
    }


    deleteEmployeeClick = () => {
        let object = {};
        object.id = this.state.employee.id;
        axios.delete(`${this.apiUrl}/api/v1/Employee/delete`, {
            headers: {
                "accept": "*/*",
                'Content-Type': 'application/json'
            }, data: { id: object.id }
        })
            .then((response) => {
                document.querySelector(".btn-close-delete-message").click();
                this.getFilteredEmployees(this.state.filter);
            })
            .catch((error) => {
                this.showError("err");
            });
    }

    render() {
        return <div className="my-2 mx-auto container p-3 block-content">
            <div className="container">

                <WarningError ref={this.childWarning} />

                <div className="d-flex justify-content-between my-2">
                    <h1>Сотрудники</h1>
                    <button data-bs-toggle="modal" data-bs-target="#form-employee" className="m-1 btn btn-success">Добавить</button>
                </div>
            </div>
            <div className="">
                
                <div className="row">
                    <div className="sort-buttons col-12 col-md-4 p-2 text-center filter-background mx-1 my-1">
                        <button onClick={this.sortClick} className="btn btn-outline-dark sort-id mx-1 bi bi-sort-up ascending active w-auto sort-btns">ФИО</button>
                        <button onClick={this.sortClick} className="btn btn-outline-dark sort-id mx-1 bi bi-sort-down descending w-auto sort-btns">ФИО</button>
                    </div>
                    <div className="col-12 col-md filter-background p-2 mx-1 my-1">
                        <select className="form-select" onClick={this.selectedFilterJobPost} defaultValue="0" aria-label="Default select example">
                            <option value="0">Все должности</option>
                            {this.state.jobPosts.map((prop, i) => {

                                return <option key={i} value={prop.id}>{prop.name}</option>
                            })}
                        </select>
                    </div>
                    <div className="">
                        <button onClick={this.loadingFilterEmployees} className="btn btn-outline-dark sort-id d-none active w-auto sort-btns">Загрузить</button>
                    </div>
                </div>
                <Table getEmpoyeeId={this.getEmpoyeeId.bind(this)} employees={this.state.employees} apiUrl={this.apiUrl} ></Table>

                <PageNavigation pages={this.state.countPages} loadPage={this.loadPage} loadedPage={this.state.filter.page} />
            </div>
            <ModealDeleteEmployee EmployeeClick={this.deleteEmployeeClick} employee={this.state.employee} apiUrl={this.apiUrl} />
            <ModealFormEmployee showError={this.showError} EmployeeClick={this.createEmployeeClick} apiUrl={this.apiUrl} />
            <ModealEditFormEmployee showError={this.showError} EmployeeClick={this.editEmployeeClick} employee={this.state.employee} apiUrl={this.apiUrl} />
        </div>
    }

}

class PageNavigation extends React.Component {
    constructor(props) {
        super(props);
    }

    getPage = (count) => {
        let content = [];


        for (let key = 0; key < count; key++) {
            if (this.props.loadedPage == key) {
                content.push(<li className="page-item active" key={key}><button onClick={this.props.loadPage} key={key} className="page-link" id={key}>{key + 1}</button></li>);
            }
            else {
                content.push(<li className="page-item" key={key}><button onClick={this.props.loadPage} key={key} className="page-link" id={key}>{key + 1}</button></li>);
            }
        }
        return content;
    };

    render() {
        return <nav aria-label="Page navigation example">
            <ul className="pagination">
                {this.getPage(this.props.pages)}
            </ul>
        </nav>
    }
}

class ModealFormEmployee extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return <div id="form-employee" className="modal fade" tabIndex="-1">
            <div className="modal-dialog modal-dialog-centered modal-dialog-scrollable">
                <div className="modal-content">
                    <div className="modal-header">
                        <h5 className="modal-title">Добавление нового сотрудника</h5>
                        <button type="button" className="btn-close modal-close" data-bs-dismiss="modal" aria-label="Закрыть"></button>
                    </div>
                    <div className="modal-body">
                        <FormEmployee showError={this.props.showError} saveClick={this.props.EmployeeClick} apiUrl={this.props.apiUrl} />
                    </div>
                </div>
            </div>
        </div>
    }
}

class ModealEditFormEmployee extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return <div id="form-edit-employee" className="modal fade" tabIndex="-1">
            <div className="modal-dialog modal-dialog-centered modal-dialog-scrollable">
                <div className="modal-content">
                    <div className="modal-header">
                        <h5 className="modal-title">Редактирование сотрудника</h5>
                        <button type="button" className="btn-close modal-close-edit" data-bs-dismiss="modal" aria-label="Закрыть"></button>
                    </div>
                    <div className="modal-body">
                        <FormEditEmployee showError={this.props.showError} idEmployee={this.props.employee.id} saveClick={this.props.EmployeeClick} employee={this.props.employee} apiUrl={this.props.apiUrl} />
                    </div>
                </div>
            </div>
        </div>
    }
}

class ModealDeleteEmployee extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return <div className="modal fade" id="delete-employee-modal" tabIndex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div className="modal-dialog">
                <div className="modal-content">
                    <div className="modal-header">
                        <h1 className="modal-title fs-5" id="exampleModalLabel">Удаление сотрудника</h1>
                        <button type="button" className="btn-close btn-close-delete-message" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div className="modal-body">
                        Вы действительно хотите удалить сотрудника?

                        <p className="fw-bold">ФИО: {this.props.employee.surname} {this.props.employee.firstname} {this.props.employee.patronymic}</p>
                    </div>
                    <div className="modal-footer">
                        <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Назад</button>
                        <button type="button" onClick={this.props.EmployeeClick} className="btn btn-primary">Подтвердить</button>
                    </div>
                </div>
            </div>
        </div>
    }
}

class WarningError extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            message: ""
        }
    }

    showMessage = (code) => {
        console.log(code);
        switch (code.code) {
            case "":
                this.setState({ message: "" });
                break;
            case "ERR_NETWORK":
                this.setState({ message: "Не удаётся подключиться к серверу" });
                break;
            case "ERR_BAD_REQUEST":
                alert(JSON.stringify(code.response.data.errors));
                break;
            default:
                this.setState({ message: "Не удалось получить информацию" });
                break;
        }
    }

    render() {

        if (this.state.message == "") {
            return
        }

        if (this.state.message) {
            return <div className="alert alert-warning alert-dismissible fade show" role="alert">
                <strong>Ошибка загрузки!</strong> {this.state.message}
                <button type="button" className="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            </div>
        }

    }
}