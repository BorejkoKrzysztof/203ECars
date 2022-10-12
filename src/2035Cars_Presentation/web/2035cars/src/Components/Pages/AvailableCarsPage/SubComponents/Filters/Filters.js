import React from 'react'
import styles from './Filters.module.css'
import TimeAndLocationsFilter from './TimeAndLocationFilter/TimeAndLocationsFilter'
import CarFeaturesFilter from './CarFeaturesFilter/CarFeaturesFilter'


function Filters(props) {

  return (
    <>
        <div className={styles.filtersWrapper}>
          <div className={styles.firstFilterWrapper}>
            <TimeAndLocationsFilter />
          </div>
          <CarFeaturesFilter />
        </div>
    </>
  )
}

export default Filters