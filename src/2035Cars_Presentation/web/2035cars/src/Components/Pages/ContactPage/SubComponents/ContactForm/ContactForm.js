import React, { useEffect, useState } from 'react'
import styles from './ContactForm.module.css'
import { useNavigate } from 'react-router-dom'
import axios from '../../../../../Axios/axiosDefault.js'

function ContactForm() {

    let navigate = useNavigate()

    const firstNameLastNameREGEX = new RegExp("^([a-zA-Z]{2,}\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\s?([a-zA-Z]{1,})?)")
    const emailAdressREGEX = /^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i
    const phoneNumberREGEX = new RegExp("^\\d{9}$")
    const reservationNumberREGEX = new RegExp('^[0-9a-f]{8}-[0-9a-f]{4}-[1-5][0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$', 'i');

    const [firstNameLastName, setFirstNameLastName] = useState('')
    const [firstNameLastNameValid, setFistNameLastNameValid] = useState(false)

    const [emailAddress, setEmailAddress] = useState('')
    const [emailAddressValid, setEmailAddressValid] = useState(false)

    const [phoneNumber, setPhoneNumber] = useState('')
    const [phoneNumberValid, setPhoneNumberValid] = useState(false)

    const [reservationNumber, setReservationNumber] = useState('')
    const [reservationNumberValid, setReservationNumberValid] = useState(false)

    const [message, setMessage] = useState('')
    const [messageValid, setMessageValid] = useState(false)

    const [errorState, setErrorState] = useState(false)

    const errorArea = <div className={styles.errorAreaWrapper}>
                            <ul className={styles.errorsList}>
                                {!firstNameLastNameValid && <li>Niepoprawne imię i nazwisko</li>}
                                {!emailAddressValid && <li>Niepoprawny adres email</li>}
                                {!phoneNumberValid && <li>Niepoprawny numer telefonu</li>}
                                {!reservationNumberValid && <li>Niepoprawny numer rezerwacji</li>}
                                {!messageValid && <li>Wiadomość jest pusta</li>}
                            </ul>
                      </div>

    const contactFormHandler = () => {
        if (firstNameLastNameValid && 
            emailAddressValid && 
            phoneNumberValid && 
            reservationNumberValid &&
            messageValid)
            {
                axios.post('/contact/kontakt', JSON.stringify({
                    PersonName: firstNameLastName,
                    EmailAddress: emailAddress,
                    Phone: phoneNumber,
                    ReservationId: reservationNumber,
                    Message: message
                })).then(() => {
                    alert('Dziękujemy za wiadomość. Oczekuj odpowiedzi na swojej skrzynce E-mail.')
                    navigate('/')
                })
            } else {
                setErrorState(true)
            }
    }

    const resetButtonHandler = () => {
        setFirstNameLastName('')
        setFistNameLastNameValid(false)
        setEmailAddress('')
        setEmailAddressValid(false)
        setPhoneNumber('')
        setPhoneNumberValid(false)
        setReservationNumber('')
        setReservationNumber(false)
        setMessage('')
        setMessageValid(false)
        setErrorState(false)
    }

    const firstNameLastNameHandler = (event) => {
        setFirstNameLastName(event.target.value)
    }

    const emailAddressHandler = (event) => {
        setEmailAddress(event.target.value)
    }

    const phoneNumberHandler = (event) => {
        setPhoneNumber(event.target.value)
    }

    const reservationNumberHandler = (event) => {
        setReservationNumber(event.target.value)
    }

    const messageHandler = (event) => {
        setMessage(event.target.value)
    }

    useEffect(() => {
        const result = firstNameLastNameREGEX.test(firstNameLastName)
        setFistNameLastNameValid(result)
    }, [firstNameLastName])

    useEffect(() => {
        const result = emailAdressREGEX.test(emailAddress)
        setEmailAddressValid(result)
    }, [emailAddress])

    useEffect(() => {
        const result = phoneNumberREGEX.test(phoneNumber)
        setPhoneNumberValid(result)
    }, [phoneNumber])

    useEffect(() => {
        const result = reservationNumberREGEX.test(reservationNumber)
        setReservationNumberValid(result)
    }, [reservationNumber])

    useEffect(() => {
        const result = message.length !== 0 ? true : false
        setMessageValid(result) 
    }, [message])

  return (
    <div className={styles.contactFormWrapper}>
        <h2 className={styles.contactFormTitle} style={{ fontFamily: "Montserrat" }}>
            Formularz kontaktowy
        </h2>
        {
            errorState && errorArea
        }
        <form className={styles.contactFormMain} onSubmit={contactFormHandler}>
            <div className={styles.contactFormInputArea}>
                <label>Imię i nazwisko:</label>
                <input type='text' onChange={firstNameLastNameHandler} 
                                        className={styles.contactInput} />
            </div>
            <div className={styles.contactFormInputArea}>
                <label>Email:</label>
                <input type='text' onChange={emailAddressHandler} 
                                    className={styles.contactInput}/>
            </div>
            <div className={styles.contactFormInputArea}>
                <label>Numer telefonu:</label>
                <input type='text' onChange={phoneNumberHandler} 
                                    className={styles.contactInput}/>
            </div>
            <div className={styles.contactFormInputArea}>
                <label>Numer rezerwacji:</label>
                <input type='text' onChange={reservationNumberHandler} 
                                    className={styles.contactInput}/>
            </div>
            <div className={styles.contactFormInputArea}>
                <label>Wiadomość:</label>
                <textarea onChange={messageHandler}>

                </textarea>
            </div>
            <div className={styles.formButtonsArea}>
                <button onClick={resetButtonHandler} 
                            className={styles.resetButton}>Resetuj</button>
                <button type='submit' className={styles.sendButton} >Wyślij</button>
            </div>
        </form>
    </div>
  )
}

export default ContactForm