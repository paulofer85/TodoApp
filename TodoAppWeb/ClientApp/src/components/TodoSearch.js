import React, { Component, TextInput, styles } from 'react';
import { Table } from 'react-bootstrap';
import { Button, ButtonToolbar } from 'react-bootstrap';
import { EditTodoModal } from './EditTodoModal';


export class TodoSearch extends Component {
    constructor(props) {
        super(props);
        this.state = { todos: [], addModalShow: false, editModalShow: false, todoDescripcion: "", todoEstatus:"" };
    }

    componentDidMount() {
        this.refreshList();
    }
    

    refreshList() {
        var filters = "";
        if ( this.state.todoDescripcion != null &&  this.state.todoDescripcion.length > 0)
            filters += "descripcion=" +  this.state.todoDescripcion + "&";

        if ( this.state.todoEstatus != null &&  this.state.todoEstatus.length > 0)
            filters += "estatus=" +  this.state.todoEstatus;

        fetch('http://localhost:49791/api/todoes/byFilter?' + filters)
            .then(response => response.json())
            .then(data => {
                this.setState({ todos: data });
            });
    }

    componentDidUpdate() {
        this.refreshList();
    }

    render() {
        const { todos, todoId, todoDescripcion, todoEstatus } = this.state;
        let addModalClose = () => this.setState({ addModalShow: false });
        let editModalClose = () => this.setState({ editModalShow: false });
        
        return (
            <div>
                <div>
                    <div className="container">
                        <form onSubmit={this.handleSubmit}>
                            <label for="TodoDescripcion">Descripción: </label><br />
                            <input type="text" id="TodoDescripcion" name="TodoDescripcion" placeholder="TodoDescripcion" 
                                ref={(input) => {this.TodoDescripcion = input }}/><br /><br />
                            <label for="TodoEstado">Estado: </label><br />
                            <input type="text" id="TodoEstado" name="TodoEstado" placeholder="TodoEstado" 
                                ref={(input) => {this.TodoEstado = input }}/><br /><br />
                             
                            <Button variant="primary"onClick={() => 
                                this.setState({ todoDescripcion: this.TodoDescripcion.value, todoEstatus: this.TodoEstado.value })}
                            >
                                Buscar TODO
                            </Button>
                        </form>
                    </div>
                    <Table className="mt-4" striped bordered hover size="sm">
                        <thead>
                            <th>Id</th>
                            <th>Descripcion</th>
                            <th>Estado</th>
                            <th>Documento</th>
                            <th>Acción</th>
                        </thead>
                        <tbody>
                            {todos.map(to => [
                                <tr key={to.todoId}>
                                    <td>{to.todoId}</td>
                                    <td>{to.descripcion}</td>
                                    <td>{to.estatus}</td>
                                    <td>{to.documento}</td>
                                    <td>
                                        <ButtonToolbar>
                                            <Button className="mr-2" variant="info"
                                                onClick={() => this.setState({ editModalShow: true, todoId: to.todoId, todoEstado: to.estatus })}
                                            >
                                                Edit
                                            </Button>
                                        </ButtonToolbar>
                                        <EditTodoModal show={this.state.editModalShow} 
                                            onHide={editModalClose}
                                            todoId = {todoId}
                                            todoEstado = {todoEstatus}
                                        />
                                    </td>
                                </tr>]
                            )}
                        </tbody>
                    </Table>
                </div>
            </div>
        );
    }
}
