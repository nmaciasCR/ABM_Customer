import React from "react";
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Styles from "./CreateCustomerModal.css";
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';






const CreateCustomerModal = ({ show, onButtonNoClick, onButtonYesClick, newCustomerData, handleEmail, handleFirst, handleLast, handleCompany, handleCountry }) => {


    return (
        <Modal show={show} onHide={onButtonNoClick}>
            <Modal.Header closeButton>Nuevo Customer</Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Group as={Row} className="mb-3" controlId="formEmail">
                        <Form.Label column sm={2}>
                            Email
                        </Form.Label>
                        <Col sm={10}>
                            <Form.Control
                                type="text"
                                value={newCustomerData.email}
                                onChange={handleEmail}
                            />
                        </Col>
                        <br /><br />
                        <Form.Label column sm={2}>
                            First
                        </Form.Label>
                        <Col sm={10}>
                            <Form.Control
                                type="text"
                                value={newCustomerData.first}
                                onChange={handleFirst}
                            />
                        </Col>
                        <br /><br />
                        <Form.Label column sm={2}>
                            Last
                        </Form.Label>
                        <Col sm={10}>
                            <Form.Control
                                type="text"
                                value={newCustomerData.last}
                                onChange={handleLast}
                            />
                        </Col>
                        <br /><br />
                        <Form.Label column sm={2}>
                            Company
                        </Form.Label>
                        <Col sm={10}>
                            <Form.Control
                                type="text"
                                value={newCustomerData.company}
                                onChange={handleCompany}
                            />
                        </Col>
                        <br /><br />
                        <Form.Label column sm={2}>
                            Country
                        </Form.Label>
                        <Col sm={10}>
                            <Form.Control
                                type="text"
                                value={newCustomerData.country}
                                onChange={handleCountry}
                            />
                        </Col>
                    </Form.Group>
                </Form>


            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={onButtonNoClick}>
                    Cancelar
                </Button>
                <Button variant="primary" onClick={onButtonYesClick}>
                    Crear
                </Button>
            </Modal.Footer>
        </Modal>
    )
}


export default CreateCustomerModal;