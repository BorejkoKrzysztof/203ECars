import React from 'react'
import { Card,
         CardTitle,
         CardText,
         ListGroup,
         ListGroupItem,
         CardLink,
         CardBody} from 'reactstrap'
import styles from './CarCard.module.css'

function CarCard(props) {
  return (
    <Card className={styles.cardContent}
        >
        <img
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
                href="#">
                Edytuj
            </a>
            <a className={`btn btn-danger ${styles.buttonLink}`}
                href="#">
                Usuń
            </a>
        </CardBody>
    </Card>
  )
}

export default CarCard