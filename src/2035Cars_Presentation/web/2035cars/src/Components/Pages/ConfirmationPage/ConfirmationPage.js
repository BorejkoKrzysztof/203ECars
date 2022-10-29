import React, { useEffect, useState } from 'react'
import styles from './ConfirmationPage.module.css'
import axios from '../../../Axios/axiosDefault'
import { useNavigate } from 'react-router-dom'
import Cookies from 'universal-cookie'

function ConfirmationPage() {

  let navigateTo = useNavigate()
  const [carId, setCarId] = useState(-1)
  const [carBrand, setCarBrand] = useState('')
  const [carModel, setCarModel] = useState('')
  const [carImage, setCarImage] = useState()
  const [imageIsLoaded, setImageIsLoaded] = useState(false)
  const [dateTimeFrom, setDateTimeFrom] = useState(new Date())
  const [dateTimeTo, setDateTimeTo] = useState(new Date())
  const [cityFrom, setCityFrom] = useState('')
  const [locationFrom, setLocationsFrom] = useState('')
  const [cityTo, setCityTo] = useState('')
  const [locationTo, setLocationTo] = useState('')
  const [price, setPrice] = useState(0)

  const [firstName, setFirstName] = useState('')
  const [lastName, setLastName] = useState('')
  const [emailAddress, setEmailAddress] = useState('')
  const [phoneNumber, setPhoneNumber] = useState('')

  const Redirection = () => {
    const cookies = new Cookies()
    
    if (cookies.get('SelectedCarUniqueNumber') === undefined ||
        cookies.get('SelectedCarBrand') === undefined ||
        cookies.get('SelectedCarModel') === undefined ||
        cookies.get('SelectedCarRentalPrice') === undefined ||
        cookies.get('ProvidedFirstName') === undefined ||
        cookies.get('ProvidedLastName') === undefined ||
        cookies.get('ProvidedEmailAddress') === undefined ||
        cookies.get('ProvidedPhoneNumber') === undefined ||
        cookies.get('dateTimeFrom' === undefined) ||
        cookies.get('dateTimeTo') === undefined || 
        cookies.get('selectedCityFrom') === undefined ||
        cookies.get('selectedLocationFrom') === undefined ||
        cookies.get('selectedCityTo') === undefined ||
        cookies.get('selectedLocationTo') === undefined ||
        cookies.get('SelectedCarRentalPrice') == undefined) 
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
      const firstName = cookies.get('ProvidedFirstName')
      setFirstName(firstName)
      const lastName = cookies.get('ProvidedLastName')
      setLastName(lastName)
      const emailAddress = cookies.get('ProvidedEmailAddress')
      setEmailAddress(emailAddress)
      const phoneNumber = cookies.get('ProvidedPhoneNumber')
      setPhoneNumber(phoneNumber)
      const dateTimestart = cookies.get('dateTimeFrom')
      setDateTimeFrom(new Date(dateTimestart))
      const dateTimeEnd = cookies.get('dateTimeTo')
      setDateTimeTo(new Date(dateTimeEnd))
      const cityStart = cookies.get('selectedCityFrom')
      setCityFrom(cityStart)
      const locationStart = cookies.get('selectedLocationFrom')
      setLocationsFrom(locationStart)
      const cityEnd = cookies.get('selectedCityTo')
      setCityTo(cityEnd)
      const locationEnd = cookies.get('selectedLocationTo')
      setLocationTo(locationEnd)
      const price = cookies.get('SelectedCarRentalPrice')
      setPrice(price)
  }

  const removeCookiesAfterResign = () => {
    const cookies = new Cookies()
    cookies.remove('SelectedCarBrand')
    cookies.remove('SelectedCarModel')
    cookies.remove('SelectedCarUniqueNumber')
    cookies.remove('ProvidedFirstName')
    cookies.remove('ProvidedLastName')
    cookies.remove('ProvidedEmailAddress')
    cookies.remove('ProvidedPhoneNumber')
    cookies.remove('SelectedCarRentalPrice')
  }

  const formHandler = () => {
      axios.post('order/performOrder', JSON.stringify({
        CarId: carId,
        FromRentalCity: cityFrom,
        FromRentalLocation: locationFrom,
        ToRentalCity: cityTo,
        ToRentalLocation: locationTo,
        RentFromDate: dateTimeFrom,
        RentToDate: dateTimeTo,
        OrderPrice: price,
        CustomerFirstName: firstName,
        CustomerLastName: lastName,
        CustomerEmail: emailAddress,
        CustomerPhoneNumber: phoneNumber
      })).then(() => {
          alert('Dziękujemy za rezerwację. Zespół 203ECars życzy szerokiej drogi!')
          navigateTo('/')
      }).catch(error => {
          console.log(error)
      })
  }

  const resetFormHandler = () => {
    removeCookiesAfterResign()
    navigateTo('/samochody')
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
    <div className={styles.confirmationWrapper}>
        <h1 className={styles.confirmationTitle}>Potwierdź zamówienie</h1>
        <div className={styles.imageContent}>
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
        <div className={styles.confirmationInfoContent}>
            <h2>{`${carBrand} ${carModel}`}</h2>
            <h2>{`Od ${dateTimeFrom.toLocaleDateString('pl-PL')}`}</h2>
            <h2>{`Z ${cityFrom} ${locationFrom}`}</h2>
            <h2>{`Do ${dateTimeTo.toLocaleDateString('pl-PL')}`}</h2>
            <h2>{`Do ${cityTo} ${locationTo}`}</h2>
            <h2>{`Cena ${price} PLN`}</h2>
            <h2>{`${firstName} ${lastName}`}</h2>
            <h2>{`${emailAddress}`}</h2>
            <h2>{`Telefon: ${phoneNumber}`}</h2>
        </div>
        <div className={styles.buttonsContent}>
            <button className={styles.confirmationButtonResign}
                    onClick={resetFormHandler}>
                Zrezygnuj
            </button>
            <button className={styles.confirmationButtonAccept}
                    onClick={formHandler}>
                Rezerwuj
            </button>
        </div>
    </div>
  )
}

export default ConfirmationPage