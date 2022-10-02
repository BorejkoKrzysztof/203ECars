import React, { useState } from 'react'
import styles from './TimeAndLocationsFilter.module.css'
import { IoLocationSharp, IoTimeSharp } from 'react-icons/io5'
import { BsFillCalendarDateFill } from 'react-icons/bs'
import { FaWindowClose } from 'react-icons/fa'


function TimeAndLocationsFilter() {

const [locationFormState, setLocationFormState] = useState(false)


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
                Miasto Miasto Lokacja
            </h6>
            <p>
                <BsFillCalendarDateFill className={styles.locationInfoIcons}/>
                    12.08.2022 &nbsp;
                <IoTimeSharp className={styles.locationInfoIcons}/>
                    10:00
            </p>
        </div>
        <hr className={styles.locationInfoSeparateLine}/>
        <div className={styles.locationInfo}>
            <h2>
                KONIEC :
            </h2>
            <h6>
                <IoLocationSharp className={styles.locationInfoIcons}/>
                Miasto Miasto Lokacja
            </h6>
            <p>
                <BsFillCalendarDateFill className={styles.locationInfoIcons}/>
                12.08.2022 &nbsp;
                <IoTimeSharp className={styles.locationInfoIcons}/>
                10:00
            </p>
        </div>
        <div className={styles.locationFormOpenButtonWrapper}>
            <button className={styles.themeButton} 
                onClick={() => { setLocationFormState(true) }}>
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
                <select></select>
            </div>
            <div className={styles.locationInfoForm}>
                <label>KONIEC :</label>
                <select></select>
            </div>
            <div className={styles.locationInfoForm}>
                <label>DATA ROZPOCZĘCIA :</label>
                <div>
                    <input type='date'></input>
                    <select></select>
                </div>
            </div>
            <div className={styles.locationInfoForm}>
                <label>DATA ZAKOŃCZENIA :</label>
                <div>
                    <input type='date'></input>
                    <select></select>
                </div>
            </div>
            <div className={styles.submitButtonWrapper}>
                <button className={styles.submitButton}>EDYTUJ</button>
            </div>
        </form>
    </div>
</>
  )
}

export default TimeAndLocationsFilter