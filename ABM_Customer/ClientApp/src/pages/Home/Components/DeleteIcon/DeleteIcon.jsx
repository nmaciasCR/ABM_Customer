import React, { useState } from "react";
import Styles from "./DeleteIcon.css";
import cancelIcon from "../../../../images/cancel_Icon.png";
import ConfirmModal from "../../../../components/ConfirmModal/ConfirmModal";




const DeleteIcon = ({ customerId, afterCloseDeleteCustomer }) => {

    const [showConfirmModal, setShowConfirmModal] = useState(false);


    //Elimina un customer
    function DeleteCustomer(id) {

        const requestOptions = {
            method: 'DELETE',
        };

        fetch(`api/home/DeleteCustomer?id=${id}`, requestOptions)
            .then(response => {
                switch (response.status) {
                    case 200: //OK
                        //Cerramos el modal
                        setShowConfirmModal(false);
                        //refesh de la grilla
                        afterCloseDeleteCustomer();
                        break;
                    case 400: //BAD REQUEST
                        alert("ERROR");
                        break;
                    default:
                        alert("ERROR");
                        break;
                }
            })
            .catch(error => {
                //Modal de ERROR
                alert(error.toString());
            })

    }


    return (
        <>
            <img className="cancel-Icon" src={cancelIcon} alt="Eliminar" title="Eliminar" onClick={() => setShowConfirmModal(true)} />
            <ConfirmModal
                show={showConfirmModal}
                question="¿Desea elimminar el customer?"
                onButtonNoClick={() => setShowConfirmModal(false)}
                onButtonYesClick={() => DeleteCustomer(customerId)}
                buttonNoTitle="No"
                buttonYesTitle="Si"
            />
        </>
    )
}


export default DeleteIcon;