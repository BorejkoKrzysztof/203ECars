import React from 'react'
import { Card,
         CardTitle,
         CardText,
         ListGroup,
         ListGroupItem,
         CardLink,
         CardBody} from 'reactstrap'
import styles from './CarCard.module.css'

function CarCard() {
  return (
    <Card className={styles.cardContent}
        >
        <img
            alt="Card"
            src="https://picsum.photos/300/200"
        />
        <CardBody>
            <CardTitle tag="h5" className={styles.carCardTitle}>
                Marka Model
            </CardTitle>
        </CardBody>
        <CardBody className={styles.carCardButtonContent}>
        <a className={`btn btn-primary ${styles.greenLink} ${styles.buttonLink}`}
                href="#">
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