import React, { useState } from 'react'
import styles from './ContactPage.module.css'
import ContactForm from './SubComponents/ContactForm/ContactForm'
import ContactInfoBar from './SubComponents/ContactInfoBar/ContactInfoBar'
import ContactInfo from './SubComponents/ContactInfo/ContactInfo'

function ContactPage() {

    useState(() => {
        document.title = 'Kontakt - 203E Cars'
    }, [])

  return (
    <div className={styles.contactWrapper}>
        <ContactInfoBar />
        <ContactForm />
        {/* <ContactInfo /> */}
    </div>
  )
}

export default ContactPage