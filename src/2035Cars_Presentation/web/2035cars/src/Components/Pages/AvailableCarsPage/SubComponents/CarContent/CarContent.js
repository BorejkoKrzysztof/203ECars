import React from 'react'
import styles from './CarContent.module.css'
import CarItem from './CarItem/CarItem'

function CarContent() {
  return (
    <>
        <div className={styles.contentWrapper}>
            <CarItem />
            <CarItem />
            <CarItem />
        </div>
    </>
  )
}

export default CarContent