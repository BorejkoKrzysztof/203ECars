import React, { useState } from 'react'
import styles from './AvailableCarsPage.module.css'
import { FaFilter, FaWindowClose } from 'react-icons/fa'
import { AiOutlineArrowDown } from 'react-icons/ai'

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
            <div className={styles.locationInfo}>
              DROP ON
            </div>
            <div className={styles.locationInfo}>
              DROP OFF
            </div>
            <div className={styles.locationFormOpenButtonWrapper}>
              <button onClick={() => { setLocationFormState(true) }}>Open</button>
            </div>
          </div>
          

          <div className={!locationFormState ? 
                              `${styles.locationFormWrapper}`
                                              :
                              `${styles.locationFormWrapper} ${styles.locationFormWrapperActive}`}>
              <div className={styles.closeLoactionFormButtonArea}>
                <button className={styles.closeLocationFormButton}
                          onClick={() => { setLocationFormState(false) }}>
                  <FaWindowClose />
                </button>
              </div>
              LOCATION FORM
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