import React from 'react'
import styles from './EasyStepsBar.module.css'
import { FaSearch } from 'react-icons/fa'
import { BsFillHandIndexThumbFill } from 'react-icons/bs'
import { AiFillCar } from 'react-icons/ai'

function EasyStepsBar() {
  return (
    <div className={styles.easyStepsWrapper}>
        <h1 className={styles.title}>Łatwa rejestracja</h1>
        <p className={styles.companyDescription}>
            &nbsp; W 203E Cars staramy się, aby nasi klienci mogli wypożyczyć samochód bez zbytniego 
             wysiłku i formalności. Cenimy Twój czas, dlatego wykonaj tylko kilka kliknięć z dowolnego urządzenia. 
            <span>
                Skorzystaj z naszego formularza na górze strony.
            </span>
        </p>
        <div className={styles.descriptionsItemsSteps}>
            <div className={styles.step}>
                <div>
                    <FaSearch />
                </div>
                <div>
                    <h3>Szukaj</h3>
                    <h5>Wybierz lokalizacje</h5>
                </div>
            </div>
            <div className={styles.step}>
                <div>
                    <BsFillHandIndexThumbFill />
                </div>
                <div>
                    <h3>Wybierz</h3>
                    <h5>Wybierz najlepsze auto</h5>
                </div>
            </div>
            <div className={styles.step}>
                <div>
                    <AiFillCar />
                </div>
                <div>
                    <h3>Rezerwuj</h3>
                    <h5>Zarezerwuj swój samochód</h5>
                </div>
            </div>
        </div>
    </div>
  )
}

export default EasyStepsBar