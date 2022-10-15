import React, { useState, useEffect } from "react";
import styles from './RegisterPage.module.css'
// import axios from '../../../axios/axiosPublicInstance'
// import useLocalStorage from "../../../hooks/useLocalStorage";
import { RiErrorWarningLine } from 'react-icons/ri'


function Register(props) {

    const nameREGEX = /^[A-ZżźćńółęąśŻŹĆĄŚĘŁÓŃ][a-zżźćńółęąś]{2,15}$/
    const emailAdressREGEX = /^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i
    const passwordREGEX = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{7,15})");


    // const [token, setToken] = useLocalStorage('token', '')
    // const [refreshToken, setRefreshToken] = useLocalStorage('refreshToken', '')

    const [firstName, setFirstName] = useState('')
    const [firstNameValid, setFirstNameValid] = useState(false)
    const [firstNameFocus, setFirstNameFocus] = useState(false)


    const [lastName, setLastName] = useState('')
    const [lastNameValid, setLastNameValid] = useState(false)
    const [lastNameFocus, setLastNameFocus] = useState(false)


    const [email, setEmail] = useState('')
    const [emailValid, setEmailValid] = useState(false)
    const [emailFocus, setEmailFocus] = useState(false)

    const [password, setPassword] = useState('')
    const [passwordValid, setPasswordValid] = useState(false)
    const [passwordFocus, setPasswordFocus] = useState(false)

    const [confirmPassword, setConfirmPassword] = useState('')
    const [confirmPasswordValid, setConfirmPasswordValid] = useState(false)
    const [confirmPasswordFocus, setConfirmPasswordFocus] = useState(false)

    const [errorState, setErrorState] = useState(false)


    const firstNameHandler = (e) => {
        setFirstName(e.target.value)
    }

    const lastNameHandler = (e) => {
        setLastName(e.target.value)
    }

    const emailHandler = (e) => {
        setEmail(e.target.value)
    }

    const passwordHandler = (e) => {
        setPassword(e.target.value)
    }

    const confirmPasswordHandler = (e) => {
        setConfirmPassword(e.target.value)
    }

    const registerHandler = async (event) => {}

    // const registerHandler = async (event) => {
    //     event.preventDefault();

    //     if(nickNameValid && emailValid && passwordValid && confirmPasswordValid) {
    //         await axios.post('/account/register', JSON.stringify({
    //             NickName: nickName,
    //             EmailAdress: email,
    //             Password: password,
    //             Role: 2
    //         }))
    //         .then( (response) => {
    //             setToken(response.data.token)
    //             setRefreshToken(response.data.refreshToken)
    //             // axios.defaults.headers.common['Authorization'] = `Bearer ${response.data.token}`
    //             props.func()
    //             window.location.href='/todolists'
    //         })
    //     }
    //     else{
    //         setErrorState(true)
    //     }
    // }

    useEffect(() => {
        document.title ='Rejestracja'
    }, [])

    useEffect(() => {
        const result = nameREGEX.test(firstName)
        setFirstNameValid(result)
    }, [firstName])

    useEffect(() => {
        const result = nameREGEX.test(lastName)
        setFirstNameValid(result)
    }, [lastName])

    useEffect(() => {
        const result = emailAdressREGEX.test(email)
        setEmailValid(result)
    }, [email])

    useEffect(() => {
        const result = passwordREGEX.test(password)
        setPasswordValid(result)
    }, [password])

    useEffect(() => {
        const result = password === confirmPassword
        setConfirmPasswordValid(result)
    }, [confirmPassword])


    return (
        <div className={styles.pageWrapper}>
            {/* <h1 className={styles.pageTitle} style={{ fontFamily: '"Noto Serif", serif' }}>Zarejestruj pracownika</h1> */}
            <div className={styles.formContainer}>
                <h1  style={{fontFamily: 'Quantico'}} className={styles.title}><span>203</span>E Cars</h1>
                <form onSubmit={registerHandler} className={styles.registerForm} autoComplete="off">
                    <div className={styles.inputContainer}>
                        <label>Imię:</label>
                        <input type='text'
                                onChange={firstNameHandler}
                                required
                                aria-invalid={firstNameValid ? "false" : "true"}
                                aria-describedby='firstNameNote'
                                onFocus={() => { setFirstNameFocus(true) }}
                                onBlur={() => { setFirstNameFocus(false) }}></input>

                        <div id="firstNameNote"
                             className={firstNameFocus && firstName && !firstNameValid ? styles.errorDescription : styles.offScreen}>
                                <RiErrorWarningLine className={styles.warningIcons}/>
                                <p>Imię length must have between 3 and 15 characters.</p>
                        </div>
                    </div>
                    <div className={styles.inputContainer}>
                        <label>Nazwisko:</label>
                        <input type='text'
                                onChange={lastNameHandler}
                                required
                                aria-invalid={lastNameValid ? "false" : "true"}
                                aria-describedby='lastNameNote'
                                onFocus={() => { setLastNameFocus(true) }}
                                onBlur={() => { setLastNameFocus(false) }}></input>

                        <div id="lastNameNote"
                             className={lastNameFocus && lastName && !lastNameValid ? styles.errorDescription : styles.offScreen}>
                                <RiErrorWarningLine className={styles.warningIcons}/>
                                <p>Nazwisko length must have between 3 and 15 characters.</p>
                        </div>
                    </div>
                    <div className={styles.inputContainer}>
                        <label>Adres Email:</label>
                        <input type='email'
                                onChange={emailHandler}
                                required
                                aria-invalid={emailValid ? "false" : "true"}
                                aria-describedby='emailNote'
                                onFocus={() => { setEmailFocus(true) }}
                                onBlur={() => { setEmailFocus(false) }}></input>

                        <div id="emailNote"
                             className={emailFocus && email && !emailValid ? styles.errorDescription : styles.offScreen}>
                                <RiErrorWarningLine className={styles.warningIcons}/>
                                <p>Enter correct Email Adress.</p>
                        </div>
                    </div>
                    <div className={styles.inputContainer}>
                        <label>Hasło:</label>
                        <input type='password'
                                onChange={passwordHandler}
                                required
                                aria-invalid={passwordValid ? "false" : "true"}
                                aria-describedby='passwordNote'
                                onFocus={() => { setPasswordFocus(true) }}
                                onBlur={() => { setPasswordFocus(false) }}
                                ></input>
                        <div id="passwordNote"
                             className={passwordFocus && password && !passwordValid ? styles.errorDescription : styles.offScreen}>
                                <RiErrorWarningLine className={styles.warningIcons}/>
                                <p>Password must be between 7 to 15 characters which contain at least one uppercase letter, one digit and a special character.</p>
                        </div>
                    </div>
                    <div className={styles.inputContainer}>
                        <label>Potwierdź Hasło:</label>
                        <input type='password'
                                onChange={confirmPasswordHandler}
                                autoComplete="off"
                                required
                                aria-invalid={confirmPasswordValid ? "false" : "true"}
                                aria-describedby='confirmPasswordNote'
                                onFocus={() => { setConfirmPasswordFocus(true) }}
                                onBlur={() => { setConfirmPasswordFocus(false) }}
                                ></input>
                        <div id="confirmPasswordNote"
                             className={confirmPasswordFocus && confirmPassword && !confirmPasswordValid ? styles.errorDescription : styles.offScreen}>
                                <RiErrorWarningLine className={styles.warningIcons}/>
                                <p>Confirm password must match password.</p>
                        </div>
                    </div>
                    {errorState && <div className={styles.errorBanner}>
                                        <p className={styles.errorText}>Process failed. Try again.</p>
                                    </div>}
                    <div className={styles.buttonContainer}>
                        <button className={styles.submitButton} type="submit">Zarejestruj</button>
                    </div>
                </form>
            </div>
        </div>
    )
}

export default Register;