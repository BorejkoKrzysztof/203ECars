import React from 'react'
import styles from './CarItem.module.css'
import { GiCarSeat, GiCarDoor, GiHotSurface } from 'react-icons/gi'
import { RiTempColdFill, RiNavigationFill } from 'react-icons/ri'
import { TbManualGearbox } from 'react-icons/tb'

function CarItem(props) {

    const carImage = props.image

    const rentButtonHandler = () => {

    }


  return (
    <>
        <div className={styles.carItem}>
            <div className={styles.carItemTitle}>
                {/* <h1>Marka Model</h1> */}
                <h1>{props.Brand} {props.Model}</h1>
            </div>
            <div className={styles.carItemMiddle}>
                <div className={styles.mainPart}>
                    {/* <img className={styles.carItemImage}
                        src={process.env.PUBLIC_URL + '/Images/ExampleCars/Jaguar I Pace.png'}
                        alt={`car`} /> */}


                    <img className={styles.carItemImage}
                        src={`carImage:image/jpeg;base64,${carImage}`}
                        alt={`car`} />
                </div>
                <div className={styles.carItemDescription}>
                    <p>
                        <span>
                            <GiCarSeat />
                        </span>
                        {props.AmountOfSeats} - ilość siedzeń
                    </p>
                    <p>
                        <span>
                            <GiCarDoor />
                        </span>
                        {props.AmountOfDoor} - ilość drzwi
                    </p>
                    {
                        props.HasAirCooling === true ?
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
                        props.HasAutomaticGearBox === true ?
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
                        props.HasHeatingSeats === true ?
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
                        props.HasBuildInNavigation === true ?
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
                            props.hoursForRental === 1 ?
                            <>
                                <p>
                                    Za 1 godzinę:
                                </p>
                            </>
                            :
                            <>
                                <p>
                                Za {props.hoursForRental} godzin
                            </p>
                            </>
                        }
                        <h3>
                            {props.PriceForRental} PLN
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