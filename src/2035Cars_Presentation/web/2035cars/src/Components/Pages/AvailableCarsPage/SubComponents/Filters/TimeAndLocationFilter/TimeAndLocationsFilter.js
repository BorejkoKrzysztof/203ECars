import React, { useEffect, useState } from 'react'
import styles from './TimeAndLocationsFilter.module.css'
import { IoLocationSharp, IoTimeSharp } from 'react-icons/io5'
import { BsFillCalendarDateFill } from 'react-icons/bs'
import { FaWindowClose } from 'react-icons/fa'
import possibleHours from '../../../../MainPage/SubComponents/Banner/hoursToSelect'
import Cookies from 'universal-cookie'
import axios from '../../../../../../Axios/axiosDefault'

function TimeAndLocationsFilter(props) {

const cityWithLocationDefault = 'Wybierz wypożyczalnie'

const [locationFormState, setLocationFormState] = useState(false)
const [citiesWithLocations, setCitieWithLocations] = useState([])

const downloadCitiesWithLocations = () => {
    axios.get('/rental/allcitieswithlocations')
            .then(response => {
                setCitieWithLocations([...response.data])
            })
            .catch(error => {
                console.log(error)
            })
}

const getDefaultTimeFrom = () => {
    let currentHour = new Date().getHours()
    let currentMinute = new Date().getMinutes()

    if (currentHour < 23) {
        if (currentMinute < 30) {
            currentMinute = 30
        } else {
            currentHour = currentHour + 1
            currentMinute = 0
        }
    }
    else {
        if (currentMinute < 30) {
            currentMinute = 30
        } else {
            props.setDateFrom(new Date().getDate() + 1)
            currentHour = 0
            currentMinute = 0
        }
    }

    props.setHourFrom([currentHour, currentMinute])
}

const getDefaultTimeTo = () => {
    let currentHour = new Date().getHours();
    let currentMinute = new Date().getMinutes();

    if (currentHour < 23) {
        if (currentMinute < 30) {
            currentHour = currentHour + 1
            currentMinute = 30
        } else {
            currentHour = currentHour + 2
            currentMinute = 0
        }
    } else {
        if (currentMinute < 30) {
            currentHour = 0
            currentMinute = 30
        } else {
            props.setDateFrom(new Date().getDate() + 1)
            currentHour = 1
            currentMinute = 0
        }
    }


    props.setHourTo([currentHour, currentMinute])
}

const setLocationFromHandler = (event) => {
    const dataArray = event.target.value.split(', ')
    props.setCityFrom(dataArray[0])
    props.setLocationFrom(dataArray[1])
}

const setLocationToHandler = (event) => {
    const dataArray = event.target.value.split(', ')
    props.setCityTo(dataArray[0])
    props.setLocationTo(dataArray[1])
}

const SetDateFromHandler = (event) => {
    props.setDateFrom(new Date(event.target.value))
}

const setHourFromHandler = (event) => {
    const stringArr = event.target.value.split(',')
    props.setHourFrom([parseInt(stringArr[0]), parseInt(stringArr[1])])
}

const SetDateToHandler = (event) => {
    const newDateTO = new Date(event.target.value)
    if (props.dateFrom > newDateTO) {
        alert('Data końcowa musi być późniejsza lub równa dacie początkowej')
    } else {
        props.setDateTo(newDateTO)
    }
}

const setHourToHandler = (event) => {
    const stringArr = event.target.value.split(',')
    const selectedHour = [parseInt(stringArr[0]), parseInt(stringArr[1])]
    if(props.dateFrom.getTime() === props.dateTo.getTime()) {
        if (props.hourFrom[0] === selectedHour[0]) {
            if (selectedHour[1] - props.hourFrom[1] < 30) {
                alert('Podaj późniejszą godzinę zakończenia!')
            } else {
                props.setHourTo([...selectedHour])
            }
        } else if (props.hourFrom[0] > selectedHour[0]) {
            alert('Niepoprawna godzina zakończenia!')
        } else {
            props.setHourTo([...selectedHour])
        }
    } else {
        props.setHourTo([...selectedHour])
    }
}

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
          props.setCityFrom(cityFromCookie)
          props.setLocationFrom(locationFromCookie)
          props.setCityTo(cityToCookie)
          props.setLocationTo(locationToCookie)

          const dateStart = new Date(dateTimeFromCookie)
          const dateEnd = new Date(dateTimeToCookie)

          props.setDateFrom(dateStart)
          props.setDateTo(dateEnd)
          props.setHourFrom([dateStart.getHours(), dateStart.getMinutes()])
          props.setHourTo([dateEnd.getHours(), dateEnd.getMinutes()])
          props.setLocationIsSetted(true)
    }
  }

const resetFormHandler = () => {
    setLocationFormState(true)
}

const formLocationAndTimeHandler = async () => {
    // event.preventDefault()
    props.setSettedFromTimeAndLocationForm(true)
    setLocationFormState(true)
}


useEffect(() => {
    const cookies = new Cookies()
    const dateTimeFromCookie = cookies.get('dateTimeFrom')
    const dateTimeToCookie = cookies.get('dateTimeTo')

    if (dateTimeFromCookie !== undefined && dateTimeToCookie !== undefined) {
        getDefaultTimeFrom()
        getDefaultTimeTo()
    }
    downloadCitiesWithLocations()

}, [])

useEffect(() => {
    setLocationDatasFromCookie()
}, [locationFormState])

  return (
    <>
    <div className={ !locationFormState ? 
        styles.locationsFilterContent
                  :
        `${styles.locationsFilterContent} ${styles.locationsFilterContentActive}`}>
        <div className={styles.rentCarDetail}>
            <h5>Szczegóły Wynajmu:</h5>
        </div>
        <div className={styles.locationInfo}>
            <h2>
                POCZĄTEK :
            </h2>
            <h6>
                <IoLocationSharp className={styles.locationInfoIcons}/>
                {
                    props.locationIsSetted ? 
                            <>
                                {props.cityFrom} {props.locationFrom}
                            </>
                            :
                            <>
                                Wybierz lokalizację
                            </>
                }
            </h6>
            <p>
                <BsFillCalendarDateFill className={styles.locationInfoIcons}/>
                {
                    props.locationIsSetted ? 
                        <>
                            {props.dateTimeFrom.toLocaleDateString('pl-PL')}
                        </>
                        :
                        <>
                        Wybierz datę
                        </>
                }&nbsp;
                <IoTimeSharp className={styles.locationInfoIcons}/>
                {
                    props.locationIsSetted ? 
                        <>
                            {props.dateTimeFrom.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' })}
                        </>
                        :
                        <>
                        --:--
                        </>
                }
            </p>
        </div>
        <hr className={styles.locationInfoSeparateLine}/>
        <div className={styles.locationInfo}>
            <h2>
                KONIEC :
            </h2>
            <h6>
                <IoLocationSharp className={styles.locationInfoIcons}/>
                {
                    props.locationIsSetted ? 
                            <>
                                {props.cityTo} {props.locationTo}
                            </>
                            :
                            <>
                                Wybierz lokalizację
                            </>
                }
            </h6>
            <p>
                <BsFillCalendarDateFill className={styles.locationInfoIcons}/>
                {
                    props.locationIsSetted ? 
                        <>
                            {props.dateTimeTo.toLocaleDateString('pl-PL')}
                        </>
                        :
                        <>
                        Wybierz datę
                        </>
                }&nbsp;
                <IoTimeSharp className={styles.locationInfoIcons}/>
                {
                    props.locationIsSetted ? 
                        <>
                            {props.dateTimeTo.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' })}
                        </>
                        :
                        <>
                        --:--
                        </>
                }
            </p>
        </div>
        <div className={styles.locationFormOpenButtonWrapper}>
            <button className={styles.themeButton} 
                onClick={resetFormHandler}>
                EDYTUJ
            </button>
        </div>
    </div>
    <div className={!locationFormState ? 
        `${styles.locationFormWrapper}`
                        :
        `${styles.locationFormWrapper} ${styles.locationFormWrapperActive}`}>
        <div className={styles.closeLoactionFormButtonArea}>
            <h5>Edytuj datę:</h5>
            <button className={styles.closeLocationFormButton}
                onClick={() => { setLocationFormState(false) }}>
                <FaWindowClose />
            </button>
        </div>
        <form className={styles.editDateTimeRent}>
            <div className={styles.locationInfoForm}>
                <label>POCZĄTEK :</label>
                <select value={`${props.cityFrom}, ${props.locationFrom}`}
                                    onChange={setLocationFromHandler}>
                {
                    [`${cityWithLocationDefault}`, ...citiesWithLocations].map((item, index) => {
                        return (
                            <option key={index} value={item}>
                                {item}
                            </option>
                        )
                    })
                }
                </select>
            </div>
            <div className={styles.locationInfoForm}>
                <label>KONIEC :</label>
                <select value={`${props.cityTo}, ${props.locationTo}`} 
                                    onChange={setLocationToHandler}>
                {
                    [`${cityWithLocationDefault}`, ...citiesWithLocations].map((item, index) => {
                        return (
                            <option key={index} value={item}>
                                {item}
                            </option>
                        )
                    })
                }
                </select>
            </div>
            <div className={styles.locationInfoForm}>
                <label>DATA ROZPOCZĘCIA :</label>
                <div>
                    <input type='date' 
                            value={props.dateFrom.toLocaleDateString('en-CA')}
                            onChange={SetDateFromHandler}>
                    </input>
                    <select value={`${props.hourFrom}`} onChange={setHourFromHandler}>
                    {
                        possibleHours.map((item, index) => {
                            return (
                                <option key={index} value={`${item.value}`}>
                                    {item.label}
                                </option>
                            )
                        })
                    }
                    </select>
                </div>
            </div>
            <div className={styles.locationInfoForm}>
                <label>DATA ZAKOŃCZENIA :</label>
                <div>
                    <input type='date'
                            value={props.dateTo.toLocaleDateString('en-CA')}
                            onChange={SetDateToHandler}>
                    </input>
                    <select value={`${props.hourTo}`} onChange={setHourToHandler}>
                    {
                        possibleHours.map((item, index) => {
                            return (
                                <option key={index} value={`${item.value}`}>
                                    {item.label}
                                </option>
                            )
                        })
                    }
                    </select>
                </div>
            </div>
            <div className={styles.submitButtonWrapper}>
                <button className={styles.submitButton}
                             onClick={formLocationAndTimeHandler}>SZUKAJ</button>
            </div>
        </form>
    </div>
</>
  )
}

export default TimeAndLocationsFilter