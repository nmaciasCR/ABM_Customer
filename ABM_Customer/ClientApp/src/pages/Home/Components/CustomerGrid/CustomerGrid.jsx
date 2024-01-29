import React from "react";
import Styles from "./CustomerGrid.css";
import Table from 'react-bootstrap/Table';
import { format } from 'date-fns';
import DeleteIcon from "../DeleteIcon/DeleteIcon";


const CustomerGrid = ({ elements, afterCloseDeleteCustomer }) => {



    return (
        <Table striped bordered hover>
            <thead>
                <tr>
                    <th>#</th>
                    <th>Email</th>
                    <th>First</th>
                    <th>Last</th>
                    <th>Company</th>
                    <th>Created</th>
                    <th>Country</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {
                    elements.map(e => (
                        <tr>
                            <td>{e.id}</td>
                            <td>{e.email}</td>
                            <td>{e.first}</td>
                            <td>{e.last}</td>
                            <td>{e.company}</td>
                            <td>{format(new Date(e.created), 'dd/MM/yyyy HH:mm:ss')}</td>
                            <td>{e.country}</td>
                            <td>
                                <DeleteIcon customerId={e.id} afterCloseDeleteCustomer={afterCloseDeleteCustomer} />
                            </td>
                        </tr>
                    ))
                }
            </tbody>
        </Table>
    )
}


export default CustomerGrid;