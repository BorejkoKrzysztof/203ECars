import React, { useEffect, useState } from "react";
import styles from './LoginPage.module.css'
import axios from "../../../axios/axiosDefault";
import { Link, useNavigate, useLocation } from 'react-router-dom'
import { FaCar } from 'react-icons/fa'


function Login()
{
    const location = useLocation()
    const from = location.state?.from?.pathname || '/'

    const [loginFailed, setLoginFailed] = useState(false)
    const [accountEmail, setAccountEmail] = useState('')
    const [accountPassword, setAccountPassword] = useState('')
    const [token, setToken] = useState('')
    const [refreshToken, setRefreshToken] = useState('')
    const [errorMessageState, setErrorMessageState] = useState(' ')


    const accountEmailHandler = (e) => {
        setAccountEmail(e.target.value)
    }

    const accountPasswordHandler = (e) => {
        setAccountPassword(e.target.value)
    }


    const loginHandler = async (event) => {
       event.preventDefault()
       try{
            axios.post('/employee/login', JSON.stringify({
            EmailAddress: accountEmail,
            Password: accountPassword
            }))
            .then( (response) => {
                localStorage.setItem('token', `${response.data.token}`)
                localStorage.setItem('refreshToken', `${response.data.refreshToken}`)
                localStorage.setItem('role', `${response.data.role}`)
                localStorage.setItem('is-loged', `${true}`)
                window.location.href = '/'
            })
       }
       catch(error) {
            setLoginFailed(true)
            if (error.response.status === 404){
                setErrorMessageState('Invalid credentials.')
            }
            else {
                setErrorMessageState('Unknown error.')
            }
    }
}

    const errorMessage = (
    <div className={styles.credentialsError}>
        <span>{errorMessageState}</span>
    </div>
    )

    useEffect(() => {
        document.title ='Zaloguj się'
    }, [])

    return (
        <div className={styles.wrapper}>
            <div className={styles.loginContainer}>
                <h1 style={{ fontFamily: '"Quantico"'}} >
                    <span>
                        <FaCar className={styles.carIcon}/>
                        /203
                    </span>
                    E Cars
                </h1>
                <form onSubmit={loginHandler} className={styles.loginForm}>
                    <div>
                        <label>Adres Email:</label>
                        <input type='email' onChange={accountEmailHandler}></input>
                    </div>
                    <div>
                        <label>Hasło:</label>
                        <input type='password' onChange={accountPasswordHandler}></input>
                    </div>
                    {loginFailed && errorMessage}
                    <div className={styles.buttonContainer}>
                        <button className={styles.loginButton} type='submit' value='Login'>Zaloguj</button>
                    </div>
                    <h5 className={styles.registerOffer}>Nie masz jeszcze konta? 
                        <Link className={styles.registerLink} to='/rejestracja'>
                            Zarejestruj się!</Link>
                    </h5>
                </form>
            </div>
        </div>
    )
}

export default Login;