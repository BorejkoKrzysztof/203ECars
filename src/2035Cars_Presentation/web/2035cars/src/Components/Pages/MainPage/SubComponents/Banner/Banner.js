import React, { useEffect, useState } from 'react'
import styles from './Banner.module.css'
import possibleHours from './hoursToSelect.js'

function Banner() {

const [countries, setCountries] = useState([{Label: 'Select Country', Value: ''}])
const [cities, setCities] = useState([{Label: 'Select City', Value: ''}])
const [otherCityLeaveOption, setOtherCityLeaveOption] = useState(false)
const [sliderState, setSliderState] = useState(1)

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

const AutoChangeSliderStateHandler = () => {
    if (sliderState === 5)
    {
        setSliderState(1)
        return
    }

    var value = sliderState + 1
    setSliderState(value)
}

useEffect(() => {
    const timer = setTimeout(AutoChangeSliderStateHandler, 180000);
    
    return () => clearTimeout(timer)
}, [sliderState])


const fieldsForOtherCityLeave = 
            <div className={styles.OtherCityLeaveSpace}>
                <label>Drop-off location:</label>
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
    <div className={`${styles.bannerWrapper} ${styles[`bannerWrapperBgc${sliderState}`]}`}>
        <div className={styles.bannerContent}>
            <div className={styles.formLabelContainer}>
                <h1 className={styles.formTitle}>Search your car</h1>
            </div>
            <div className={styles.formContainer}>
                <form>
                    <label>Pick-up location:</label>
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
                            Do you want to leave a car in another place?
                        </p>
                        <div id='OtherCityLeaveOption'
                            className={styles.centerOptions}>
                                <span className={otherCityLeaveOption ? 
                                                        styles.spanRadioButton 
                                                                    : 
                                                `${styles.spanRadioButton} ${styles.spanRadioButtonActive}`}
                                    onClick={() => { SetOtherCityLeaveOptionHandler(false) }}>
                                    NO
                                </span>
                                <span className={!otherCityLeaveOption ? 
                                                        styles.spanRadioButton 
                                                                    : 
                                                `${styles.spanRadioButton} ${styles.spanRadioButtonActive}`}
                                    onClick={() => { SetOtherCityLeaveOptionHandler(true) }}>
                                    YES
                                </span>
                        </div>
                    </div>
                    {/* Extra fields in form */}
                    { otherCityLeaveOption && fieldsForOtherCityLeave}
                    <div className={styles.timeInputsArea}>
                        <div className={styles.formTimeWrapper}>
                            <label>FROM:</label>
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
                            <label>TO:</label>
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
                            SEARCH CAR
                        </button>
                    </div>
                </form>
            </div>
        </div>
        <div className={styles.radioButtonsSliderContainer}>
            <input type='radio' 
                            name='sliderClick' 
                            onChange={() => { setSliderState(1) }} 
                            checked={sliderState == 1}/>
            <input type='radio' 
                            name='sliderClick' 
                            onChange={() => { setSliderState(2) }} 
                            checked={sliderState === 2}/>
            <input type='radio' 
                            name='sliderClick' 
                            onChange={() => { setSliderState(3) }} 
                            checked={sliderState === 3}/>
            <input type='radio' 
                            name='sliderClick' 
                            onChange={() => { setSliderState(4) }} 
                            checked={sliderState === 4}/>
            <input type='radio' 
                            name='sliderClick' 
                            onChange={() => { setSliderState(5) }} 
                            checked={sliderState === 5}/>
        </div>
    </div>
  )
}

export default Banner