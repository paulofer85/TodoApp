import React, { Component } from 'react';
import { Modal, Button, Row, Col, Form } from 'react-bootstrap';

export class EditTodoModal extends React.Component {
    constructor(props) {
        super(props);
    }

    handleSubmit(event) {
        var formData = new FormData();
        event.preventDefault();
        fetch('http://localhost:49791/api/todoes/' + event.target.TodoId.value, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                TodoId: event.target.TodoId.value,
                estatus: event.target.TodoEstado.value
            })
        }).then(response => response.json())
            .then(success => {
                alert("OK")
            })
            .catch(error => console.log(error));
    }

    render() {
        return (
            <Modal
                {...this.props}
                size="lg"
                aria-labelledby="contained-modal-title-vcenter"
                centered>
                <Modal.Header closeButton>
                    <Modal.Title id="contained-modal-title-vcenter">
                        Edit TODO
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                   <div className="container">
                        <Row>
                            <Col sm={6}>
                                <form onSubmit={this.handleSubmit} id="TodoId">
                                    <label for="TodoId">TodoId: </label><br />
                                    <input type="text" name="TodoId" required disabled  placeholder="TodoId" defaultValue={this.props.todoId} /><br /><br />
                                    <label for="TodoEstado">Estado: </label><br />
                                    <input type="text" name="TodoEstado" required placeholder="TodoEstado" defaultValue={this.props.todoEstado} /><br /><br />
                                    <Button variant="primary" type="submit">
                                        Edit TODO
                                    </Button>
                                </form>
                   
                            </Col>
                        </Row>
                   </div>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="danger"onClick={this.props.onHide}>Close</Button>
                </Modal.Footer>
            </Modal>
        );
    }
}