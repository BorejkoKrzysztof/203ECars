import React, { useState } from 'react'
import styles from './AvailableCarsPage.module.css'
import { FaFilter, FaWindowClose } from 'react-icons/fa'
import { AiOutlineArrowDown } from 'react-icons/ai'
import { IoLocationSharp, IoTimeSharp } from 'react-icons/io5'
import { BsFillCalendarDateFill } from 'react-icons/bs'

function AvailableCarsPage() {

  const [filterFormState, setFilterFormState] = useState(false)
  const [locationFormState, setLocationFormState] = useState(false)


  return (
    <div className={styles.availableCarsWrapper}>
      <div className={styles.AvailableCarsContent}>
        <div className={styles.filtersWrapper}>
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
              <button onClick={() => { setLocationFormState(true) }}>EDYTUJ</button>
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
                    <button>EDYTUJ</button>
                  </div>
              </form>
          </div>


          <div className={!filterFormState ? 
                            `${styles.otherSettingsFilterContent}` 
                                      : 
                            `${styles.otherSettingsFilterContent} ${styles.otherSettingsFilterContentActive}`}>
            <div className={styles.otherSettingsFilterBar} onClick={() => { setFilterFormState(!filterFormState) }}>
                <div className={styles.filterBarContent}>
                  <FaFilter />
                  <h3>Filtruj</h3>
                </div>
                <AiOutlineArrowDown 
                    className={!filterFormState ? `${styles.filterArrow}` : `${styles.filterArrow} ${styles.filterArrowActive}`}/>
            </div>
            <div className={styles.filterFormWrapper}>
                FILTER FORM
            </div>
          </div>
        </div>
        <div className={styles.contentWrapper}>



          <div className={styles.carItem}>
              CAR ITEM
          </div>
          <div className={styles.carItem}>
              CAR ITEM
          </div>
          <div className={styles.carItem}>
              CAR ITEM
          </div>
          <div className={styles.carItem}>
              CAR ITEM
          </div>

        </div>
      </div>
    </div>
  )
}

export default AvailableCarsPage