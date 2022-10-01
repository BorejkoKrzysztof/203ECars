import React from 'react'
import styles from './CarContent.module.css'
import CarItem from './CarItem/CarItem'
import PageButton from './PageButtons/PageButton'

function CarContent() {
  return (
    <>
        <div className={styles.contentWrapper}>
            <CarItem />
            <CarItem />
            <CarItem />
            <CarItem />
            <PageButton amountOfPages = {7}
                        currentPage = {1}/>
        </div>
    </>
  )
}

export default CarContent