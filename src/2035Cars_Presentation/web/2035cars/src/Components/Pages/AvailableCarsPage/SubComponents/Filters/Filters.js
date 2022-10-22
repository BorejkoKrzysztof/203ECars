import React from 'react'
import styles from './Filters.module.css'
import TimeAndLocationsFilter from './TimeAndLocationFilter/TimeAndLocationsFilter'
import CarFeaturesFilter from './CarFeaturesFilter/CarFeaturesFilter'


function Filters(props) {

  return (
    <>
        <div className={styles.filtersWrapper}>
          <div className={styles.firstFilterWrapper}>
            <TimeAndLocationsFilter 
                      cityFrom={props.cityFrom}
                      setCityFrom={props.setCityFrom}
                      locationFrom={props.locationFrom}
                      setLocationFrom={props.setLocationFrom}
                      cityTo={props.cityTo}
                      setCityTo={props.setCityTo}
                      locationTo={props.locationTo}
                      setLocationTo={props.setLocationTo}
                      dateTimeFrom={props.dateTimeFrom}
                      setDateTimeFrom={props.setDateTimeFrom}
                      dateTimeTo={props.dateTimeTo}
                      setDateTimeTo={props.setDateTimeTo}
                      locationIsSetted={props.locationIsSetted}
                      dateFrom={props.dateFrom}
                      setDateFrom={props.setDateFrom}
                      hourFrom={props.hourFrom}
                      setHourFrom={props.setHourFrom}
                      dateTo={props.dateTo}
                      setDateTo={props.setDateTo}
                      hourTo={props.hourTo}
                      setHourTo={props.setHourTo}
            />
          </div>
          <CarFeaturesFilter 
                      suvCarTypeChecked={props.suvCarTypeChecked} 
                      setSuvCarTypeChecked={props.setSuvCarTypeChecked}
                      sportCarTypeChecked={props.sportCarTypeChecked}
                      setSportCarTypeChecked={props.setSportCarTypeChecked}
                      compactCarTypeChecked={props.compactCarTypeChecked}
                      setCompactCarTypeChecked={props.setCompactCarTypeChecked}
                      sedanCarTypeChecked={props.sedanCarTypeChecked}
                      setSedanCarTypeChecked={props.setSedanCarTypeChecked}
                      airConditioningChecked={props.airConditioningChecked}
                      setAirConditioningChecked={props.setAirConditioningChecked}
                      heatedSeatChecked={props.heatedSeatChecked}
                      setHeatedSeatChecked={props.setHeatedSeatChecked}
                      automaticGearBoxChecked={props.automaticGearBoxChecked}
                      setAutomaticGearBoxChecked={props.setAutomaticGearBoxChecked}
                      navigationChecked={props.navigationChecked}
                      setNavigationChecked={props.setNavigationChecked}
                      hybridFuelChecked={props.hybridFuelChecked}
                      setHybridFuelChecked={props.setHybridFuelChecked}
                      electricFuelChecked={props.electricFuelChecked}
                      setElectricFuelChecked={props.setElectricFuelChecked}
                      sliderVal={props.sliderVal}
                      setSliderVal={props.setSliderVal}
          />
        </div>
    </>
  )
}

export default Filters