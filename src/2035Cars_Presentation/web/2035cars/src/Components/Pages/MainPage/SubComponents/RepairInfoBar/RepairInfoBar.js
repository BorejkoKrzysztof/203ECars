import React from 'react'
import styles from './RepairInfoBar.module.css'
import { GiAutoRepair } from 'react-icons/gi'

function RepairInfoBar() {
  return (
    <div className={styles.repairInfoWrapper}>
        <div className={styles.repairBigIcon}>
            <GiAutoRepair />
        </div>
        <div className={styles.repairDescription}>
            <h1 className={styles.repairTitle}>
                We will Repair your car if it breaks down during your trip!
            </h1>
            <p className={styles.repairParagraph}>
                203E Car has rentals in most cities so if your car breaks down during your trip, 
                our mechanic will come to you and try to repair the car on the spot. 
                If a quick repair is not possible you will get a replacement car.
            </p>
        </div>
    </div>
  )
}

export default RepairInfoBar