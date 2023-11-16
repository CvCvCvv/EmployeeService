import axios from 'axios';
const React = require('react');


export default class FormEeitEmployee extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            departments: [],
            jobPosts: [],
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
        this.getDirectory();
    }

    componentDidUpdate() {
        if (this.state.employee.id != this.props.idEmployee) {
            this.getEmpoyeeId();
        }
    }

    getEmpoyeeId() {
        let editEmployee = {};
        if (document.getElementById("form-edit-employee-reset") != null) {
            document.getElementById("form-edit-employee-reset").reset();
        }
        axios.post(`${this.props.apiUrl}/api/v1/Employee/get`,
            {
                id: this.props.idEmployee
            })
            .then((response) => {
                editEmployee = response.data;
                editEmployee.dateOfBirth = editEmployee.dateOfBirth.split('T')[0];
                editEmployee.dateOfEmployment = editEmployee.dateOfEmployment.split('T')[0];
                this.setState({ employee: editEmployee });
            })

            .catch(function (error) {
                console.log(error);
                //this.props.showError(error);
            });
    }

    getDirectory() {
        axios.get(`${this.props.apiUrl}/api/v1/Department/getall`)
            .then((response) => {
                this.setState({ departments: response.data });
            })

            .catch(function (error) {
                console.log(error);
                //this.props.showError(error);
            });

        axios.get(`${this.props.apiUrl}/api/v1/JobPost/getall`)
            .then((response) => {
                this.setState({ jobPosts: response.data });
            })

            .catch(function (error) {
                console.log(error);
                //this.props.showError(error);
            });
    }

    selectDepartment = (event) => {
        let employee = this.state.employee;
        employee.departmentId = event.target.value;
        this.setState({ employee: employee });
    }

    selectJobPost = (event) => {
        let employee = this.state.employee;
        employee.jobPostId = event.target.value;
        this.setState({ employee: employee });
    }


    render() {
        return <form id="form-edit-employee-reset" method="post" onSubmit={this.props.saveClick}>
            <input className="d-none" name="id" defaultValue={this.props.employee.id}></input>
            <div className="form-floating mb-3">
                <input type="text" className="form-control" maxLength="40" defaultValue={this.state.employee.firstname} name="firstname" id="floatingFirstname" placeholder="Имя" required />
                <label htmlFor="floatingFirstname">Имя</label>
            </div>

            <div className="form-floating mb-3">
                <input type="text" className="form-control" maxLength="40" defaultValue={this.state.employee.surname} name="surname" id="floatingsurname" placeholder="Фамилия" required />
                <label htmlFor="floatingsurname">Фамилия</label>
            </div>

            <div className="form-floating mb-3">
                <input type="text" className="form-control" maxLength="40" defaultValue={this.state.employee.patronymic} name="patronymic" id="flatingpatronymic" placeholder="Отчество" />
                <label htmlFor="flatingpatronymic">Отчество</label>
            </div>

            <label htmlFor="dateOfBirdth  mb-3">Дата рождения</label>
            <input id="dateOfBirdth" max={new Date().toISOString().split("T")[0]} name="dateOfBirth" defaultValue={this.state.employee.dateOfBirth} className="form-control" type="date" required />

            <label htmlFor="dateOfEmployment mb-3">Дата начала работы</label>
            <input id="dateOfEmployment" max={new Date().toISOString().split("T")[0]} name="dateOfEmployment" defaultValue={this.state.employee.dateOfEmployment} className="form-control" type="date" required />

            <div className="form-floating mb-3 my-3">
                <input type="number" min="1" max="999999999" className="form-control" defaultValue={this.state.employee.tariff} name="tariff" id="tariff" placeholder="Ставка" required />
                <label htmlFor="tariff">Ставка</label>
            </div>

            <div className="form-floating mb-3">
                <select className="form-select" onChange={this.selectDepartment} name="departmentId" value={this.state.employee.departmentId} id="department" aria-label="Выберите отдел" required>
                    {this.state.departments.map((prop, i) => {
                        return <option key={i} value={prop.id}>{prop.name}</option>
                    })}
                </select>
                <label htmlFor="department">Выберите отдел</label>
            </div>

            <div className="form-floating mb-3">
                <select className="form-select" name="jobPostId" onChange={this.selectJobPost} id="jobPost" value={this.state.employee.jobPostId} aria-label="Выберите должность" required>
                    {this.state.jobPosts.map((prop, i) => {

                        return <option key={i} value={prop.id}>{prop.name}</option>
                    })}
                </select>
                <label htmlFor="jobPost">Выберите должность</label>
            </div>
            <button type="submit" className="btn btn-primary">Сохранить изменения</button>

        </form>
    }

}