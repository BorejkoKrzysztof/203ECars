import React, { useEffect, useState } from 'react'
import styles from './AvailableCarsPage.module.css'
import CarContent from './SubComponents/CarContent/CarContent'
import Filters from './SubComponents/Filters/Filters'
import LackOfCars from './SubComponents/LackOfCars/LackOfCars'
import LoadingCircle from './SubComponents/LoadingCircle/LoadingCircle'
import axios from '../../../Axios/axiosDefault'

function AvailableCarsPage() {

  const [listOfCars, setListOfCars] = useState([1])
  const [hoursForRental, setHoursForRental] = useState(-1)
  const [areCarsLoaded, setAreCarsLoaded] = useState(true)
  const [amountOfPages, setAmountOfPages] = useState(-1)
  const [currentPage, setCurrentPage] = useState(-1)
  const [amountOfHours, setAmountOfHours] = useState(-1)

  const DownloadCars = async () => {
    try {
      const response = await axios.get('/') // dodac sciezke
      setHoursForRental(response.data.hours)
      setAmountOfPages(response.data.amountOfPages)
      setCurrentPage(response.data.currentPage)
      setAmountOfHours(response.data.amountOfHours)
      setAreCarsLoaded(true)
      setListOfCars(response.data.cars)
    } catch (error) {
      console.log(error)
    }
  }

  useEffect(() => {
    document.title = 'Dostępne samochody'
    // DownloadCars()
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
                          <CarContent 
                                cars={listOfCars} 
                                hours={hoursForRental}
                                amountOfPages={amountOfPages}
                                currentPage={currentPage}
                                amountOfHours={amountOfHours}/>

        }
      </div>
    </div>
  )
}

export default AvailableCarsPage