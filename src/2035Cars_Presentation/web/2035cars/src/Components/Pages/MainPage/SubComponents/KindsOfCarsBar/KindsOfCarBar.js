import React from 'react'
import styles from './KindsOfCarBar.module.css'
import { kindsOfCars } from './exampleTypes.js' 
import KindOfCarItem from './Item/KindOfCarItem'

function KindsOfCarBar() {


  return (
    <div className={styles.kindsOfCarBarWrapper}>
        <h1>We have all what you need</h1>
        <p>
            Convertibles, luxury cars, SUVs and sports cars are some of the most popular
        </p>
        <div className={styles.kindsOfCarBarContent}>
            {kindsOfCars.map((item, index) => {
                return(
                    <KindOfCarItem 
                            key = {index} 
                            Kind = {item.Kind}
                            Img = {item.ImagePath}
                            Alt = {item.Alt}
                            Brand = {item.Brand}
                            Model = {item.Model}
                            AmountOfPlaces = {item.AmountOfPlaces}
                            AmountOfDoors = {item.AmountOfDoors}
                            Link = {item.Link}/>
                )
            })}
        </div>
    </div>
  )
}

export default KindsOfCarBar