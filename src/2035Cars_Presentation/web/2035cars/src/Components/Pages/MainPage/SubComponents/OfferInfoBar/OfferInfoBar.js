import React from 'react'
import styles from './OfferInfoBar.module.css'
import { MdFreeCancellation } from 'react-icons/md'
import { BiHide } from 'react-icons/bi'
import { GiRotaryPhone } from 'react-icons/gi'

function OfferInfoBar() {
  return (
    <div className={styles.OfferInfoBarWrapper}>
        <div>
            <MdFreeCancellation />
            <h5 className={styles.offerDescription}>Bezpłatne odwołania</h5>
        </div>
        <div>
            <BiHide />
            <h5 className={styles.offerDescription}>Brak ukrytych opłat</h5>
        </div>
        <div>
            <GiRotaryPhone />
            <h5 className={styles.offerDescription}>Wsparcie 24/7</h5>
        </div>
    </div>
  )
}

export default OfferInfoBar