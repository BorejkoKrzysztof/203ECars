import React, { useEffect, useState } from 'react'
import axios from '../../../../../Axios/axiosDefault.js'
import styles from './Banner.module.css'
import possibleHours from './hoursToSelect.js'
import Cookie from 'universal-cookie'
import { useNavigate } from 'react-router-dom'

function Banner() {

let navigate = useNavigate()

const cityDefaultValue = 'Wybierz miasto'
const locationDefaultValue = 'Wybierz lokalizację'

const [cities, setCities] = useState([])
const [locationsFrom, setLocationsFrom] = useState([])
const [locationsTo, setLocationsTo] = useState([])
const [otherCityLeaveOption, setOtherCityLeaveOption] = useState(false)


const [selectedCityFrom, setSelectedCityFrom] = useState(`${cityDefaultValue}`)
const [selectedLocationFrom, setSelectedLocationFrom] = useState(`${locationDefaultValue}`)

const [selectedCityTo, setSelectedCityTo] = useState(`${cityDefaultValue}`)
const [selectedLocationTo, setSelectedLocationTo] = useState(`${locationDefaultValue}`)

const [dateFrom, setDateFrom] = useState(new Date())
const [hourFrom, setHourFrom] = useState([])

const [dateTo, setDateTo] = useState(new Date())
const [hourTo, setHourTo] = useState([])

const RemoveCookie = (cookieName) => {
    const cookies = new Cookie()

    const selectedCookie = cookies.get(`${cookieName}`)

    if (selectedCookie !== undefined) {
        cookies.remove(`${cookieName}`, { path: '/' })
    }
}

const RemoveSetOfCookies = () => {
    RemoveCookie('selectedCityFrom')
    RemoveCookie('selectedLocationFrom')
    RemoveCookie('selectedCityTo')
    RemoveCookie('selectedLocationTo')
    RemoveCookie('dateFrom')
    RemoveCookie('hourFrom')
    RemoveCookie('dateTo')
    RemoveCookie('hourTo')
    RemoveCookie('dateTimeFrom')
    RemoveCookie('dateTimeTo')
    RemoveCookie('Suv')
    RemoveCookie('Sport')
    RemoveCookie('Sedan')
    RemoveCookie('Compact')
    RemoveCookie('AirCooling')
    RemoveCookie('AmountOfDoors')
    RemoveCookie('AmountOfSeats')
    RemoveCookie('AutomaticGearBox')
    RemoveCookie('BuildInNavigation')
    RemoveCookie('HeatingSeats')
    RemoveCookie('maxPrice')
    RemoveCookie('minPrice')
    RemoveCookie('SelectedCarUniqueNumber')
    RemoveCookie('SelectedCarBrand')
    RemoveCookie('SelectedCarModel')
    RemoveCookie('SelectedCarImage')
    RemoveCookie('SelectedCarRentalPrice')
}

const GetCities = () => {
    axios.get('/rental/cities')
            .then(response => {
                setCities([...response.data])
            })
            .catch(error => {
                console.log(error)
            })
}

const GetLocations = (city, from, to) => {
    axios.get(`rental/locations/${city}`)
            .then(response => {
                if (from === true) {
                    setLocationsFrom([...response.data])
                }
                if (to === true) {
                    setLocationsTo([...response.data])
                }
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
            setDateFrom(new Date().getDate() + 1)
            currentHour = 0
            currentMinute = 0
        }
    }

    setHourFrom([currentHour, currentMinute])
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
            setDateFrom(new Date().getDate() + 1)
            currentHour = 1
            currentMinute = 0
        }
    }


    setHourTo([currentHour, currentMinute])
}

const CityFromFormSubmitHandler = (event) => {
    setSelectedCityFrom(event.target.value)
}

const LocationFromFormSubmitHandler= (event) => {
    setSelectedLocationFrom(event.target.value)
}

const CityToFormSubmitHandler = (event) => {
    setSelectedCityTo(event.target.value)
}

const LocationToFormSubmitHandler = (event) => {
    setSelectedLocationTo(event.target.value)
}

const SetDateFromHandler = (event) => {
    setDateFrom(new Date(event.target.value))
}

const setHourFromHandler = (event) => {
    const stringArr = event.target.value.split(',')
    setHourFrom([parseInt(stringArr[0]), parseInt(stringArr[1])])
}

const SetDateToHandler = (event) => {
    const newDateTO = new Date(event.target.value)
    if (dateFrom > newDateTO) {
        alert('Data końcowa musi być późniejsza lub równa dacie początkowej')
    } else {
        setDateTo(newDateTO)
    }
}

const setHourToHandler = (event) => {
    const stringArr = event.target.value.split(',')
    // console.log('stringArr ')
    // console.log(stringArr)
    const selectedHour = [parseInt(stringArr[0]), parseInt(stringArr[1])]
    // console.log('selectedHour ')
    // console.log(selectedHour)
    if(dateFrom.getTime() === dateTo.getTime()) {
        // console.log('1')
        if (hourFrom[0] === selectedHour[0]) {
            if (selectedHour[1] - hourFrom[1] < 30) {
                // console.log('2')
                alert('Podaj późniejszą godzinę zakończenia!')
            } else {
                // console.log('3')
                setHourTo([...selectedHour])
            }
        } else if (hourFrom[0] > selectedHour[0]) {
            // console.log('4')
            alert('Niepoprawna godzina zakończenia!')
        } else {
            // console.log('5')
            setHourTo([...selectedHour])
        }
    } else {
        // console.log('6')
        setHourTo([...selectedHour])
    }
}

const SetOtherCityLeaveOptionHandler = (value) => {
    setOtherCityLeaveOption(value)
}

const formHandler = async (event) => {
    event.preventDefault();

    if (otherCityLeaveOption && (selectedCityTo === cityDefaultValue 
                            || selectedLocationTo === locationDefaultValue)) {
                                alert('Uzupełnij poprawnie formularz!')
                                return;
                            }

    if (selectedCityFrom !== cityDefaultValue && 
                selectedLocationFrom !== locationDefaultValue)
    {
        const sinceDate = new Date(dateFrom)
        sinceDate.setHours(hourFrom[0])
        sinceDate.setMinutes(hourFrom[1])

        // console.log(sinceDate)

        const toDate = new Date(dateTo)
        toDate.setHours(hourTo[0])
        toDate.setMinutes(hourTo[1])

        // console.log(toDate)

        const cookies = new Cookie()
        cookies.set('selectedCityFrom', `${selectedCityFrom}`, { path: '/' })
        cookies.set('selectedLocationFrom', `${selectedLocationFrom}`, { path: '/' })
        cookies.set('dateTimeFrom', `${sinceDate}`, { path: '/' })
        cookies.set('dateTimeTo', `${toDate}`, { path: '/' })

        if (!otherCityLeaveOption) {
            cookies.set('selectedCityTo', `${selectedCityFrom}`, { path: '/' })
            cookies.set('selectedLocationTo', `${selectedLocationFrom}`, { path: '/' })
        }
        else {
            cookies.set('selectedCityTo', `${selectedCityTo}`, { path: '/' })
            cookies.set('selectedLocationTo', `${selectedLocationTo}`, { path: '/' })
        }

        navigate('/samochody')
    } else 
    {
        alert('Uzupełnij wszystkie pola w formularzu!')
    }
}

const fieldsForOtherCityLeave = 
            <div className={styles.OtherCityLeaveSpace}>
                <label>Końcowa lokalizacja:</label>
                <div className={styles.inputsArea}>
                    <div>
                        <select id='CityLeave'
                                className={styles.fullWidthField}
                                onChange={CityToFormSubmitHandler}>
                            {
                                [`${cityDefaultValue}`, ...cities].map((item, index) => {
                                    return (
                                        <option key={index}
                                                value={item}>
                                            {item}
                                        </option>
                                    )
                                })
                            }
                        </select>
                    </div>
                    <div>
                        <select id='LocationLeave'
                                className={styles.fullWidthField}
                                value={selectedLocationTo}
                                onChange={LocationToFormSubmitHandler}>
                            {
                                [`${locationDefaultValue}`, ...locationsTo].map((item, index) => {
                                    return (
                                        <option key={index}
                                                value={item}>
                                            {item}
                                        </option>
                                    )
                                })
                            }
                        </select>
                    </div>
                </div>
            </div>


  useEffect(() => {
        RemoveSetOfCookies();
        getDefaultTimeFrom();
        getDefaultTimeTo();
        GetCities();
  }, [])

  useEffect(() => {
        if(selectedCityFrom !== `${cityDefaultValue}`) {
            GetLocations(selectedCityFrom, true, false)
        } else {
            setLocationsFrom([])
        }
        setSelectedLocationFrom(`${locationDefaultValue}`)
  }, [selectedCityFrom])

  useEffect(() => {
        if(selectedCityTo !== `${cityDefaultValue}`) {
            GetLocations(selectedCityTo, false, true)
        } else {
            setLocationsTo([])
        }
        setSelectedLocationTo(`${locationDefaultValue}`)
  }, [selectedCityTo])

  useEffect(() => {
        if (!otherCityLeaveOption) {
            setSelectedCityTo(`${cityDefaultValue}`)
            setSelectedLocationTo(`${locationDefaultValue}`)
            setLocationsTo([])
        }
  }, [otherCityLeaveOption])



  return (
    <div className={`${styles.bannerWrapper}`}>
        <div className={styles.bannerContent}>
            <div className={styles.formLabelContainer}>
                <h1 className={styles.formTitle}>SZUKAJ AUTA</h1>
            </div>
            <div className={styles.formContainer}>
                <form onSubmit={formHandler}>
                    <label>Początkowa lokalizacja:</label>
                    <div className={styles.inputsArea}>
                        <div>
                            <select id='CityFrom' 
                                    className={styles.fullWidthField}
                                    onChange={CityFromFormSubmitHandler}>
                                {
                                    [`${cityDefaultValue}`, ...cities].map((item, index) => {
                                        return (
                                            <option key={index}
                                                    value={item}>
                                                {item}
                                            </option>
                                        )
                                    })
                                }
                            </select>
                        </div>
                        <div>
                            <select id='LocationFrom'
                                    className={styles.fullWidthField}
                                    value={selectedLocationFrom}
                                    onChange={LocationFromFormSubmitHandler}>
                                {
                                    [`${locationDefaultValue}`, ...locationsFrom].map((item, index) => {
                                        return (
                                            <option key={index}
                                                    value={item}>
                                                {item}
                                            </option>
                                        )
                                    })
                                }
                            </select>
                        </div>
                    </div>
                    <div className={styles.mobile}>
                        <p className={styles.otherCityLabel}>
                            Chcesz zostawić samochód w innym miejscu?
                        </p>
                        <div id='OtherCityLeaveOption'
                            className={styles.centerOptions}>
                                <span className={otherCityLeaveOption ? 
                                                        styles.spanRadioButton 
                                                                    : 
                                                `${styles.spanRadioButton} ${styles.spanRadioButtonActive}`}
                                    onClick={() => { SetOtherCityLeaveOptionHandler(false) }}>
                                    NIE
                                </span>
                                <span className={!otherCityLeaveOption ? 
                                                        styles.spanRadioButton 
                                                                    : 
                                                `${styles.spanRadioButton} ${styles.spanRadioButtonActive}`}
                                    onClick={() => { SetOtherCityLeaveOptionHandler(true) }}>
                                    TAK
                                </span>
                        </div>
                    </div>
                    {/* Extra fields in form */}
                    { otherCityLeaveOption && fieldsForOtherCityLeave}
                    {/* Extra fields in form */}
                    <div className={styles.timeInputsArea}>
                        <div className={styles.formTimeWrapper}>
                            <label>Od:</label>
                            <div>
                                <input type='date' 
                                        value={dateFrom.toLocaleDateString('en-CA')}
                                        onChange={SetDateFromHandler}>
                                </input>
                                <select value={`${hourFrom}`}
                                        // multiple={true}
                                        onChange={setHourFromHandler}>
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
                        <div className={styles.formTimeWrapper}>
                            <label>Do:</label>
                            <div>
                            <input type='date' 
                                    value={dateTo.toLocaleDateString('en-CA')}
                                    onChange={SetDateToHandler}></input>
                                <select value={`${hourTo}`}
                                        // multiple={true}
                                        onChange={setHourToHandler}>
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
                    </div>
                    <div className={styles.formSubmitButtonSpace}>
                        <button type='submit' className={!otherCityLeaveOption 
                                            ? 
                                           `${styles.formSubmitButton} ${styles.formSubmitButtonMargin}`
                                            :
                                            `${styles.formSubmitButton}`}>
                            SZUKAJ
                        </button>
                    </div>
                </form>
            </div>
        </div>
    </div>
  )
}

export default Banner