
const React = require('react');


export default class Table extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        let employees = this.props.employees;

        return <div className="my-2 mx-auto p-3 block-content overflow-scroll">
            < table className="table" >
                <thead>
                    <tr>
                        <th scope="col">Отдел</th>
                        <th scope="col">Ф.И.О</th>
                        <th scope="col">Дата рождения</th>
                        <th scope="col">Должность</th>
                        <th scope="col">Дата устройства на работу</th>
                        <th scope="col">Заработная плата</th>
                        <th scope="col">Действия</th>
                    </tr>
                </thead>
                <tbody>
                    {employees.map((prop, i) => {

                        return <StringTable getEmpoyeeId={this.props.getEmpoyeeId} items={prop} key={i} />
                    })}
                </tbody>
            </table >
        </div>
    }
}

class StringTable extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        let items = this.props.items;

        return <tr>
            <td >{items.department}</td>
            <td>{items.surname + " " + items.firstname + " " + (items.patronymic != null ? items.patronymic : "")}</td>
            <td>{items.dateOfBirth}</td>
            <td>{items.jobPost}</td>
            <td>{items.dateOfEmployment}</td>
            <td>{items.salary}</td>
            <td >
                <div className="d-flex">
                    <button id={items.id} onClick={this.props.getEmpoyeeId} data-bs-toggle="modal" data-bs-target="#delete-employee-modal" className="btn bi bi-trash"></button>
                    <button id={items.id} onClick={this.props.getEmpoyeeId} data-bs-toggle="modal" data-bs-target="#form-edit-employee" className="btn bi bi-pen"></button>
                </div>
            </td>
        </tr>
    }
}
