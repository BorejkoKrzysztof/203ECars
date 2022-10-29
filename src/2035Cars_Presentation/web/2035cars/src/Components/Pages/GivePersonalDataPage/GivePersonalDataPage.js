import React, { useEffect, useState } from 'react'
import styles from './GivePersonalDataPage.module.css'
import Cookies from 'universal-cookie'
import { useNavigate } from 'react-router-dom'
import axios from '../../../Axios/axiosDefault'

function GivePersonalDataPage() {

    let navigateTo = useNavigate()
    const [carId, setCarId] = useState(-1)
    const [carBrand, setCarBrand] = useState('')
    const [carModel, setCarModel] = useState('')
    const [carImage, setCarImage] = useState()
    const [imageIsLoaded, setImageIsLoaded] = useState(false)

    const [firstName, setFirstName] = useState('')
    const [lastName, setLastName] = useState('')
    const [emailAddress, setEmailAddress] = useState('')
    const [phoneNumber, setPhoneNumber] = useState('')

    const Redirection = () => {
        const cookies = new Cookies()
        
        if (cookies.get('SelectedCarUniqueNumber') === undefined ||
            cookies.get('SelectedCarBrand') === undefined ||
            cookies.get('SelectedCarModel') === undefined ||
            cookies.get('SelectedCarRentalPrice') === undefined)
        {
            navigateTo('/')
        }
    }

    const downloadImageforCar = () => {
        axios.get(`car/cars/getcarimage/${carId}`)
                .then(response => {
                    setCarImage(response.data)
                })
                .catch(error => {
                    console.log(error)
                })
    }

    const setCarDateFromCookies = () => {
        const cookies = new Cookies()
        const brand = cookies.get('SelectedCarBrand')
        setCarBrand(brand)
        const model = cookies.get('SelectedCarModel')
        setCarModel(model)
        const id = cookies.get('SelectedCarUniqueNumber')
        setCarId(id)
    }

    const setFirstNameHandler = (event) => {
        setFirstName(event.target.value)
    }

    const setLastNameHandler = (event) => {
        setLastName(event.target.value)
    }

    const setEmailAddressHandler = (event) => {
        setEmailAddress(event.target.value)
    }

    const setPhoneNumberHandler = (event) => {
        setPhoneNumber(event.target.value)
    }

    const formHandler = () => {

        if (firstName.length !== 0 && lastName.length !== 0 && 
                emailAddress.length !== 0 && phoneNumber.length !== 0) {
                const cookies = new Cookies()
                cookies.set('ProvidedFirstName', `${firstName}`, { path: '/' })
                cookies.set('ProvidedLastName', `${lastName}`, { path: '/' })
                cookies.set('ProvidedEmailAddress', `${emailAddress}`, { path: '/' })
                cookies.set('ProvidedPhoneNumber', `${phoneNumber}`, { path: '/' })

                navigateTo('/potwierdzenie')
            } else {
                alert('Uzupełnij wszystkie pola.')
            }
    }

    useEffect(() => {
        Redirection()        
        setCarDateFromCookies()
        setImageIsLoaded(true)
    }, [])

    useEffect(() => {
        if (carId !== -1) {
            downloadImageforCar()
        }
    }, [carId])


  return (
    <div className={styles.personalDataWrapper}>
        <div className={styles.imageMainPart}>
            <h1>Wypożycz</h1>
            <h1>{carBrand} {carModel}</h1>
            {
                imageIsLoaded ?
                <>
                    <img className={styles.carItemImage}
                            src={`data:image/png;base64,${carImage}`}
                            alt={`car`} />
                </>
                :
                <></>
            }
        </div>
        <div className={styles.formPart}>
            <p className={styles.paragraphTitle}>Podaj wymagane dane:</p>
            <div className={styles.formPersonalData}>
                <div className={styles.personalDataArea}>
                    <label>Imie:</label>
                    <input type='text' onChange={setFirstNameHandler}></input>
                </div>
                <div className={styles.personalDataArea}>
                    <label>Nazwisko:</label>
                    <input type='text' onChange={setLastNameHandler}></input>
                </div>
                <div className={styles.personalDataArea}>
                    <label>Adress Email:</label>
                    <input type='text' onChange={setEmailAddressHandler}></input>
                </div>
                <div className={styles.personalDataArea}>
                    <label>Numer telefonu:</label>
                    <input type='text' onChange={setPhoneNumberHandler}></input>
                </div>
                <div className={styles.buttonWrapper}>
                    <button onClick={formHandler} className={styles.formSubmitButton}>
                        Dalej
                    </button>
                </div>
            </div>
        </div>
    </div>
  )
}

export default GivePersonalDataPage