import React from 'react'
import styles from './LackOfCars.module.css'
import { IoSadOutline } from 'react-icons/io5'

function LackOfCars() {
  return (
    <div className={styles.lackOfCarsWrapper}>
        <div className={styles.lackOfCarsContent}>
            <div className={styles.lackTitle}>
                <h1>Brak dostępnych aut!</h1>
            </div>
            <div className={styles.lackParagraph}>
                <p>Przykro nam, ale niestety nie możemy zaoferować Ci odpowiedniego samochodu w tym terminie.
                    Zmień datę rozpoczęcia i/lub końca wynajmu, albo zmień wymagane opcje pojazdu.
                </p>
            </div>
            <div className={styles.sadIcon}>
                <p className={styles.lackIcon}>
                    <IoSadOutline />
                </p>
            </div>
        </div>
    </div>
  )
}

export default LackOfCars