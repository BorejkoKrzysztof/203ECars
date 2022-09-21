import React from 'react'
import styles from './CarItem.module.css'
import { GiCarSeat, GiCarDoor, GiHotSurface } from 'react-icons/gi'
import { RiTempColdFill, RiNavigationFill } from 'react-icons/ri'
import { TbManualGearbox } from 'react-icons/tb'

function CarItem() {
  return (
    <>
        <div className={styles.carItem}>
            <div className={styles.carItemTitle}>
                <h1>Marka Model</h1>
            </div>
            <div className={styles.carItemMiddle}>
                <div className={styles.mainPart}>
                    <img className={styles.carItemImage}
                        src={process.env.PUBLIC_URL + '/Images/ExampleCars/Jaguar I Pace.png'}
                        alt={`car`} />
                </div>
                <div className={styles.carItemDescription}>
                    <p>
                        <span>
                            <GiCarSeat />
                        </span>
                        {`5`} ilość siedzeń
                    </p>
                    <p>
                        <span>
                            <GiCarDoor />
                        </span>
                        {`5`} ilość drzwi
                    </p>
                    <p>
                        <span>
                            <RiTempColdFill />
                        </span>
                        Automatyczna klimatyzacja
                    </p>
                    <p>
                        <span>
                            <TbManualGearbox />
                        </span>
                        Automatyczna skrzynia biegów
                    </p>
                    <p>
                        <span>
                            <GiHotSurface />
                        </span>
                        Podgrzewane fotele
                    </p>
                    <p>
                        <span>
                            <RiNavigationFill />
                        </span>
                        Wbudowana nawigacja
                    </p>
                </div>
            </div>
            <div className={styles.bottomSectionCarItem}>
                <div className={styles.priceArea}>
                        <p>
                            Za {`3`} dni:
                        </p>
                        <h3>
                            250.00 PLN
                        </h3>
                </div>
                <div className={styles.rentCarButtonArea}>
                    <button className={styles.rentCarButton}>Wypożycz</button>
                </div>
            </div>
        </div>
    </>
  )
}

export default CarItem