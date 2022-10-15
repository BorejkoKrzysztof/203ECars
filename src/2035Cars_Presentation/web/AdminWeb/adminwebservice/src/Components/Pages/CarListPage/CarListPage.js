import React, { useState } from 'react'
import styles from './CarListPage.module.css'
import CarCard from './subComponents/CarCard'

function CarListPage() {

 useState(() => {
    document.title = 'Zarządzaj samochodami'
 })

  return (
    <div className={styles.wrapper}>
        <div className={styles.pageDescription}>
            <p>Tutaj możesz znaleźć informacje nt. floty samochodów oraz modyfikować je i usuwać.</p>
            <a className={`btn btn-primary ${styles.colorButtonLink}`} style={{ marginLeft: "5px" }}>
                Dodaj nowy samochód
            </a>
        </div>
        <div className={styles.cars}>
            <CarCard />
            <CarCard />
            <CarCard />
            <CarCard />
        </div>
        <div className={styles.paginationArea}>
            {/* <Pagination>
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
                </Pagination> */}
        </div>
    </div>
  )
}

export default CarListPage