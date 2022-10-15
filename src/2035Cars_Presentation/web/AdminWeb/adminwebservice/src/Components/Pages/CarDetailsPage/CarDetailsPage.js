import React from 'react'
import styles from './CarDetailsPage.module.css'

function CarDetailsPage() {
  return (
    <div className={styles.wrapper}>
        <div className={styles.cardContent}>
            <div className={styles.carImageWrapper}>
            <img
                alt="car"
                src="https://picsum.photos/300/200"
            />
            </div>
            <div className={styles.carDescription}>
                <h1>Marka Model</h1>
                <h3>CarType</h3>
                <h3>Klimatyzacja</h3>
                <h3>Podgrz. siedzenia</h3>
                <h3>Autom. skrz. biegów</h3>
                <h3>Wbudowana navigacja</h3>
                <h3>Napęd DriveType</h3>
                <h3>AmountOfDoor</h3>
                <h3>Ilość siedzeń</h3>
                <h3>Cena za godz.</h3>
                <h3>Wynajęty/Wolny</h3>
                <h3>Wynajęty do</h3>
            </div>
            <div className={styles.buttonsArea}>
                <a className={`btn btn-primary ${styles.buttonColor} ${styles.buttonLink}`}
                    href="#">
                    Edytuj
                </a>
                <a className={`btn btn-danger ${styles.buttonLink}`}
                    href="#">
                    Usuń
                </a>
            </div>
        </div>
        <div className={styles.backButtonArea}>
            <a className={`btn btn-outline-primary ${styles.backButton}`} style={{ marginBottom: "30px" }}>
                Powrót do listy pracowników
            </a>
        </div>
    </div>
  )
}

export default CarDetailsPage