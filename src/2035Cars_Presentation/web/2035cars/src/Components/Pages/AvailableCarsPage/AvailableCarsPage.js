import React, { useEffect, useState } from 'react'
import styles from './AvailableCarsPage.module.css'
import CarContent from './SubComponents/CarContent/CarContent'
import Filters from './SubComponents/Filters/Filters'
import LoadingCircle from './SubComponents/LoadingCircle/LoadingCircle'

function AvailableCarsPage() {

  const [areCarsLoaded, setAreCarsLoaded] = useState(true)

  const DownloadCars = async () => {

  }

  useEffect(() => {
    document.title = 'Dostępne samochody'
  }, [])

  return (
    <div className={styles.availableCarsWrapper}>
      <div className={styles.AvailableCarsContent}>
        <Filters />
        {areCarsLoaded ? <CarContent /> : <LoadingCircle />}
      </div>
    </div>
  )
}

export default AvailableCarsPage