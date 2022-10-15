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
            <CardLink href="#">
            Card Link
            </CardLink>
            <CardLink href="#">
            Another Card Link
            </CardLink>
        </CardBody>
    </Card>
  )
}

export default CarCard