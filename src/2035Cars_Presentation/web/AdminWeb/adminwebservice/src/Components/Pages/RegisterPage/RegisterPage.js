import React, { useState, useEffect } from "react";
import styles from './RegisterPage.module.css'
import axios from '../../../axios/axiosDefault'
import { RiErrorWarningLine } from 'react-icons/ri'


function Register(props) {

    const nameREGEX = /^[A-ZżźćńółęąśŻŹĆĄŚĘŁÓŃ][a-zżźćńółęąś]{2,15}$/
    const emailAdressREGEX = /^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i
    const passwordREGEX = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{7,15})");

    const [token, setToken] = useState()
    const [refreshToken, setRefreshToken] = useState()

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

    const [department, setDepartment] = useState()
    const [departmentValid, setDepartmentValid] = useState(false)

    const [businessPositions, setBusinessPosition] = useState(0)

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

    const setDepartmentHandler = (e) => {
        setDepartment(e.target.value)
    }

    const setBusinessPositionHandler = (e) => {
        setBusinessPosition(e.target.value)
    }


    const registerHandler = async (event) => {
        event.preventDefault();

        if(firstNameValid && lastNameValid && emailValid && 
                passwordValid && confirmPasswordValid && departmentValid) {
            
            const calculatedDepartment = department - 1

            await axios.post('/account/register', JSON.stringify({
                FirstName: firstName,
                LastName: lastName,
                EmailAdress: email,
                Password: password,
                Role: calculatedDepartment,
                BusinessPosition: businessPositions
            }))
            .then( (response) => {
                setToken(response.data.token)
                setRefreshToken(response.data.refreshToken)
                props.func()
                window.location.href='/todolists'
            })
        }
        else{
            setErrorState(true)
        }
    }

    useEffect(() => {
        document.title ='Rejestracja'
    }, [])

    useEffect(() => {
        const result = nameREGEX.test(firstName)
        setFirstNameValid(result)
    }, [firstName])

    useEffect(() => {
        const result = nameREGEX.test(lastName)
        setLastNameValid(result)
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

    useEffect(() => {
        const result = department !== 0
        setDepartmentValid(result)
    })


    return (
        <div className={styles.pageWrapper}>
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
                                <p>Długość imienia musi mieć od 3 do 15 znaków. 
                                    Imię musi zaczynać się z dużej litery</p>
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
                                <p>Długość nazwiska musi mieć od 3 do 15 znaków. 
                                    Nazwisko musi zaczynać się z dużej litery.
                                </p>
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
                                <p>Podaj prawidłowy Adres Email.</p>
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
                                <p>Hasło musi zawierać od 7 do 15 znaków, w tym co najmniej jedną wielką literę, jedną cyfrę i znak specjalny.</p>
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
                                <p>Hasło potwierdzające musi być zgodne z hasłem.</p>
                        </div>
                    </div>
                    <div className={styles.inputContainer}>
                        <label>Dział pracownika:</label>
                        <select onChange={setDepartmentHandler}>
                            <option value={0}>Wybierz dział:</option>
                            <option value={1}>Dział Sprzedaży</option>
                            <option value={2}>Dział Obsługi Klienta</option>
                            <option value={3}>Dział Marketingu</option>
                            <option value={4}>Zarząd</option>
                        </select>
                    </div>
                    <div className={styles.inputFullContainer}>
                        <label className={styles.businessPositionLabel}>Stanowisko</label>
                        <div className={styles.radioButtonsWrapper} onChange={setBusinessPositionHandler}>
                            <div>
                               <div className={styles.buttonGridArea}>
                                    <label>Pracownik</label>
                                    <input type='radio' value={2} name='businessPosition' checked={true}/>
                                </div>
                            </div>
                            <div>
                            <div className={styles.buttonGridArea}>
                                <label>Dyrektor</label>
                                <input type='radio' value={1} name='businessPosition' />
                                </div>
                            </div>
                            <div>
                            <div className={styles.buttonGridArea}>
                                <label>Menadżer</label>
                                <input type='radio' value={0} name='businessPosition' />
                                </div>
                            </div>
                        </div>
                    </div>
                    {errorState && <div className={styles.errorBanner}>
                                        <p className={styles.errorText}>Niepowodzenie. Spróbuj ponownie.</p>
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