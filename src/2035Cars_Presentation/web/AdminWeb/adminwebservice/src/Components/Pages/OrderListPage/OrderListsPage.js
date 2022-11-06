import React, { useEffect, useState } from 'react'
import styles from './OrderListsPage.module.css'
import { Table } from 'reactstrap'
import axios from '../../../axios/axiosAuthorize'

function OrderListsPage() {

    const [listOfOrders, setListOfOrders] = useState([])
    const [areOrdersLoaded, setAreOrdersLoaded] = useState(false)

    const downloadOrders = () => {
        const rentalId = localStorage.getItem('rentalId')
        axios.get(`/order/getorders/${rentalId}`)
                .then( response => {
                    setListOfOrders(response.data)
                    setAreOrdersLoaded(true)
                })
                .catch( error => {
                    console.log(error)
                })
    }

    const finishOrderHandler = (orderId) => {

        if(window.confirm("Czy napewno chcesz zamknąć zamówienie ?") == true) {
            axios.get(`/order/finishorder/${orderId}`)
                .then(() => {
                    window.location.reload(true)
                })
                .catch((error) => {
                    console.log(error)
                })
        }
    }

    useEffect(() => {
        document.title = 'Zakończ zamówienie'
        downloadOrders()
    }, [])

  return (
    <div className={styles.wrapper}>
        <h1>Zakończ zamówienie</h1>
        <div className={styles.tableContent}>
        {
            areOrdersLoaded ?
                listOfOrders.length > 0 ?
                <>
                    <Table hover>
                        <thead>
                            <tr>
                            <th>
                            </th>
                            <th>
                                Cena
                            </th>
                            <th>
                                Imię
                            </th>
                            <th>
                                Nazwisko
                            </th>
                            <th>
                                Akceptacja
                            </th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                [...listOfOrders].map((item, index) => {
                                    return (
                                        <tr key={index}>
                                            <th scope='row'>
                                                {index + 1}
                                            </th>
                                            <td>
                                                {item.price}
                                            </td>
                                            <td>
                                                {item.customerFirstName}
                                            </td>
                                            <td>
                                                {item.customerLastName}
                                            </td>
                                            <td style={{ width: "20px" }}>
                                                <a className={`btn btn-success`} onClick={() => { finishOrderHandler(item.id)}}>
                                                    Zakończ
                                                </a>
                                            </td>
                                        </tr>
                                    )
                                })
                            }
                        </tbody>
                    </Table>
                </>
                :
                <h1 style={{textAlign: 'center', fontSize: '60px', color: 'blue', marginTop: '20vh'}}>
                    Brak zamówień...
                </h1>
            :
            <>
            </>
        }
        </div>
    </div>
  )
}

export default OrderListsPage