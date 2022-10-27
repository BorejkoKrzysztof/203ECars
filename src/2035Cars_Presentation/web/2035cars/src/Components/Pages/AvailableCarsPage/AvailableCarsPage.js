import React, { useEffect, useState } from 'react'
import styles from './AvailableCarsPage.module.css'
import CarContent from './SubComponents/CarContent/CarContent'
import Filters from './SubComponents/Filters/Filters'
import LackOfCars from './SubComponents/LackOfCars/LackOfCars'
import LoadingCircle from './SubComponents/LoadingCircle/LoadingCircle'
import axios from '../../../Axios/axiosDefault'
import Cookies from 'universal-cookie'


function AvailableCarsPage() {

  const cityDefaultValue = 'Wybierz miasto'
  const locationDefaultValue = 'Wybierz lokalizację'

  const [cityFrom, setCityFrom] = useState(`${cityDefaultValue}`)
  const [locationFrom, setLocationFrom] = useState(`${locationDefaultValue}`)
  const [cityTo, setCityTo] = useState(`${cityDefaultValue}`)
  const [locationTo, setLocationTo] = useState(`${locationDefaultValue}`)
  const [dateTimeFrom, setDateTimeFrom] = useState(new Date())
  const [dateTimeTo, setDateTimeTo] = useState(new Date())
  const [locationIsSetted, setLocationIsSetted] = useState(false)

  const [dateFrom, setDateFrom] = useState(new Date())
  const [hourFrom, setHourFrom] = useState([0,0])

  const [dateTo, setDateTo] = useState(new Date())
  const [hourTo, setHourTo] = useState([0,0])

  const [searchAllCars, setSearchAllCars] = useState(false)

  const [suvCarTypeChecked, setSuvCarTypeChecked] = useState(false)
  const [sportCarTypeChecked, setSportCarTypeChecked] = useState(false)
  const [compactCarTypeChecked, setCompactCarTypeChecked] = useState(false)
  const [sedanCarTypeChecked, setSedanCarTypeChecked] = useState(false)
  const [preferableTypeIsSetted, setPreferableTypeIsSetted] = useState(false)

  const [airConditioningChecked, setAirConditioningChecked] = useState(false)
  const [heatedSeatChecked, setHeatedSeatChecked] = useState(false)
  const [automaticGearBoxChecked, setAutomaticGearBoxChecked] = useState(false)
  const [navigationChecked, setNavigationChecked] = useState(false)

  const [hybridFuelChecked, setHybridFuelChecked] = useState(false)
  const [electricFuelChecked, setElectricFuelChecked] = useState(false)

  const [sliderVal, setSliderVal] = useState([])
  const [sliderMinDistance, setSliderMinDistance] = useState(1)
  const [minPriceForSlider, setMinPriceForSlider] = useState(0)
  const [maxPriceForSlider, setMaxPriceForSlider] = useState(1000)

  const [preferableAmountOfDoors, setPreferableAmountOfDoors] = useState(0)
  const [preferableAmountOfSeats, setPreferableAmountOfSeats] = useState(0)

  const [listOfCars, setListOfCars] = useState([])
  const [hoursForRental, setHoursForRental] = useState(-1)
  const [areCarsLoaded, setAreCarsLoaded] = useState(false)
  const [amountOfPages, setAmountOfPages] = useState(-1)
  const [currentPage, setCurrentPage] = useState(1)
  const [amountOfHours, setAmountOfHours] = useState(-1)

  const [settedFromTimeAndLocationForm, setSettedFromTimeAndLocationForm] = useState(false)
  const [settedFromCarFeaturesForm, setSettedFromCarFeaturesForm] = useState(false)
  const [resetedFromCarFeaturesForm, setResetedFromCarFeaturesForm] = useState(false)

  const [minPriceForCarCollection, setMinPriceForCarCollection] = useState(0)
  const [maxPriceForCarCollection, setMaxPriceForCarCollection] = useState(0)

  const [showCarFeaturesFormResetButton, setShowCarFeaturesFormResetButton] = useState(false)
  

  const setLocationDatasFromCookie = () => {
    const cookies = new Cookies()
    const cityFromCookie = cookies.get('selectedCityFrom')
    const locationFromCookie = cookies.get('selectedLocationFrom')
    const cityToCookie = cookies.get('selectedCityTo')
    const locationToCookie = cookies.get('selectedLocationTo')
    const dateTimeFromCookie = cookies.get('dateTimeFrom')
    const dateTimeToCookie = cookies.get('dateTimeTo')

    if (cityFromCookie !== undefined && locationFromCookie !== undefined && 
        cityToCookie !== undefined && locationToCookie !== undefined &&
        dateTimeFromCookie !== undefined && dateTimeToCookie !== undefined) {
          setCityFrom(cityFromCookie)
          setLocationFrom(locationFromCookie)
          setCityTo(cityToCookie)
          setLocationTo(locationToCookie)
          setDateTimeFrom(new Date(dateTimeFromCookie))
          setDateTimeTo(new Date(dateTimeToCookie))
          setLocationIsSetted(true)
    }
  }

  const setCookiesFromDatesAndLocationsData = () => {
    const cookies = new Cookies()
    cookies.set('selectedCityFrom', `${cityFrom}`, { path: '/' })
    cookies.set('selectedLocationFrom', `${locationFrom}`, { path: '/' })

    if (cityTo !== cityDefaultValue || cityTo !== undefined) {
      cookies.set('selectedCityTo', `${cityTo}`, { path: '/' })
      cookies.set('selectedLocationTo', `${locationTo}`, { path: '/' })
    } else {
      cookies.set('selectedCityTo', `${cityFrom}`, { path: '/' })
      cookies.set('selectedLocationTo', `${locationFrom}`, { path: '/' })
    }

    const dateStart = new Date(dateFrom)
    dateStart.setHours(hourFrom[0])
    dateStart.setMinutes(hourFrom[1])
    cookies.set('dateTimeFrom', `${dateStart}`, { path: '/' })

    const dateEnd = new Date(dateTo)
    dateEnd.setHours(hourTo[0])
    dateEnd.setMinutes(hourTo[1])
    cookies.set('dateTimeTo', `${dateEnd}`, { path: '/' })
  }

  const setCookiesFromCarEquipmentData = () => {
    const cookies = new Cookies()
    cookies.set('minPrice', `${sliderVal[0]}`, { path: '/' })
    cookies.set('maxPrice', `${sliderVal[1]}`, { path: '/' })
    cookies.set('Suv', `${suvCarTypeChecked}`, { path: '/' })
    cookies.set('Sedan', `${sedanCarTypeChecked}`, { path: '/' })
    cookies.set('Sport', `${sportCarTypeChecked}`, { path: '/' })
    cookies.set('Compact', `${compactCarTypeChecked}`, { path: '/' })
    cookies.set('AirCooling', `${airConditioningChecked}`, { path: '/' })
    cookies.set('HeatingSeats', `${heatedSeatChecked}`, { path: '/' })
    cookies.set('AutomaticGearBox', `${automaticGearBoxChecked}`, { path: '/' })
    cookies.set('BuildInNavigation', `${navigationChecked}`, { path: '/' })
    cookies.set('AmountOfDoors', `${preferableAmountOfDoors}`, { path: '/' })
    cookies.set('AmountOfSeats', `${preferableAmountOfSeats}`, { path: '/' })
    cookies.set('ResetButton', `${resetedFromCarFeaturesForm}`, { path: '/' })
  }

  const setPreferableCarType = () => {
    const cookies = new Cookies()
    const sedanTypeCookie = cookies.get('Sedan')
    const sportTypeCookie = cookies.get('Sport')
    const suvTypeCookie = cookies.get('Suv')
    const compactTypeCookie = cookies.get('Kompakt')

    if (sedanTypeCookie !== undefined || sportTypeCookie !== undefined ||
        suvTypeCookie !== undefined || compactTypeCookie !== undefined) {

        if (sedanTypeCookie) {
          setSedanCarTypeChecked(sedanTypeCookie === 'true')
        }
        if (sportTypeCookie) {
          setSportCarTypeChecked(sportTypeCookie === 'true')
        }
        if (suvTypeCookie) {
          setSuvCarTypeChecked(suvTypeCookie === 'true')
        }
        if (compactTypeCookie) {
          setCompactCarTypeChecked(compactTypeCookie === 'true')
        }

        setPreferableTypeIsSetted(true)
    } else {
      setSearchAllCars(true)
    }    
  }

  const downloadCarsByLocationFrom = () => {
        axios.post(`car/cars/${currentPage}/${cityFrom}/${locationFrom}`, JSON.stringify({
          AvailableFrom: dateTimeFrom,
          OrderTo: dateTimeTo,
          DesiredSuvType: suvCarTypeChecked,
          DesiredSportType: sportCarTypeChecked,
          DesiredCompactType: compactCarTypeChecked,
          DesiredSedanType: sedanCarTypeChecked,
          DesiredAirCooling: airConditioningChecked,
          DesiredHeatingSeats: heatedSeatChecked,
          DesiredAutomaticGearBox: automaticGearBoxChecked,
          DesiredBuildInNavigation: navigationChecked,
          DesiredHybridDrive: hybridFuelChecked,
          DesiredElectricDrive: electricFuelChecked,
        })).then(response => {

          setListOfCars([...response.data.cars])
          setAmountOfPages(response.data.amountOfPages)
          setAmountOfHours(response.data.amountOfHours)
          setMinPriceForCarCollection(response.data.carMinPrice)
          setMaxPriceForCarCollection(response.data.carMaxPrice)
          
          // setLocationIsSetted(false)
          setAreCarsLoaded(true)
        }).catch(error => {
          console.log(error)
        })
  }

  const downloadCarsByPreferableType = () => {
      axios.post(`car/cars/getcarsbytype/${currentPage}`, JSON.stringify({
        DesiredSuvType: suvCarTypeChecked,
        DesiredSportType: sportCarTypeChecked,
        DesiredCompactType: compactCarTypeChecked,
        DesiredSedanType: sedanCarTypeChecked,
      })).then(response => {
        setListOfCars(response.data.cars)
        setAmountOfPages(response.data.amountOfPages)
        setAmountOfHours(response.data.amountOfHours)
        setMinPriceForCarCollection(response.data.carMinPrice)
        setMaxPriceForCarCollection(response.data.carMaxPrice)

        setAreCarsLoaded(true)
      }).catch(error => {
        console.log(error)
      })
  }

  const downloadAllCars = () => {
    axios.get(`car/cars/getallcars/${currentPage}`)
          .then(response => {
            setListOfCars(response.data.cars)
            setAmountOfPages(response.data.amountOfPages)
            setAmountOfHours(response.data.amountOfHours)
            setMinPriceForCarCollection(response.data.carMinPrice)
            setMaxPriceForCarCollection(response.data.carMaxPrice)

            setAreCarsLoaded(true)
          })
          .catch(error => {
            console.log(error)
          })
  }

  const downloadCarsByCarEquipment = () => {

      const from = new Date(dateFrom)
      from.setHours(hourFrom[0])
      from.setMinutes(hourFrom[1])
      const to = new Date(dateTo)
      to.setHours(hourTo[0])
      to.setMinutes(hourTo[1])

      axios.post(`car/cars/getcarsbycarequipment/${currentPage}`, JSON.stringify({
          CityFrom: cityFrom !== cityDefaultValue ? cityFrom : '',
          LocationFrom: locationFrom !== locationDefaultValue ? locationFrom :  '', 
          CityTo: cityTo !== cityDefaultValue ? cityTo : '',
          LocationTo: locationTo !== locationDefaultValue ? locationTo : '',
          DateTimeFrom: from,
          DateTimeTo: to,
          MinPrice: sliderVal[0],
          MaxPrice: sliderVal[1],
          DesiredSuv: suvCarTypeChecked,
          DesiredSedan: sedanCarTypeChecked,
          DesiredSport: sportCarTypeChecked,
          DesiredCompact: compactCarTypeChecked,
          DesiredAirConditioning: airConditioningChecked,
          DesiredHeatingSeats: heatedSeatChecked,
          DesiredAutomaticGearBox: automaticGearBoxChecked,
          DesiredBuildInNavigation: navigationChecked,
          DesiredHybridDrive: hybridFuelChecked,
          DesiredElectricDrive: electricFuelChecked,
          AmountOfDoors: preferableAmountOfDoors,
          AmountOfSeats: preferableAmountOfSeats
      })).then(response => {
          setListOfCars(response.data.cars)
          setAmountOfPages(response.data.amountOfPages)
          setAmountOfHours(response.data.amountOfHours)
          setMinPriceForCarCollection(response.data.carMinPrice)
          setMaxPriceForCarCollection(response.data.carMaxPrice)

          setAreCarsLoaded(true)
      }).catch(error => {
          console.log(error)
      })
  }

  useEffect(() => {
    document.title = 'Dostępne samochody'
    setLocationDatasFromCookie()
  }, [])

  useEffect(() => {
    if(locationIsSetted) {
      downloadCarsByLocationFrom()
    } else {
      setPreferableCarType()
    }
  }, [locationIsSetted])

  useEffect(() => {
    if (preferableTypeIsSetted) {
      downloadCarsByPreferableType()
    }
  }, [preferableTypeIsSetted])

  useEffect(() => {
      if (!locationIsSetted && !preferableTypeIsSetted && searchAllCars) {
        downloadAllCars()
      }
  }, [searchAllCars])

  useEffect(() => {

      if(locationIsSetted) {
        downloadCarsByLocationFrom()
      } else if (preferableTypeIsSetted) {
        downloadCarsByPreferableType()
      } else if (!locationIsSetted && !preferableTypeIsSetted && searchAllCars) {
        downloadAllCars()
      }
  }, [currentPage])

  useEffect(() => {

      if (settedFromTimeAndLocationForm) {
        setAreCarsLoaded(false)
        setCurrentPage(1)
        setCookiesFromDatesAndLocationsData()
        setLocationDatasFromCookie()
        downloadCarsByLocationFrom()
        setSettedFromTimeAndLocationForm(false)
      }
  }, [settedFromTimeAndLocationForm])

  useEffect(() => {

      if (listOfCars.length === 0) {
        setMinPriceForSlider(0)
        setMaxPriceForSlider(0)
        const minDistance = 0
        setSliderMinDistance(minDistance)
        setSliderVal([0, 0])
        return
      }

      // if (listOfCars.length > 0) {
        setMinPriceForSlider(minPriceForCarCollection)
        setMaxPriceForSlider(maxPriceForCarCollection)
        const minDistance = maxPriceForCarCollection / 10
        setSliderMinDistance(minDistance)
        setSliderVal([minPriceForCarCollection, maxPriceForCarCollection])
  }, [listOfCars])

  useEffect(() => {

    if(settedFromCarFeaturesForm) {

      // if (cityFrom !== cityDefaultValue || locationFrom !== locationDefaultValue)
      // {
        setShowCarFeaturesFormResetButton(true)
        setAreCarsLoaded(false)
        setCookiesFromCarEquipmentData()
        setCurrentPage(1)
        downloadCarsByCarEquipment()
        setSettedFromCarFeaturesForm(false)
      // } else {
      //   alert
      // }
    }
  }, [settedFromCarFeaturesForm])

  useEffect(() => {
      if (resetedFromCarFeaturesForm) {
        setCookiesFromCarEquipmentData()
        if (cityFrom !== cityDefaultValue || locationFrom !== locationDefaultValue) {
          downloadCarsByLocationFrom()
        } else {
          downloadAllCars()
        }
        
        setResetedFromCarFeaturesForm(false)
      }
  }, [resetedFromCarFeaturesForm])

  return (
    <div className={styles.availableCarsWrapper}>
      <div className={styles.AvailableCarsContent}>
        <Filters 
                  cityFrom={cityFrom}
                  setCityFrom={setCityFrom}
                  locationFrom={locationFrom}
                  setLocationFrom={setLocationFrom}
                  cityTo={cityTo}
                  setCityTo={setCityTo}
                  locationTo={locationTo}
                  setLocationTo={setLocationTo}
                  dateTimeFrom={dateTimeFrom}
                  setDateTimeFrom={setDateTimeFrom}
                  dateTimeTo={dateTimeTo}
                  setDateTimeTo={setDateTimeTo}
                  suvCarTypeChecked={suvCarTypeChecked}
                  setSuvCarTypeChecked={setSuvCarTypeChecked}
                  sportCarTypeChecked={sportCarTypeChecked}
                  setSportCarTypeChecked={setSportCarTypeChecked}
                  compactCarTypeChecked={compactCarTypeChecked}
                  setCompactCarTypeChecked={setCompactCarTypeChecked}
                  sedanCarTypeChecked={sedanCarTypeChecked}
                  setSedanCarTypeChecked={setSedanCarTypeChecked}
                  airConditioningChecked={airConditioningChecked}
                  setAirConditioningChecked={setAirConditioningChecked}
                  heatedSeatChecked={heatedSeatChecked}
                  setHeatedSeatChecked={setHeatedSeatChecked}
                  automaticGearBoxChecked={automaticGearBoxChecked}
                  setAutomaticGearBoxChecked={setAutomaticGearBoxChecked}
                  navigationChecked={navigationChecked}
                  setNavigationChecked={setNavigationChecked}
                  hybridFuelChecked={hybridFuelChecked}
                  setHybridFuelChecked={setHybridFuelChecked}
                  electricFuelChecked={electricFuelChecked}
                  setElectricFuelChecked={setElectricFuelChecked}
                  sliderVal={sliderVal}
                  setSliderVal={setSliderVal}
                  locationIsSetted={locationIsSetted}
                  dateFrom={dateFrom}
                  setDateFrom={setDateFrom}
                  hourFrom={hourFrom}
                  setHourFrom={setHourFrom}
                  dateTo={dateTo}
                  setDateTo={setDateTo}
                  hourTo={hourTo}
                  setHourTo={setHourTo}
                  setLocationIsSetted={setLocationIsSetted}
                  setSettedFromTimeAndLocationForm={setSettedFromTimeAndLocationForm}
                  sliderMinDistance={sliderMinDistance}
                  maxPriceForSlider={maxPriceForSlider}
                  minPriceForSlider={minPriceForSlider}
                  preferableAmountOfDoors={preferableAmountOfDoors}
                  setPreferableAmountOfDoors={setPreferableAmountOfDoors}
                  preferableAmountOfSeats={preferableAmountOfSeats}
                  setPreferableAmountOfSeats={setPreferableAmountOfSeats}
                  setSettedFromCarFeaturesForm={setSettedFromCarFeaturesForm}
                  setResetedFromCarFeaturesForm={setResetedFromCarFeaturesForm}
                  showCarFeaturesFormResetButton={showCarFeaturesFormResetButton}
                  setShowCarFeaturesFormResetButton={setShowCarFeaturesFormResetButton}
                  />
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
                                setPage={setCurrentPage}
                                amountOfHours={amountOfHours}/>

        }
      </div>
    </div>
  )
}

export default AvailableCarsPage