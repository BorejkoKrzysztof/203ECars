import React from 'react'
import styles from './RecommendationsBar.module.css'
import { FaHandshake } from 'react-icons/fa'
import { IoCarSportSharp } from 'react-icons/io5'
import { MdPriceCheck } from 'react-icons/md'
import { ImStarFull, ImStarHalf } from 'react-icons/im'

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
        <div className={styles.recommendationQuoteWrapper}>
            <div className={styles.recommendationQuoteContent}>
                <h1 className={styles.recommendationsRate}>4.8/5</h1>
                <h3 className={styles.recommendationRateText}>Amazing</h3>
                <div className={styles.recommendationStars}>
                    <ImStarFull />
                    <ImStarFull />
                    <ImStarFull />
                    <ImStarFull />
                    <ImStarHalf />
                </div>
                <p className={styles.recommendationQuoteSource}>
                    Based on 
                    <span>
                        1200+ reviews
                    </span>
                </p>
            </div>
        </div>
        <div className={styles.recommendationOfferWrapper}>
            <div className={styles.recommendationOfferContent}>
                <h2>Rent a car</h2>
                <h3>
                    Anywhere from Europe
                </h3>
                <h4>
                    Choose from 300+ cars
                </h4>
                <img src={process.env.PUBLIC_URL + '/Images/ExampleCars/Przechwytywanie.jpg'} alt='car'/>
                <a 
                // TODO Przekierowanie do banner
                >  
                    BOOK A CAR
                </a>
            </div>
        </div>
        
    </div>
  )
}

export default RecommendationsBar