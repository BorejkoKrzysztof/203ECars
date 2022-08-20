import React, { useEffect, useState } from "react";
import styles from './LoginPage.module.css';
// import axios from "../../../axios/axiosPublicInstance";
// import useLocalStorage from "../../../hooks/useLocalStorage";
import { Link, useNavigate, useLocation } from 'react-router-dom'


function Login({setLoggedState})
{
    const location = useLocation()
    const from = location.state?.from?.pathname || '/'

    const [loginFailed, setLoginFailed] = useState(false)
    const [accountEmail, setAccountEmail] = useState('')
    const [accountPassword, setAccountPassword] = useState('')
    // const [token, setToken] = useLocalStorage('token', '')
    // const [refreshToken, setRefreshToken] = useLocalStorage('refreshToken', '')
    const [errorMessageState, setErrorMessageState] = useState(' ')


    const accountEmailHandler = (e) => {
        setAccountEmail(e.target.value)
    }

    const accountPasswordHandler = (e) => {
        setAccountPassword(e.target.value)
    }


        const loginHandler = () => {}

//     const loginHandler = async (event) => {
//        event.preventDefault()
//        try{
//             await axios.post('/account/login', JSON.stringify({
//             EmailAdress: accountEmail,
//             Password: accountPassword
//             }))
//             .then( (response) => {
//                 setToken(response.data.token)
//                 setRefreshToken(response.data.refreshToken)
//                 // axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
//                 setLoggedState()
//                 setAccountEmail('')
//                 setAccountPassword('')
//                 window.location.href = from
//             })
//        }
//        catch(error) {
//             setLoginFailed(true)
//             if (error.response.status === 404){
//                 setErrorMessageState('Invalid credentials.')
//             }
//             else {
//                 setErrorMessageState('Unknown error.')
//             }
//     }
// }

    const errorMessage = (
    <div className={styles.credentialsError}>
        <span>{errorMessageState}</span>
    </div>
    )

    useEffect(() => {
        document.title ='Login'
    }, [])

    return (
        <div className={styles.wrapper}>
            <div className={styles.loginContainer}>
                <h1>My Tasks!</h1>
                <form onSubmit={loginHandler} className={styles.loginForm}>
                    <div>
                        <label>Email Adress:</label>
                        <input type='email' onChange={accountEmailHandler}></input>
                    </div>
                    <div>
                        <label>Password:</label>
                        <input type='password' onChange={accountPasswordHandler}></input>
                    </div>
                    {loginFailed && errorMessage}
                    <div className={styles.buttonContainer}>
                        <button className={styles.loginButton} type='submit' value='Login'>Log In</button>
                    </div>
                    <h5 className={styles.registerOffer}>Don't have an account yet? 
                        <Link className={styles.registerLink} to='/register'>
                            Register NOW!</Link>
                    </h5>
                </form>
            </div>
        </div>
    )
}

export default Login;