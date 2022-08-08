import React from 'react'
import styles from './RecommendationsBar.module.css'
import { FaHandshake } from 'react-icons/fa'
import { IoCarSportSharp } from 'react-icons/io5'
import { MdPriceCheck } from 'react-icons/md'

function RecommendationsBar() {
  return (
    <div className={styles.RecommendationsBarWrapper}>
        <div className={styles.RecommendationsInfoWrapper}>
            <div className={styles.RecommendationsInfoContent}>
                <div>
                    <FaHandshake className={styles.recomInfoIcon}/>
                </div>
                <div className={styles.recomInfoDescription}>
                    <h4>Leading Car Rental in EU</h4>
                    <p>We are the largest rental company in Europe. 
                        We are trusted by millions of customers.
                    </p>
                </div>
            </div>
            <div className={styles.RecommendationsInfoContent}>
                <div>
                    <IoCarSportSharp className={styles.recomInfoIcon}/>
                </div>
                <div className={styles.recomInfoDescription}>
                    <h4>Rental fleet for all kinds of travelers</h4>
                    <p>
                        From compact families, single travelers to large groups, there is a car for everyone.
                    </p>
                </div>
            </div>
            <div className={styles.RecommendationsInfoContent}>
                <div>
                    <MdPriceCheck className={styles.recomInfoIcon}/>
                </div>
                <div className={styles.recomInfoDescription}>
                    <h4>Cheapest rental cars for all countries</h4>
                    <p>
                    Save more with discounted car rental prices for locations at all major cities and airports.
                    </p>
                </div>
            </div>
        </div>

        
    </div>
  )
}

export default RecommendationsBar