import React from 'react'
import styles from './ContactInfoBar.module.css'
import { BsTelephoneFill } from 'react-icons/bs'
import { MdOutlineAlternateEmail, MdEmail } from 'react-icons/md'


function ContactInfoBar() {
  return (
    <div className={styles.contactInfoBarWrapper}>
        <div className={styles.contactTitleWrapper}>
            <h1 className={styles.contactTitle} style={{ fontFamily: "Montserrat" }}>
                Skontaktuj się z nami - Wsparcie 24/7!
            </h1>
        </div>
        <div className={styles.contactDescriptionWrapper}>
            <p className={styles.contactDescription}>
                Zadzwoń do nas, skorzystaj z formularza, lub napisz Email.
            </p>
        </div>
        <div className={styles.iconsWrapper}>
            <BsTelephoneFill className={styles.phoneIcon}/>
            <MdEmail className={styles.envelopIcon} />
            <MdOutlineAlternateEmail className={styles.emailIcon} />
        </div>
    </div>
  )
}

export default ContactInfoBar