import React from "react";
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Styles from "./ConfirmModal.css";



const ConfirmModal = ({ show, question, onButtonNoClick, onButtonYesClick, buttonNoTitle, buttonYesTitle }) => {


    return (
        <Modal show={show} onHide={onButtonNoClick}>
            <Modal.Header closeButton></Modal.Header>
            <Modal.Body>
                {question}
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={onButtonNoClick}>
                    {buttonNoTitle}
                </Button>
                <Button variant="primary" onClick={onButtonYesClick}>
                    {buttonYesTitle}
                </Button>
            </Modal.Footer>
        </Modal>
    );
}


export default ConfirmModal;