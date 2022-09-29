import React from 'react'
import styles from './RecommendationsBar.module.css'
import { FaHandshake } from 'react-icons/fa'
import { IoCarSportSharp } from 'react-icons/io5'
import { MdPriceCheck } from 'react-icons/md'
import { ImStarFull, ImStarHalf } from 'react-icons/im'

function RecommendationsBar() {
  return (
    <div className={styles.RecommendationsBarWrapper}>
        <div className={`${styles.RecommendationsInfoWrapper} ${styles.cardRecommendationContent}`}>
            <div className={styles.RecommendationsInfoContent}>
                <div>
                    <FaHandshake className={styles.recomInfoIcon}/>
                </div>
                <div className={styles.recomInfoDescription}>
                    <h4>Wiodąca wypożyczalnia samochodów w Polsce</h4>
                    <p>Jesteśmy największą wypożyczalnią w Polsce. 
                        Zaufały nam miliony klientów.
                    </p>
                </div>
            </div>
            <div className={styles.RecommendationsInfoContent}>
                <div>
                    <IoCarSportSharp className={styles.recomInfoIcon}/>
                </div>
                <div className={styles.recomInfoDescription}>
                    <h4>Wszystkie typy aut</h4>
                    <p>
                    Od kompaktowych, rodzinnych, po sportowe kabriolety, jest tu samochód dla każdego.
                    </p>
                </div>
            </div>
            <div className={styles.RecommendationsInfoContent}>
                <div>
                    <MdPriceCheck className={styles.recomInfoIcon}/>
                </div>
                <div className={styles.recomInfoDescription}>
                    <h4>Najtańsza wypożyczalnia w kraju</h4>
                    <p>
                    Oszczędzaj więcej dzięki obniżonym cenom wynajmu samochodów w lokalizacji we wszystkich większych miastach i na lotniskach.
                    </p>
                </div>
            </div>
        </div>
        <div className={`${styles.recommendationQuoteWrapper} ${styles.cardRecommendationContent}`}>
            <div className={styles.recommendationQuoteContent}>
                <h1 className={styles.recommendationsRate}>4.8/5</h1>
                <h3 className={styles.recommendationRateText}>Wspaniała</h3>
                <div className={styles.recommendationStars}>
                    <ImStarFull />
                    <ImStarFull />
                    <ImStarFull />
                    <ImStarFull />
                    <ImStarHalf />
                </div>
                <p className={styles.recommendationQuoteSource}>
                    Na podstawie
                    <span>
                        1200+ ocen
                    </span>
                </p>
            </div>
        </div>
        <div className={`${styles.recommendationOfferWrapper} ${styles.cardRecommendationContent}`}>
            <div className={styles.recommendationOfferContent}>
                <h2>Wynajmij auto</h2>
                <h3>
                    Dowolne miasto
                </h3>
                <h4>
                    Wybierz spośród 300 aut
                </h4>
                <img src={process.env.PUBLIC_URL + '/Images/ExampleCars/Przechwytywanie.jpg'} alt='car'/>
                <a 
                // TODO Przekierowanie do banner
                >  
                    ZAREZERWUJ
                </a>
            </div>
        </div>
    </div>
  )
}

export default RecommendationsBar