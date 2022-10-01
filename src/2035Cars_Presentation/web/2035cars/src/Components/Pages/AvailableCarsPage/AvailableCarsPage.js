import React, { useEffect, useState } from 'react'
import styles from './AvailableCarsPage.module.css'
import CarContent from './SubComponents/CarContent/CarContent'
import Filters from './SubComponents/Filters/Filters'
import LackOfCars from './SubComponents/LackOfCars/LackOfCars'
import LoadingCircle from './SubComponents/LoadingCircle/LoadingCircle'

function AvailableCarsPage() {

  const [listOfCars, setListOfCars] = useState([1])
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
        {!areCarsLoaded ? 
              <LoadingCircle />
                        :
              listOfCars.length == 0 ?
                          <LackOfCars />
                                      :
                          <CarContent />

        }
      </div>
    </div>
  )
}

export default AvailableCarsPage