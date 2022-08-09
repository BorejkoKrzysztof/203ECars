import React, { useEffect } from 'react'
import styles from './MainPage.module.css'
import Banner from './SubComponents/Banner/Banner'
import EasyStepsBar from './SubComponents/EasyStepsBar/EasyStepsBar'
import KindsOfCarBar from './SubComponents/KindsOfCarsBar/KindsOfCarBar'
import OfferInfoBar from './SubComponents/OfferInfoBar/OfferInfoBar'
import RecommendationsBar from './SubComponents/RecommendationsBar/RecommendationsBar'

function MainPage() {
  
  useEffect(() => {
    document.title ='203E Cars - Main Page'
  }, [])
  
  return (
    <>
      <Banner />
      <OfferInfoBar />
      <RecommendationsBar />
      <KindsOfCarBar />
      <EasyStepsBar />
      <div className={styles.Temporary}>MainPage</div>
    </>
  )
}

export default MainPage