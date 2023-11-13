import Table from "./table/table.jsx";
import FormEmployee from "./form/form.jsx";
import FormEditEmployee from "./form/formEdit.jsx";
import axios from 'axios';
const React = require('react');

const form = document.getElementById('form-employee');

export default class IndexEmployee extends React.Component {
    constructor(props) {
        super(props);
        this.apiUrl = props.configData.API_URL;
        this.state = {
            employees: [],
            jobPosts: [],
            filter: {
                countLoaded: 0,
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
            }
        };

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

            .catch(function (error) {
                console.log(error);
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
        }
        else if (e.target.classList.contains("ascending")) {
            let newFilter = this.state.filter;
            newFilter.sortDescending = false;
            this.setState({ filter: newFilter });
        }
    }

    loadingFilterEmployees = () => {
        let newFilter = this.state.filter;
        newFilter.countLoaded = 0;
        this.setState({ filter: newFilter });
        this.getFilteredEmployees(newFilter);

    }

    getFilteredEmployees(newFilter) {
        axios.post(`${this.apiUrl}/api/v1/Employee/filter`, newFilter)
            .then((response) => {
                this.setState({ employees: response.data });
            })

            .catch(function (error) {
                console.log(error);
            });
    }

    selectedFilterJobPost = (e) => {
        let newFilter = this.state.filter;
        newFilter.jobPostId = e.target.value;
        this.setState({ filter: newFilter });
    }

    createEmployeeClick = (event) => {
        event.preventDefault();
        const data = new FormData(event.target);
        var object = {};
        data.forEach(function (value, key) {
            object[key] = value;
        });
        var json = JSON.stringify(object);
        console.log(json);
        event.target.reset();
        axios.post(`${this.apiUrl}/api/v1/Employee/create`, json, {
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then((response) => {
                console.log(response);
                document.querySelector(".modal-close").click();
                this.getFilteredEmployees(this.state.filter);
            })
            .catch(function (error) {
                console.log(error.response.data);
                alert(error.response.data.message);
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

                editEmployee.dateOfBirth = new Date(editEmployee.dateOfBirth).toISOString().split('T')[0];
                editEmployee.dateOfEmployment = new Date(editEmployee.dateOfEmployment).toISOString().split('T')[0];
                editEmployee.tariff = response.data.tariff;
            })

            .catch(function (error) {
                console.log(error);
            });
        this.setState({ employee: editEmployee });
        console.log(this.state.employee);

    }

    updateItemInTable(object)
    {
        let employeeEdit = this.state.employees.find((element) => element.id == object.id);
        axios.post(`${this.apiUrl}/api/v1/Employee/get`,
            {
                id: object.id
            })
            .then((response) => {
                let editEmployee = response.data;

                editEmployee.dateOfBirth = new Date(editEmployee.dateOfBirth).toISOString().split('T')[0];
                editEmployee.dateOfEmployment = new Date(editEmployee.dateOfEmployment).toISOString().split('T')[0];

                let data = this.state.employees;

                data.forEach(function (value, key) {
                    if (value.id == object.id)
                    {
                        data[key] = response.data;
                    }
                     
                });

                this.setState({ employees: data });

            })

            .catch(function (error) {
                console.log(error);
            });
    }

    editEmployeeClick = (event) => {
        event.preventDefault();
        const data = new FormData(event.target);
        var object = {};
        data.forEach(function (value, key) {
            object[key] = value;
        });
        var json = JSON.stringify(object);
        console.log(json);
        //event.target.reset();
        axios.post(`${this.apiUrl}/api/v1/Employee/edit`, json, {
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then((response) => {
                console.log(response);
                document.querySelector(".modal-close-edit").click();
                //this.getFilteredEmployees(this.state.filter);
                this.updateItemInTable(object);
            })
            .catch(function (error) {
                console.log(error.response.data);
                alert(error.response.data.message);
            });

    }

    render() {
        return <div className="my-2 mx-auto p-3 block-content">
            <div className="d-flex">
                <h1>Сотрудники</h1>
                <button data-bs-toggle="modal" data-bs-target="#form-employee" className="btn text-allign-right sort-btns">Добавить</button>
            </div>
            <div>
                <div className="d-flex">
                    <div className="sort-buttons d-flex">
                        <p className="align-text-bottom">Сортировать по:</p>
                        <button onClick={this.sortClick} className="btn btn-outline-dark sort-id m-1 ascending active w-auto sort-btns">по возрастанию</button>
                        <button onClick={this.sortClick} className="btn btn-outline-dark sort-id m-1 descending w-auto sort-btns">по убыванию</button>
                    </div>
                    <select className="form-select" onClick={this.selectedFilterJobPost} defaultValue="0" aria-label="Default select example">
                        <option value="0">Все должности</option>
                        {this.state.jobPosts.map((prop, i) => {

                            return <option key={i} value={prop.id}>{prop.name}</option>
                        })}
                    </select>
                    <button onClick={this.loadingFilterEmployees} className="btn btn-outline-dark sort-id m-1 active w-auto sort-btns">Загрузить</button>
                </div>
                <Table getEmpoyeeId={this.getEmpoyeeId.bind(this)} employees={this.state.employees} apiUrl={this.apiUrl} ></Table>

                <PageNavigation />
            </div>
            <ModealDeleteEmployee EmployeeClick={this.createEmployeeClick} employee={this.state.employee} apiUrl={this.apiUrl} />
            <ModealFormEmployee EmployeeClick={this.createEmployeeClick} apiUrl={this.apiUrl} />
            <ModealEditFormEmployee EmployeeClick={this.editEmployeeClick} employee={this.state.employee} apiUrl={this.apiUrl} />
        </div>
    }

}

class PageNavigation extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return <nav aria-label="Page navigation example">
            <ul className="pagination">
                <li className="page-item">
                    <a className="page-link" href="#" aria-label="Previous">
                        <span aria-hidden="true">&laquo;</span>
                    </a>
                </li>
                <li className="page-item"><a className="page-link" href="#">1</a></li>
                <li className="page-item"><a className="page-link" href="#">2</a></li>
                <li className="page-item"><a className="page-link" href="#">3</a></li>
                <li className="page-item">
                    <a className="page-link" href="#" aria-label="Next">
                        <span aria-hidden="true">&raquo;</span>
                    </a>
                </li>
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
                        <FormEmployee saveClick={this.props.EmployeeClick} apiUrl={this.props.apiUrl} />
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
                        <FormEditEmployee saveClick={this.props.EmployeeClick} employee={this.props.employee} apiUrl={this.props.apiUrl} />
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
        return <div class="modal fade" id="delete-employee-modal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5" id="exampleModalLabel">Удаление сотрудника</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        Вы действительно хотите удалить сотрудника?

                        <p className="fw-bold">ФИО: {this.props.employee.surname} {this.props.employee.firstname} { this.props.employee.patronymic}</p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Назад</button>
                        <button type="button" class="btn btn-primary">Подтвердить</button>
                    </div>
                </div>
            </div>
        </div>
    }
}

