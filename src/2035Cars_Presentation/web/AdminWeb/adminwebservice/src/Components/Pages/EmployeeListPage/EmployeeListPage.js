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
    // const [amountOfPagess, setAmountOfPagess] = useState(2)
    const [employeesCollection, setEmployeesCollection] = useState([])

    const seeEmployeeDetailsHandler = (employeeID) => {
        sessionStorage.setItem('EmployeeIdForDetails', `${employeeID}`)
        window.location.href = '/szczegolypracownika'
    }

    const paginationButtons = (pages) => {
        let buttons = []

        for (let i = 0; i < pages; i++) {
            buttons.push(
                <>
                    <PaginationItem className={`${styles.buttonStylePagination}`}>
                            <PaginationLink onClick={() => {
                                setCurrentPage(() => {
                                    return (i + 1)
                                })
                                donwloadEmployeesCollection()
                            }}>
                            {i + 1}
                            </PaginationLink>
                    </PaginationItem>
                </>
            )
        }
        
        return buttons
    }

    const donwloadEmployeesCollection = () => {
        const rentalId = localStorage.getItem('rentalId')
        axios.get(`employee/getallrentalemployees/${rentalId}/${currentPage}`)
                .then( (response) => {

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
                                        <button className={styles.buttonStyle} 
                                                    onClick={() => { seeEmployeeDetailsHandler(item.id) }}>
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
            {
                amountOfPages > 1 ? 
                <>
                    <Pagination>
                        <PaginationItem className={`${styles.buttonStylePagination}`}>
                            <PaginationLink 
                            first
                            onClick={() => {
                                setCurrentPage(1)
                                donwloadEmployeesCollection()
                            }}
                            />
                        </PaginationItem>
                        <PaginationItem className={`${styles.buttonStylePagination}`}>
                            <PaginationLink
                            onClick={() => {
                                setCurrentPage(prev => {
                                    return (prev - 1)
                                })
                                donwloadEmployeesCollection()
                            }}
                            previous
                            />
                        </PaginationItem>
                        {
                            paginationButtons(amountOfPages)
                        }
                        <PaginationItem className={`${styles.buttonStylePagination}`}>
                            <PaginationLink
                            onClick={() => {
                                setCurrentPage(prev => {
                                    return (prev + 1)
                                })
                                donwloadEmployeesCollection()
                            }}
                            next
                            />
                        </PaginationItem>
                        <PaginationItem className={`${styles.buttonStylePagination}`}>
                            <PaginationLink
                            onClick={() => {
                                setCurrentPage(amountOfPages)
                                donwloadEmployeesCollection()
                            }}
                            last
                            />
                        </PaginationItem>
                    </Pagination>
                </>
                :
                <></>
            }
        </div>
    </div>
  )
}

export default EmployeeListPage