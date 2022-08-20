import React, { useEffect, useState } from 'react'
import styles from './AvailableCarsPage.module.css'
import CarContent from './SubComponents/CarContent/CarContent'
import Filters from './SubComponents/Filters/Filters'

function AvailableCarsPage() {

  useEffect(() => {
    document.title = 'Dostępne samochody'
  }, [])

  return (
    <div className={styles.availableCarsWrapper}>
      <div className={styles.AvailableCarsContent}>
        <Filters />
        <CarContent />
      </div>
    </div>
  )
}

export default AvailableCarsPage