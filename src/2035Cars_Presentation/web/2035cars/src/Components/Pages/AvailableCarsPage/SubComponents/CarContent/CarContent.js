import React from 'react'
import styles from './CarContent.module.css'
import CarItem from './CarItem/CarItem'
import PageButton from './PageButtons/PageButton'

function CarContent(props) {

  return (
    <>
        <div className={styles.contentWrapper}>

            {/* {
              props.cars.map((item, index) => {
                return (
                  <CarItem key={index}
                            car={item}
                            hours={props.hoursForRental}/>
                )
              })
            } */}

            <CarItem />
            <CarItem />
            <CarItem />
            <CarItem />
            <PageButton amountOfPages = {7}
                        currentPage = {1}/>
            
            {/* <PageButton amountOfPages = {props.amountOfPages}
                        currentPage = {props.currentPage}/> */}
        </div>
    </>
  )
}

export default CarContent