import React from 'react'
import styles from './ContactInfo.module.css'
import { BsTelephoneFill } from 'react-icons/bs'
import { MdEmail } from 'react-icons/md'

function ContactInfo() {
  return (
    <div className={styles.contactInfoWrapper}>
        <div className={styles.contactItem}>
            <BsTelephoneFill className={styles.contactIcon}/>
            <h3 className={styles.contactTitle} style={{ fontFamily: "Montserrat" }}>
              Wsparcie telefoniczne
            </h3>
            <p>Zadzwoń do nas, aby uzyskać natychmiastową odpowiedź.
               Koszt zgodny z taryfą operatora.
            </p>
            <div className={styles.contactDataInfo}>
                <h3>+ 48 789 264 514</h3>
            </div>
        </div>
        <div className={styles.contactItem}>
            <MdEmail className={styles.contactIcon}/>
            <h3 className={styles.contactTitle} style={{ fontFamily: "Montserrat" }}>
              Wiadomość email
            </h3>
            <p>Napisz do nas wiadomość Email, 
              a my odpowiemy Ci w ciągu jednego dnia roboczego.
            </p>
            <div className={styles.contactDataInfo}>
                <h3>support@203ecars.pl</h3>
            </div>
        </div>
    </div>
  )
}

export default ContactInfo