import React, { useEffect } from 'react'
import styles from './CarItem.module.css'
import { GiCarSeat, GiCarDoor, GiHotSurface } from 'react-icons/gi'
import { RiTempColdFill, RiNavigationFill } from 'react-icons/ri'
import { TbManualGearbox } from 'react-icons/tb'

function CarItem(props) {

    const carImage = props.car.image

    const rentButtonHandler = () => {

    }

  return (
    <>
        <div className={styles.carItem}>
            <div className={styles.carItemTitle}>
                {/* <h1>Marka Model</h1> */}
                <h1>{props.car.brand} {props.car.model}</h1>
            </div>
            <div className={styles.carItemMiddle}>
                <div className={styles.mainPart}>
                    {/* <img className={styles.carItemImage}
                        src={process.env.PUBLIC_URL + '/Images/ExampleCars/Jaguar I Pace.png'}
                        alt={`car`} /> */}


                    <img className={styles.carItemImage}
                        src={`data:image/png;base64,${carImage}`}
                        alt={`car`} />
                </div>
                <div className={styles.carItemDescription}>
                    <p>
                        <span>
                            <GiCarSeat />
                        </span>
                        {props.car.amountOfSeats} - ilość siedzeń
                    </p>
                    <p>
                        <span>
                            <GiCarDoor />
                        </span>
                        {props.car.amountOfDoor} - ilość drzwi
                    </p>
                    {
                        props.car.hasAirCooling === true ?
                        <>
                            <p>
                                <span>
                                    <RiTempColdFill />
                                </span>
                                Automatyczna klimatyzacja
                            </p>
                        </>
                        :
                        <></>
                    }
                    {
                        props.car.hasAutomaticGearBox === true ?
                        <>
                            <p>
                                <span>
                                    <TbManualGearbox />
                                </span>
                                Automatyczna skrzynia biegów
                            </p>
                        </>
                        :
                        <></>
                    }
                    {
                        props.car.hasHeatingSeats === true ?
                        <>
                            <p>
                                <span>
                                    <GiHotSurface />
                                </span>
                                Podgrzewane fotele
                            </p>
                        </>
                        :
                        <></>
                    }
                    {
                        props.car.hasBuildInNavigation === true ?
                        <>
                            <p>
                                <span>
                                    <RiNavigationFill />
                                </span>
                                Wbudowana nawigacja
                            </p>
                        </>
                        :
                        <></>
                    }
                </div>
            </div>
            <div className={styles.bottomSectionCarItem}>
                <div className={styles.priceArea}>
                        {
                            props.hours === 1 ?
                            <>
                                <p>
                                    Za 1 godzinę:
                                </p>
                            </>
                            :
                            <>
                                <p>
                                Za {props.hours} godzin
                            </p>
                            </>
                        }
                        <h3>
                            {
                                Number.isInteger(props.car.priceForRental) ?
                                    `${props.car.priceForRental}.00`
                                    :
                                    `${props.car.priceForRental.toFixed(2)}`
                            } PLN
                        </h3>
                </div>
                <div className={styles.rentCarButtonArea}>
                    <button className={styles.rentCarButton}
                        onClick={rentButtonHandler}>Wypożycz</button>
                </div>
            </div>
        </div>
    </>
  )
}

export default CarItem