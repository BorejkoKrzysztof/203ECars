import React from 'react'
import styles from './ConfirmationPage.module.css'

function ConfirmationPage() {
  return (
    <div className={styles.confirmationWrapper}>
        <h1 className={styles.confirmationTitle}>Potwierdź zamówienie</h1>
        <div className={styles.imageContent}>
            <img className={styles.carItemImage}
                                src={process.env.PUBLIC_URL + '/Images/ExampleCars/Jaguar I Pace.png'}
                                alt={`car`} />
        </div>
        <div className={styles.confirmationInfoContent}>
            <h2>Marka Model</h2>
            <h2>Od 21.12.22 12:20</h2>
            <h2>Z miasto lokacja</h2>
            <h2>Do 21.12.22 13:30</h2>
            <h2>Do miasto lokacja</h2>
            <h2>Cena 250 PLN</h2>
            <h2>Imie Nazwisko</h2>
            <h2>AdresEmail</h2>
            <h2>Telefon: 111111111</h2>
        </div>
        <div className={styles.buttonsContent}>
            <button className={styles.confirmationButtonResign}>Zrezygnuj</button>
            <button className={styles.confirmationButtonAccept}>Rezerwuj</button>
        </div>
    </div>
  )
}

export default ConfirmationPage