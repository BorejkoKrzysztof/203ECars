import React, { useEffect, useState } from 'react'
import axios from '../../../../../Axios/axiosDefault.js'
import styles from './Banner.module.css'
import possibleHours from './hoursToSelect.js'

function Banner() {

const [cities, setCities] = useState([{Label: 'Wybierz miasto', Value: ''}])
const [locations, setLocations] = useState([{Label: 'Wybierz lokacje', Value: ''}])
const [otherCityLeaveOption, setOtherCityLeaveOption] = useState(false)


const [selectedCityFrom, setSelectedCityFrom] = useState()
const [selectedLocationFrom, setSelectedLocationFrom] = useState()

const [selectedCityTo, setSelectedCityTo] = useState()
const [selectedLocationTo, setSelectedLocationTo] = useState()

const GetCities = async () => {
    try {
        const response = await axios.get('/rental/cities');
        setCities(response.data);
    } catch (error) {
        console.log(error)
    }
}

const GetLocations = async (city) => {
    try {
        const response = await axios.get(`rental/locations/${city}`)
        setLocations(response.data)
    } catch (error) {
        console.log(error)
    }
}

const CityFromFormSubmitHandler = (event) => {
    setSelectedCityFrom(event.target.value)
    GetLocations(event.target.value)
}

const LocationFromFormSubmitHandler= (event) => {
    setSelectedLocationFrom(event.target.value)
}

const CityLeaveFormSubmitHandler = (event) => {
    setSelectedCityTo(event.target.value)
    GetLocations(event.target.value)
}

const LocationLeaveFormSubmitHandler = (event) => {
    setSelectedLocationTo(event.target.value)
}


const SetOtherCityLeaveOptionHandler = (value) => {
    setOtherCityLeaveOption(value)
}

const formHandler = async (event) => {
    event.preventDefault();

    // tutaj ustawie ciasteczka
}

const fieldsForOtherCityLeave = 
            <div className={styles.OtherCityLeaveSpace}>
                <label>Końcowa lokalizacja:</label>
                <div className={styles.inputsArea}>
                    <div>
                        <select id='CityLeave'
                                className={styles.fullWidthField}
                                onChange={CityLeaveFormSubmitHandler}>
                            {
                                cities.map((item, index) => {
                                    return (
                                        <option key={index}
                                                value={item.Value}>
                                            {item.Label}
                                        </option>
                                    )
                                })
                            }
                        </select>
                    </div>
                    <div>
                        <select id='LocationLeave'
                                className={styles.fullWidthField}
                                onChange={LocationLeaveFormSubmitHandler}>
                            {
                                locations.map((item, index) => {
                                    return (
                                        <option key={index}
                                                value={item.Value}>
                                            {item.Label}
                                        </option>
                                    )
                                })
                            }
                        </select>
                    </div>
                </div>
            </div>


  useEffect(() => {
    GetCities();

    // tutaj powinienem usunac ciasteczko "mozna isc dalej"
  },[])

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
                                    cities.map((item, index) => {
                                        return (
                                            <option key={index}
                                                    value={item.Value}>
                                                {item.Label}
                                            </option>
                                        )
                                    })
                                }
                            </select>
                        </div>
                        <div>
                            <select id='LocationFrom'
                                    className={styles.fullWidthField}
                                    onChange={LocationFromFormSubmitHandler}>
                                {
                                    locations.map((item, index) => {
                                        return (
                                            <option key={index}
                                                    value={item.Value}>
                                                {item.Label}
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
                    <div className={styles.timeInputsArea}>
                        <div className={styles.formTimeWrapper}>
                            <label>Od:</label>
                            <div>
                                <input type='date' ></input>
                                <select>
                                    {
                                        possibleHours.map((item, index) => {
                                            return (
                                                <option key={index} value={item.value}>
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
                            <input type='date' ></input>
                                <select>
                                    {
                                        possibleHours.map((item, index) => {
                                            return (
                                                <option key={index} value={item.value}>
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