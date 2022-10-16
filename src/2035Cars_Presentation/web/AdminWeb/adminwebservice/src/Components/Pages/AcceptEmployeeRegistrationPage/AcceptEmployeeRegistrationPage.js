import React from 'react'
import styles from './AcceptEmployeeRegistrationPage.module.css'
import { Table } from 'reactstrap'

function AcceptEmployeeRegistrationPage() {
  return (
    <div className={styles.wrapper}>
        <h1>Akceptacja nowych pracowników</h1>
        <div className={styles.tableContent}>
        <Table hover>
            <thead>
                <tr>
                <th>
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
                    Mark
                </td>
                <td>
                    Otto
                </td>
                <td style={{ width: "20px" }}>
                    <a className={`btn btn-primary ${styles.buttonLink} ${styles.backButton}`}>
                        Akceptuj
                    </a>
                </td>
                </tr>
                <tr>
                <th scope="row">
                    2
                </th>
                <td>
                    Jacob
                </td>
                <td>
                    Thornton
                </td>
                <td style={{ width: "20px" }}>
                    <a className={`btn btn-primary ${styles.buttonLink} ${styles.backButton}`}>
                        Akceptuj
                    </a>
                </td>
                </tr>
                <tr>
                <th scope="row">
                    3
                </th>
                <td>
                    Larry
                </td>
                <td>
                    the Bird
                </td>
                <td style={{ width: "20px" }}>
                    <a className={`btn btn-primary ${styles.buttonLink} ${styles.backButton}`}>
                        Akceptuj
                    </a>
                </td>
                </tr>
            </tbody>
            </Table>
        </div>
    </div>
  )
}

export default AcceptEmployeeRegistrationPage