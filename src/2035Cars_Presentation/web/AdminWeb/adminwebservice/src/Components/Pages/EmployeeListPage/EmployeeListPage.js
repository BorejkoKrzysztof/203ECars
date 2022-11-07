import React, { useState } from 'react'
import styles from './EmployeeListPage.module.css'
import { Table,
        Pagination,
        PaginationItem,
        PaginationLink } from 'reactstrap'
import axios from '../../../axios/axiosAuthorize'

function EmployeeListPage() {

    const [employeesAreLoaded, setEmployeesAreLoaded] = useState(true)
    const [currentPage, setCurrentPage] = useState(1)
    const [amountOfPages, setAmountOfPages] = useState(0)
    const [employeesCollection, setEmployeesCollection] = useState([])

    const donwloadEmployeesCollection = () => {
        const rentalId = localStorage.getItem('rentalId')
        axios.get(`employee/getallrentalemployees/${rentalId}/${currentPage}`)
                .then( (response) => {

                    console.log(response)

                    setEmployeesCollection(response.data.employees)
                    setCurrentPage(response.data.currentPage)
                    setAmountOfPages(response.data.amountOfPages)
                    setEmployeesAreLoaded(true)
                })
                .catch( (error) => {
                    console.log(error)
                })
    }

    useState(() => {
        document.title = 'Lista Pracowników'
        donwloadEmployeesCollection()
    }, [])

  return (
    <div className={styles.wrapper}>
        <h1 className={styles.employeePageTitle}>Lista Pracowników:</h1>
        <div className={styles.employeeTableListArea}>
            {
                employeesAreLoaded ?
                <Table size="sm">
                <thead className={styles.centerRow}>
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
                        Telefon
                    </th>
                    <th>
                        Szczegóły
                    </th>
                    </tr>
                </thead>
                <tbody className={styles.centerRow}>
                    {
                        employeesCollection.map((item, index) => {
                            return (
                                <tr key={index}>
                                    <th scope="row">
                                        {index + 1}
                                    </th>
                                    <td>
                                        {item.firstName}
                                    </td>
                                    <td>
                                        {item.lastName}
                                    </td>
                                    <td>
                                        {item.phoneNumber}
                                    </td>
                                    <td>
                                        <button className={styles.buttonStyle}>
                                            Zobacz
                                        </button>
                                    </td>
                                </tr>
                            )
                        })
                    }
                </tbody>
            </Table>
            :
            <>
            </>
            }
        </div>
        <div className={styles.paginationArea}>
            <Pagination>
                <PaginationItem className={`${styles.buttonStylePagination}`}>
                    <PaginationLink 
                    first
                    href="#"
                    />
                </PaginationItem>
                <PaginationItem className={`${styles.buttonStylePagination}`}>
                    <PaginationLink
                    href="#"
                    previous
                    />
                </PaginationItem>
                <PaginationItem className={`${styles.buttonStylePagination}`}>
                    <PaginationLink href="#">
                    1
                    </PaginationLink>
                </PaginationItem>
                <PaginationItem className={`${styles.buttonStylePagination}`}>
                    <PaginationLink href="#">
                    2
                    </PaginationLink>
                </PaginationItem>
                <PaginationItem className={`${styles.buttonStylePagination}`}>
                    <PaginationLink href="#">
                    3
                    </PaginationLink>
                </PaginationItem>
                <PaginationItem className={`${styles.buttonStylePagination}`}>
                    <PaginationLink href="#">
                    4
                    </PaginationLink>
                </PaginationItem>
                <PaginationItem className={`${styles.buttonStylePagination}`}>
                    <PaginationLink href="#">
                    5
                    </PaginationLink>
                </PaginationItem>
                <PaginationItem className={`${styles.buttonStylePagination}`}>
                    <PaginationLink
                    href="#"
                    next
                    />
                </PaginationItem>
                <PaginationItem className={`${styles.buttonStylePagination}`}>
                    <PaginationLink
                    href="#"
                    last
                    />
                </PaginationItem>
            </Pagination>
        </div>
    </div>
  )
}

export default EmployeeListPage