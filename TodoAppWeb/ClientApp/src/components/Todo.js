import React, { Component, TextInput, styles } from 'react';
import { Table } from 'react-bootstrap';
import { Button, ButtonToolbar } from 'react-bootstrap';
import { AddTodoModal } from './AddTodoModal';
import { EditTodoModal } from './EditTodoModal';


export class Todo extends Component {
    displayName = Todo.name

    constructor(props) {
        super(props);
        this.state = { todos: [], addModalShow: false, editModalShow: false };
    }

    componentDidMount() {
        this.refreshList();
    }
    

    refreshList() {
        debugger;
        fetch('http://localhost:49791/api/todoes')
            .then(response => response.json())
            .then(data => {
                this.setState({ todos: data });
            });
    }

    componentDidUpdate() {
        this.refreshList();
    }
      
    render() {
        const { todos, todoId, todoEstado } = this.state;
        let addModalClose = () => this.setState({ addModalShow: false });
        let editModalClose = () => this.setState({ editModalShow: false });

        return (
            <div>
                <div>
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
                                            onClick={()=>this.setState({editModalShow: true, todoId: to.todoId, todoEstado: to.estatus})}
                                            >
                                                Edit
                                            </Button>
                                        </ButtonToolbar>
                                        <EditTodoModal show={this.state.editModalShow} 
                                            onHide={editModalClose}
                                            todoId = {todoId}
                                            todoEstado = {todoEstado}
                                        />
                                    </td>
                                </tr>]
                            )}
                        </tbody>
                    </Table>
                </div>
                <div>
                    <ButtonToolbar>
                        <Button variant="primary"  onClick={() => this.setState({ addModalShow: true })}>
                            Crear TODO
                    </Button>
                        <AddTodoModal show={this.state.addModalShow} onHide={addModalClose}>
                        </AddTodoModal>
                    </ButtonToolbar>
                </div>
            </div>
        );
    }
}
