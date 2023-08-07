import React, { Component } from 'react';
import { useParams, Link } from 'react-router-dom';
import style from '../styles/Style.css';

export class ListUsers extends Component {
    static displayName = ListUsers.name;

    constructor(props) {
        super(props);
        this.state = { users: [], loading: true };
    }

    componentDidMount() {
        this.populateUsers();
    }

    static renderUsersTable(users) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>           
                        <th>Name</th>
                        <th>Surname</th>
                        <th>Telephone </th>
                        <th>Email</th>
                        <th>Suscription</th>
                    </tr>
                </thead>
                <tbody>
                    {users.map(user =>
                        <tr key={user.usrId}>
                            <td>{user.usrName}</td>
                            <td>{user.usrSurname}</td>
                            <td>{user.usrTelephone}</td>
                            <td>{user.usrEmail}</td>
                            <td>{user.usrSuscription === "True" ? "Yes" : "No"}</td>
                            <td className='button'>
                                <Link to={'/show_menus_users?id='+user.usrId} style={{ textDecoration: 'none', color: 'white' }}>
                                    Select
                                </Link>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : ListUsers.renderUsersTable(this.state.users);

        return (
            <div>
                <h1 id="tabelLabel" >User List</h1>
                <p>An entire list of users.</p>
                <div >
                    {contents}
                </div>
            </div>
        );
    }

    async populateUsers() {

        const response = await fetch('https://localhost:7092/api/User', {
            headers:
            {
                'Access-Control-Allow-Origin': '*',
                'Content-Type': 'application/json',
                'mode': "no-cors"
            }
        });
        var a = response.body;
        const data = await response.json();
        this.setState({ users: data, loading: false });

    }
}