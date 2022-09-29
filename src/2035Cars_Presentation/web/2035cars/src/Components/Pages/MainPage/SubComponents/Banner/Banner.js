import React, { useEffect, useState } from 'react'
import styles from './Banner.module.css'
import possibleHours from './hoursToSelect.js'

function Banner() {

const [countries, setCountries] = useState([{Label: 'Select Country', Value: ''}])
const [cities, setCities] = useState([{Label: 'Select City', Value: ''}])
const [otherCityLeaveOption, setOtherCityLeaveOption] = useState(false)

const CountryFormSubmitHandler = () => {

}

const CityFormSubmitHandler= () => {
    
}

const CountryLeaveFormSubmitHandler = () => {

}

const CityLeaveFormSubmitHandler = () => {

}

const SetOtherCityLeaveOptionHandler = (value) => {
    setOtherCityLeaveOption(value)
}

const fieldsForOtherCityLeave = 
            <div className={styles.OtherCityLeaveSpace}>
                <label>Końcowa lokalizacja:</label>
                <div className={styles.inputsArea}>
                    <div>
                        <select id='CountryLeave'
                                className={styles.fullWidthField}
                                onChange={CountryLeaveFormSubmitHandler}>
                            {
                                countries.map((item, index) => {
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
                </div>
            </div>

  return (
    <div className={`${styles.bannerWrapper}`}>
        <div className={styles.bannerContent}>
            <div className={styles.formLabelContainer}>
                <h1 className={styles.formTitle}>SZUKAJ AUTA</h1>
            </div>
            <div className={styles.formContainer}>
                <form>
                    <label>Początkowa lokalizacja:</label>
                    <div className={styles.inputsArea}>
                        <div>
                            <select id='Country' 
                                    className={styles.fullWidthField}
                                    onChange={CountryFormSubmitHandler}>
                                {
                                    countries.map((item, index) => {
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
                            <select id='City'
                                    className={styles.fullWidthField}
                                    onChange={CityFormSubmitHandler}>
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
                            <label>OD:</label>
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
                            <label>DO:</label>
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
                        <button className={!otherCityLeaveOption 
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