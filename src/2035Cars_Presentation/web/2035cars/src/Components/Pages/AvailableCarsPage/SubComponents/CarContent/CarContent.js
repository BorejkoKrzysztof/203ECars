import React from 'react'
import styles from './CarContent.module.css'
import CarItem from './CarItem/CarItem'
import PageButton from './PageButtons/PageButton'

function CarContent(props) {

  return (
    <>
        <div className={styles.contentWrapper}>

            {
              props.cars.map((item, index) => {
                return (
                  <CarItem key={index}
                            car={item}
                            hours={props.amountOfHours}/>
                )
              })
            }
            <PageButton amountOfPages = {props.amountOfPages}
                        currentPage = {props.currentPage}
                        setPage={props.setPage}/>
        </div>
    </>
  )
}

export default CarContent