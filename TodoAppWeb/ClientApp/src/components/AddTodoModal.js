import React, { Component } from 'react';
import { Modal, Button, Row, Col, Form } from 'react-bootstrap';

export class AddTodoModal extends React.Component {
    constructor(props) {
        super(props);
    }

    handleSubmit(event) {
        var formData = new FormData();

        formData.append('descripcion', event.target.TodoDescripcion.value);
        formData.append('estatus', event.target.TodoEstado.value);
        formData.append('documento', event.target.TodoDocumento.files[0]);

        event.preventDefault();
        fetch('http://localhost:49791/api/todoes', {
            method: 'POST',
            body: formData
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
                        Crear TODO
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                   <div className="container">
                        <Row>
                            <Col sm={6}>
                                <form onSubmit={this.handleSubmit}>
                                    <label for="TodoDescripcion">Descripción: </label><br />
                                    <input type="text" name="TodoDescripcion" required placeholder="TodoDescripcion" /><br /><br />
                                    <label for="TodoEstado">Estado: </label><br />
                                    <input type="text" name="TodoEstado" required placeholder="TodoEstado" /><br /><br />
                                    <label for="TodoDocumento">Documento: </label><br />
                                    <input type="file" name="TodoDocumento"  placeholder="TodoDocumento" /><br /><br />
                                    <Button variant="primary" type="submit">
                                        Crear TODO
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