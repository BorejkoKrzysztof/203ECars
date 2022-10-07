import React from 'react'
import styles from './GivePersonalDataPage.module.css'

function GivePersonalDataPage() {
  return (
    <div className={styles.personalDataWrapper}>
        <div className={styles.imageMainPart}>
            <h1>Wypożycz</h1>
            <h1>Marka Model</h1>
            <img className={styles.carItemImage}
                            src={process.env.PUBLIC_URL + '/Images/ExampleCars/Jaguar I Pace.png'}
                            alt={`car`} />
        </div>
        <div className={styles.formPart}>
            <p className={styles.paragraphTitle}>Podaj wymagane dane:</p>
            <form className={styles.formPersonalData}>
                <div className={styles.personalDataArea}>
                    <label>Imie:</label>
                    <input />
                </div>
                <div className={styles.personalDataArea}>
                    <label>Nazwisko:</label>
                    <input />
                </div>
                <div className={styles.personalDataArea}>
                    <label>Adress Email:</label>
                    <input />
                </div>
                <div className={styles.personalDataArea}>
                    <label>Numer telefonu:</label>
                    <input />
                </div>
                <div className={styles.buttonWrapper}>
                    <button type='submit' className={styles.formSubmitButton}>
                        Dalej
                    </button>
                </div>
            </form>
        </div>
    </div>
  )
}

export default GivePersonalDataPage