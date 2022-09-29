import React from 'react'
import styles from './RepairInfoBar.module.css'
import { GiAutoRepair } from 'react-icons/gi'

function RepairInfoBar() {
  return (
    <div className={styles.repairInfoWrapper}>
        <div className={styles.repairBigIcon}>
            <GiAutoRepair />
        </div>
        <div className={styles.repairDescription}>
            <h1 className={styles.repairTitle}>
                Naprawimy Twój samochód, jeśli zepsuje się podczas podróży!
            </h1>
            <p className={styles.repairParagraph}>
                203E Cars posiada wypożyczalnie w większości miast, więc jeśli Twój samochód zepsuje się podczas podróży, 
                nasz mechanik przyjedzie do Ciebie i spróbuje naprawić samochód na miejscu. 
                Jeśli szybka naprawa nie będzie możliwa otrzymasz samochód zastępczy.
            </p>
        </div>
    </div>
  )
}

export default RepairInfoBar