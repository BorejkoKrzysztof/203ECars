import React, { useState } from 'react'
import styles from './EmployeeListPage.module.css'
import { Table,
        Pagination,
        PaginationItem,
        PaginationLink } from 'reactstrap'

function EmployeeListPage() {


    useState(() => {
        document.title = 'Lista Pracowników'
    }, [])

  return (
    <div className={styles.wrapper}>
        <h1 className={styles.employeePageTitle}>Lista Pracowników:</h1>
        <div className={styles.employeeTableListArea}>
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
                    <td>
                        @mdo
                    </td>
                    <td>
                        <button className={styles.buttonStyle}>
                            Zobacz
                        </button>
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
                    <td>
                        @fat
                    </td>
                    <td>
                        <button className={styles.buttonStyle}>
                            Zobacz
                        </button>
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
                    <td>
                        @twitter
                    </td>
                    <td>
                        <button className={styles.buttonStyle}>
                            Zobacz
                        </button>
                    </td>
                    </tr>
                </tbody>
            </Table>
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