import React from 'react'
import styles from './KindOfCarItem.module.css'
import { BsFillPersonFill } from 'react-icons/bs'
import { GiCarDoor } from 'react-icons/gi'
import { useNavigate } from 'react-router-dom'
import Cookie from 'universal-cookie'

function KindOfCarItem(props) {

    const navigate = useNavigate();
    
    const navigateTo = (kindOfCar) => {
        const cookies = new Cookie()
        cookies.set(`${kindOfCar}`, `${true}`)
        navigate('/samochody')
    }

  return (
    <div className={styles.kindItemWrapper} onClick={() => { navigateTo(props.Kind)}}>
        <div className={styles.mainPart}>
            <span className={styles.economyInfo}>
                {props.Kind}
            </span>
                <img src={props.Img} alt={props.Alt} />
            <h3 className={styles.modelTitle}>{props.Brand} {props.Model}</h3>
        </div>
        <div className={styles.infoBar}>
            <div>
                <BsFillPersonFill />
                <span>/ {props.AmountOfPlaces}</span>
            </div>
            <div>
                <GiCarDoor />
                <span>/ {props.AmountOfDoors}</span>
            </div>
        </div>
    </div>
  )
}

export default KindOfCarItem