import React, { useState } from 'react'
import styles from './CarListPage.module.css'
import CarCard from './subComponents/CarCard'
import { Pagination,
    PaginationItem,
    PaginationLink } from 'reactstrap'
import axios from '../../../axios/axiosAuthorize'

function CarListPage() {

    const [amountOfPages, setAmountOfPages] = useState(0)
    const [currentPage, setCurrentPage] = useState(1)
    const [cars, setCars] = useState([])
    const [areCarsLoaded, setAreCarsLoaded] = useState(false)

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
                                donwloadListOfCar()
                            }}>
                            {i + 1}
                            </PaginationLink>
                    </PaginationItem>
                </>
            )
        }
        
        return buttons
    }

    const donwloadListOfCar = () => {
        const rentalId = localStorage.getItem('rentalId')
        axios.get(`/car/carsforrental/${rentalId}/${currentPage}`)
                .then( (response) => {
                    setCars(response.data.cars)
                    setCurrentPage(() => { return response.data.currentPage })
                    setAmountOfPages(() => { return response.data.amountOfPages })
                    setAreCarsLoaded(true)
                })
                .catch( (error) => {
                    console.log(error)
                })
    }

 useState(() => {
    document.title = 'Zarządzaj samochodami'
    donwloadListOfCar()
 }, [])

  return (
    <div className={styles.wrapper}>
        <div className={styles.pageDescription}>
            <p>Tutaj możesz znaleźć informacje nt. floty samochodów oraz modyfikować je i usuwać.</p>
            <a  href='/dodajsamochod'
                className={`btn btn-primary ${styles.colorButtonLink}`} 
                style={{ marginLeft: "5px" }}>
                Dodaj nowy samochód
            </a>
        </div>
        <div className={styles.cars}>
            {
                areCarsLoaded ?
                <>
                    {
                        cars.map( (item, index) => {
                            return (
                                <React.Fragment key={index}>
                                    <CarCard 
                                    id = {item.carUniqueReferrence}
                                    brand = {item.brand}
                                    model = {item.model}
                                    image = {item.image}
                                    />
                                </React.Fragment>
                            )
                        })
                    }
                </>
                :
                <></>
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
                                setAreCarsLoaded(false)
                                donwloadListOfCar()
                            }}
                            />
                        </PaginationItem>
                        <PaginationItem className={`${styles.buttonStylePagination}`}>
                            <PaginationLink
                            onClick={() => {
                                setCurrentPage(prev => {
                                    return (prev - 1)
                                })
                                setAreCarsLoaded(false)
                                donwloadListOfCar()
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
                                setAreCarsLoaded(false)
                                donwloadListOfCar()
                            }}
                            next
                            />
                        </PaginationItem>
                        <PaginationItem className={`${styles.buttonStylePagination}`}>
                            <PaginationLink
                            onClick={() => {
                                setCurrentPage(amountOfPages)
                                setAreCarsLoaded(false)
                                donwloadListOfCar()
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

export default CarListPage