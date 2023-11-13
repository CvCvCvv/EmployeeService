import axios from 'axios';
const React = require('react');


export default class FormEeitEmployee extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            departments: [],
            jobPosts: []
        };
    }

    componentDidMount() {
        this.getDirectory();
    }

    getDirectory() {
        axios.get(`${this.props.apiUrl}/api/v1/Department/getall`)
            .then((response) => {
                this.setState({ departments: response.data });
            })

            .catch(function (error) {
                console.log(error);
            });

        axios.get(`${this.props.apiUrl}/api/v1/JobPost/getall`)
            .then((response) => {
                this.setState({ jobPosts: response.data });
            })

            .catch(function (error) {
                console.log(error);
            });
    }

    render() {
        return <form method="post" onSubmit={this.props.saveClick}>
            <input className="d-none" name="id" defaultValue={this.props.employee.id}></input>
            <div className="form-floating mb-3">
                <input type="text" className="form-control" defaultValue={this.props.employee.firstname} name="firstname" id="floatingFirstname" placeholder="Имя" required />
                <label htmlFor="floatingFirstname">Имя</label>
            </div>

            <div className="form-floating mb-3">
                <input type="text" className="form-control" defaultValue={this.props.employee.surname} name="surname" id="floatingsurname" placeholder="Фамилия" required />
                <label htmlFor="floatingsurname">Фамилия</label>
            </div>

            <div className="form-floating mb-3">
                <input type="text" className="form-control" defaultValue={this.props.employee.patronymic} name="patronymic" id="flatingpatronymic" placeholder="Отчество" />
                <label htmlFor="flatingpatronymic">Отчество</label>
            </div>

            <label htmlFor="dateOfBirdth  mb-3">Дата рождения</label>
            <input id="dateOfBirdth mb-3" name="dateOfBirth" defaultValue={this.props.employee.dateOfBirth} className="form-control" type="date" required />

            <label htmlFor="dateOfEmployment mb-3">Дата начала работы</label>
            <input id="dateOfEmployment  mb-3 px-3" name="dateOfEmployment" defaultValue={this.props.employee.dateOfEmployment} className="form-control" type="date" required />

            <div className="form-floating mb-3 my-3">
                <input type="number" min="1" className="form-control" defaultValue={this.props.employee.tariff} name="tariff" id="tariff" placeholder="Ставка" required />
                <label htmlFor="tariff">Ставка</label>
            </div>

            <div className="form-floating mb-3">
                <select className="form-select" name="departmentId" defaultValue={this.props.employee.departmentId} id="department" aria-label="Выберите отдел" required>
                    {this.state.departments.map((prop, i) => {
                        return <option key={i} selected={prop.id == this.props.employee.departmentId} value={prop.id}>{prop.name}</option>
                    })}
                </select>
                <label htmlFor="department">Выберите отдел</label>
            </div>

            <div className="form-floating mb-3">
                <select className="form-select" name="jobPostId" id="jobPost" defaultValue={this.props.employee.jobPostId} aria-label="Выберите должность" required>
                    {this.state.jobPosts.map((prop, i) => {

                        return <option key={i} selected={prop.id == this.props.employee.jobPostId} value={prop.id}>{prop.name}</option>
                    })}
                </select>
                <label htmlFor="jobPost">Выберите должность</label>
            </div>
            <button type="submit" className="btn btn-primary">Сохранить изменения</button>
           
        </form>
    }

}