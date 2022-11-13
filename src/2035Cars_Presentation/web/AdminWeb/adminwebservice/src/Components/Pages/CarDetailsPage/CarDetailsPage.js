import React, {
    useEffect,
    useState
} from 'react'
import styles from './CarDetailsPage.module.css'
import axios from '../../../axios/axiosAuthorize'

function CarDetailsPage() {

    const [carInfo, setCarInfo] = useState({})
    const [isCarLoaded, setIsCarLoaded] = useState(false)

    const downloadCarInfo = () => {
        const carId = sessionStorage.getItem('carId')
        axios.get(`/car/getcarinfo/${carId}`)
            .then((response) => {
                setCarInfo(response.data)
                setIsCarLoaded(true)
            })
            .catch((error) => {
                console.log(error)
            })
    }

    const removeCarHandler = (carId) => {
        if(window.confirm('Ta akcja spowoduje usunięcie samochodu') == true) {
            axios.delete(`car/removecar/${carId}`)
                .then(() => {
                    window.location.href = '/samochody'
                })
                .catch( (error) => {
                    console.log(error)
                })
        }
    }

    useEffect(() => {
        document.title = 'Szczegóły samochodu'
        downloadCarInfo()
    }, [])

    // Component Did Unmount
    useEffect(() => {
        return () => {
            sessionStorage.removeItem('carId')
        }
    }, [])

    const printCarType = () => {
        const carTypeInfo = carInfo.carType

        switch (carTypeInfo) {
            case 0:
                return 'Suv'
            case 1:
                return 'Sportowy'
            case 2:
                return 'Kabriolet'
            case 3:
                return 'Sedan'
            case 4:
                return 'Kompakt'
            default:
                break;
        }
    }

    const printDriveType = () => {
        const driveType = carInfo.driveType

        switch (driveType) {
            case 0:
                return 'Hybrydowy'
            case 1:
                return 'Elektryczny'
            default:
                break;
        }
    }

    return (
    <div className={styles.wrapper}>
        {isCarLoaded ?
        <>
            <div className={styles.cardContent}>
                <div className={styles.carImageWrapper}>
                <img style={{ padding: '25px' }}
                    alt="car"
                    src={`data:image/png;base64,${carInfo.image}`}
                />
                </div>
                <div className={styles.carDescription}>
                    <h1>{carInfo.brand} {carInfo.model}</h1>
                    <h3>Typ nadwozia: {printCarType()}</h3>
                    <h3>Klimatyzacja: {carInfo.hasAirCooling ? 'TAK' : 'NIE'}</h3>
                    <h3>Podgrz. siedzenia: {carInfo.hasHeatingSeats ? 'TAK' : 'NIE'}</h3>
                    <h3>Autom. skrz. biegów: {carInfo.hasAutomaticGearBox ? 'TAK' : 'NIE'}</h3>
                    <h3>Wbudowana navigacja: {carInfo.hasBuildInNavigation ? 'TAK' : 'NIE'}</h3>
                    <h3>Napęd: {printDriveType()}</h3>
                    <h3>Ilość drzwi: {carInfo.amountOfDoor}</h3>
                    <h3>Ilość siedzeń: {carInfo.amountOfSeats}</h3>
                    <h3>Cena za godz.: {carInfo.priceForRental} PLN</h3>
                    <h3 style={{ color: 'red' }}>{carInfo.isRented? 'Wynajęty' : 'Wolny'}</h3>
                </div>
                <div className={styles.buttonsArea}>
                    <a className={`btn btn-primary ${styles.buttonColor} ${styles.buttonLink}`}
                        onClick={() => {
                            sessionStorage.setItem('CarToEditId', `${carInfo.carUniqueReferrence}`)
                            window.location.href = 'edytujsamochod'
                        }}>
                        Edytuj
                    </a>
                    <a className={`btn btn-danger ${styles.buttonLink}`}
                        onClick={() => { removeCarHandler(carInfo.carUniqueReferrence) }} >
                        Usuń
                    </a>
                </div>
            </div>
            <div className={styles.backButtonArea}>
                <a className={`btn btn-outline-primary ${styles.backButton}`} 
                    style={{ marginBottom: "30px" }}
                    onClick={() => {
                        sessionStorage.removeItem('carId')
                        window.location.href = '/samochody'
                    }}>
                    Powrót do listy samochodów
                </a>
            </div>
        </> 
        :
        <></>}   
    </div>
    )
}

export default CarDetailsPage