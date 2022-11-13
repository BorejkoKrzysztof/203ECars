import React from 'react'
import { Card,
         CardTitle,
         CardText,
         ListGroup,
         ListGroupItem,
         CardLink,
         CardBody} from 'reactstrap'
import styles from './CarCard.module.css'
import axios from '../../../../axios/axiosAuthorize'

function CarCard(props) {

const removeCarHandler = (carId) => {
    if(window.confirm('Ta akcja spowoduje usunięcie samochodu') == true) {
        axios.delete(`car/removecar/${carId}`)
            .then(() => {
                window.location.reload()
            })
            .catch( (error) => {
                console.log(error)
            })
    }
}

  return (
    <Card className={styles.cardContent}
        >
        <img style={{ padding: '25px' }}
            alt="Car"
            src={`data:image/png;base64,${props.image}`}
        />
        <CardBody>
            <CardTitle tag="h5" className={styles.carCardTitle}>
                {`${props.brand} ${props.model}`}
            </CardTitle>
        </CardBody>
        <CardBody className={styles.carCardButtonContent}>
        <a className={`btn btn-primary ${styles.greenLink} ${styles.buttonLink}`}
                onClick={() => {
                    sessionStorage.setItem('carId', `${props.id}`)
                    window.location.href = '/szczegolysamochodu'
                }}>
                Zobacz
            </a>
            <a className={`btn btn-primary ${styles.blueLink} ${styles.buttonLink}`}
                onClick={() => {
                    sessionStorage.setItem('CarToEditId', `${props.id}`)
                    window.location.href = 'edytujsamochod'
                }}>
                Edytuj
            </a>
            <a className={`btn btn-danger ${styles.buttonLink}`}
                onClick={ () => { removeCarHandler(props.id) } }>
                Usuń
            </a>
        </CardBody>
    </Card>
  )
}

export default CarCard