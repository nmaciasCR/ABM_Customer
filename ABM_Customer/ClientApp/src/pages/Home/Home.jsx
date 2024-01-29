import React, { useEffect, useState, useCallback } from "react";
import Styles from "./Home.css";
import CustomerGrid from "./Components/CustomerGrid/CustomerGrid";
import Button from 'react-bootstrap/Button';
import CreateCustomerModal from "../../components/CreateCustomerModal/CreateCustomerModal";


const Home = () => {

    const [customers, setCustomers] = useState([]);
    const [showCreateModal, setShowCreateModal] = useState(false);
    const [newCustomer, setNewCustomer] = useState({});


    function ResetCustomerGrid() {
        const requestOptions = {
            method: 'POST'
        };

        fetch("api/home/ResetCustomerData", requestOptions)
            .then(response => {
                loadTableCustomers();
            })
            .catch(error => {
                console.log(error);
            })
    }


    const loadTableCustomers = useCallback(() => {
        fetch("api/home/GetCustomers")
            .then(response => { return response.json() })
            .then(responseJson => {
                setCustomers(responseJson.sort((a, b) => a.id < b.id ? 1 : -1));
            })
            .catch(error => {
                console.log(error);
            })

    }, []);


    useEffect(() => {
        loadTableCustomers();
    }, [loadTableCustomers]);

    //Eventos para crear el newCustomer
    const handleEmailInput = (event) => {
        setNewCustomer({ ...newCustomer, email: event.target.value });
    }
    const handleFirstInput = (event) => {
        setNewCustomer({ ...newCustomer, first: event.target.value });
    }
    const handleLastInput = (event) => {
        setNewCustomer({ ...newCustomer, last: event.target.value });
    }
    const handleCompanyInput = (event) => {
        setNewCustomer({ ...newCustomer, company: event.target.value });
    }
    const handleCountryInput = (event) => {
        setNewCustomer({ ...newCustomer, country: event.target.value });
    }

    function CancelNewCustomerModal() {
        setShowCreateModal(false);
        setNewCustomer({});
    }
    //Crea un nuevo consumer
    function CreateNewCustomer() {

        const requestOptions = {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                'email': newCustomer.email,
                'first': newCustomer.first,
                'last': newCustomer.last,
                'company': newCustomer.company,
                'country': newCustomer.country
            })
        };

        fetch("api/home/CreateCustomer", requestOptions)
            .then(response => {
                switch (response.status) {
                    case 200: //OK
                        //Cerramos el modal
                        setShowCreateModal(false);
                        //Reset del modelo
                        setNewCustomer({});
                        loadTableCustomers();
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
        <div className="main-container">
            <div className="title">
                <h1>Customers</h1>
            </div>
            <div className="buttons">
                <Button variant="primary" onClick={() => setShowCreateModal(true)}>Nuevo Customer</Button>
                <Button variant="danger" onClick={ResetCustomerGrid}>Reset</Button>
            </div>
            <div>
                <CustomerGrid elements={customers} afterCloseDeleteCustomer={loadTableCustomers} />
            </div>

            <CreateCustomerModal
                show={showCreateModal}
                onButtonNoClick={CancelNewCustomerModal}
                onButtonYesClick={CreateNewCustomer}
                newCustomerData={newCustomer}
                handleEmail={handleEmailInput}
                handleFirst={handleFirstInput}
                handleLast={handleLastInput}
                handleCompany={handleCompanyInput}
                handleCountry={handleCountryInput}
            />

        </div>

    )
}

export default Home;