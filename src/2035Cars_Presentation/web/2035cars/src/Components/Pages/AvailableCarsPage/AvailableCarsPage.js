import React, { useState } from 'react'
import styles from './AvailableCarsPage.module.css'
import { FaFilter } from 'react-icons/fa'
import { AiOutlineArrowDown } from 'react-icons/ai'

function AvailableCarsPage() {

  const [formState, setFormState] = useState(false)


  return (
    <div className={styles.availableCarsWrapper}>
      <div className={styles.AvailableCarsContent}>
        <div className={styles.filtersWrapper}>
          <div className={styles.locationsFilterContent}>
            <div className={styles.locationInfo}>

            </div>
            <div className={styles.locationInfo}>

            </div>
            <div className={styles.locationFormOpenButtonWrapper}>
              <button>Open</button>
            </div>
          </div>
          <div className={!formState ? 
                            `${styles.otherSettingsFilterContent}` 
                                      : 
                            `${styles.otherSettingsFilterContent} ${styles.otherSettingsFilterContentActive}`}>
            <div className={styles.otherSettingsFilterBar} onClick={() => { setFormState(!formState) }}>
                <div className={styles.filterBarContent}>
                  <FaFilter />
                  <h3>Filtruj</h3>
                </div>
                <AiOutlineArrowDown 
                    className={!formState ? `${styles.filterArrow}` : `${styles.filterArrow} ${styles.filterArrowActive}`}/>
            </div>
            <div className={styles.filterFormWrapper}>

            </div>
          </div>
        </div>
        <div className={styles.contentWrapper}>



          <div className={styles.carItem}>

          </div>
          <div className={styles.carItem}>

          </div>
          <div className={styles.carItem}>

          </div>
          <div className={styles.carItem}>

          </div>

        </div>
      </div>
    </div>
  )
}

export default AvailableCarsPage