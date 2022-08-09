import React from 'react'
import styles from './EasyStepsBar.module.css'
import { FaSearch } from 'react-icons/fa'
import { BsFillHandIndexThumbFill } from 'react-icons/bs'
import { AiFillCar } from 'react-icons/ai'

function EasyStepsBar() {
  return (
    <div className={styles.easyStepsWrapper}>
        <h1 className={styles.title}>Easy booking</h1>
        <p className={styles.companyDescription}>
            &nbsp; In 203E Cars, we strive to make sure that our customers can rent a car without too 
            much effort or paperwork. We value your time, so make just a few clicks from any device. 
            <span>
                Use our form at the top of the page.
            </span>
        </p>
        <div className={styles.descriptionsItemsSteps}>
            <div className={styles.step}>
                <div>
                    <FaSearch />
                </div>
                <div>
                    <h3>Search</h3>
                    <h5>Choose your location</h5>
                </div>
            </div>
            <div className={styles.step}>
                <div>
                    <BsFillHandIndexThumbFill />
                </div>
                <div>
                    <h3>Select</h3>
                    <h5>Select the best car</h5>
                </div>
            </div>
            <div className={styles.step}>
                <div>
                    <AiFillCar />
                </div>
                <div>
                    <h3>Book</h3>
                    <h5>Reserve your car</h5>
                </div>
            </div>
        </div>
    </div>
  )
}

export default EasyStepsBar