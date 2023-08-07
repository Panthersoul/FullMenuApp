import React, { Component } from 'react';


export class ListMenuUsers extends Component {
    static displayName = ListMenuUsers.name;

    constructor(props) {
        super(props);
        this.state = { menus: [], loading: true };
    }
    
    componentDidMount() {
        
        const queryParameters = new URLSearchParams(window.location.search)
        const id = queryParameters.get("id")
        console.log(id);
        this.populateMenus(id);
    }

    static RenderMenuTable(menus) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Active</th>
                    </tr>
                </thead>
                <tbody>
                    {menus.map(menu =>
                        <tr key={menu.menuId}>
                            <td>{menu.menuBarName}</td>
                            <td>{menu.menuActive === "True" ? "Yes" : "No"}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : ListMenuUsers.RenderMenuTable(this.state.menus);

        console.log(this.state.menus);

        return (
            <div>
                <h1 id="tabelLabel" >Menú List</h1>
                <p>An entire list of menu by user.</p>
                <div >
                    {contents}
                </div>
            </div>
        );
    }

    async populateMenus(id) {
        const response = await fetch('https://localhost:7092/api/Menu?userID='+id, {        
            headers:
            {
                'Access-Control-Allow-Origin': '*',
                'Content-Type': 'application/json',
                'mode': "no-cors"
            }
        });
       
        const data = await response.json();
        this.setState({ menus: data, loading: false });
    }
}