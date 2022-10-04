import React from 'react'
import styles from './ContactForm.module.css'

function ContactForm() {
  return (
    <div className={styles.contactFormWrapper}>
        <h2 className={styles.contactFormTitle} style={{ fontFamily: "Montserrat" }}>
            Formularz kontaktowy
        </h2>
        <form className={styles.contactFormMain}>
            <div className={styles.contactFormInputArea}>
                <label>Imię i nazwisko:</label>
                <input className={styles.contactInput} />
            </div>
            <div className={styles.contactFormInputArea}>
                <label>Email:</label>
                <input className={styles.contactInput}/>
            </div>
            <div className={styles.contactFormInputArea}>
                <label>Numer telefonu:</label>
                <input className={styles.contactInput}/>
            </div>
            <div className={styles.contactFormInputArea}>
                <label>Numer rezerwacji:</label>
                <input className={styles.contactInput}/>
            </div>
            <div className={styles.contactFormInputArea}>
                <label>Wiadomość:</label>
                <textarea>

                </textarea>
            </div>
            <div className={styles.formButtonsArea}>
                <button className={styles.resetButton}>Resetuj</button>
                <button type='submit' className={styles.sendButton} >Wyślij</button>
            </div>
        </form>
    </div>
  )
}

export default ContactForm