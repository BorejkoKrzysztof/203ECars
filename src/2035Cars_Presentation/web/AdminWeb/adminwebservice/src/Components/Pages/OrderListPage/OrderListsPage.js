import React, { useEffect } from 'react'
import styles from './OrderListsPage.module.css'
import { Table } from 'reactstrap'

function OrderListsPage() {

    useEffect(() => {
        document.title = 'Zakończ zamówienie'
    }, [])

  return (
    <div className={styles.wrapper}>
        <h1>Zakończ zamówienie</h1>
        <div className={styles.tableContent}>
        <Table hover>
            <thead>
                <tr>
                <th>
                </th>
                <th>
                    ID
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
                <tr>
                <th scope="row">
                    1
                </th>
                <td>
                    KHDAK-DKSBA-SDBSDK
                </td>
                <td>
                    Mark
                </td>
                <td>
                    Otto
                </td>
                <td style={{ width: "20px" }}>
                    <a className={`btn btn-success`}>
                        Zakończ
                    </a>
                </td>
                </tr>
                <tr>
                <th scope="row">
                    2
                </th>
                <td>
                    KHDAK-DKSBA-SDBSDK
                </td>
                <td>
                    Jacob
                </td>
                <td>
                    Thornton
                </td>
                <td style={{ width: "20px" }}>
                    <a className={`btn btn-success`}>
                        Zakończ
                    </a>
                </td>
                </tr>
                <tr>
                <th scope="row">
                    3
                </th>
                <td>
                    KHDAK-DKSBA-SDBSDK
                </td>
                <td>
                    Larry
                </td>
                <td>
                    the Bird
                </td>
                <td style={{ width: "20px" }}>
                    <a className={`btn btn-success`}>
                        Zakończ
                    </a>
                </td>
                </tr>
            </tbody>
            </Table>
        </div>
    </div>
  )
}

export default OrderListsPage