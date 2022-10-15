import React, { useState } from 'react'
import styles from './EmployeeDetails.module.css'
import { Card,
         CardHeader,
         ListGroup,
         ListGroupItem } from 'reactstrap'

import { BsFillTelephoneFill } from 'react-icons/bs'
import { AiFillHome } from 'react-icons/ai'
import { MdEmail, MdWork, MdNetworkCell } from 'react-icons/md'

function EmployeeDetails() {

    useState(() => {
        document.title = 'Pracownik'
    }, [])

  return (
    <div className={styles.wrapper}>
        <div className={styles.cardContent}>
            <Card
                style={{
                    width: '18rem'
                }}
                >
                <CardHeader className={styles.cardHeader}>
                    Imie Nazwisko
                </CardHeader>
                <ListGroup flush>
                    <ListGroupItem>
                        <BsFillTelephoneFill /> 123456789
                    </ListGroupItem>
                    <ListGroupItem>
                        <AiFillHome /> <span>ul. Wesoła 5c/13, 59-100 Poznań</span>
                    </ListGroupItem>
                    <ListGroupItem>
                        <MdEmail /> adresemail@gmail.com
                    </ListGroupItem>
                    <ListGroupItem>
                        <MdWork /> Zarząd
                    </ListGroupItem>
                    <ListGroupItem>
                        <MdNetworkCell /> Menadżer
                    </ListGroupItem>
                    <ListGroupItem className={styles.buttonsRow}>
                        <a className="btn btn-primary">
                            Edytuj
                        </a>
                        <a className='btn btn-danger'>
                            Usuń
                        </a>
                    </ListGroupItem>
                </ListGroup>
            </Card>
        </div>
        <div className={styles.backButtonArea}>
            <a className={`btn btn-outline-primary ${styles.buttonColor}`} style={{ marginBottom: "30px" }}>
                Powrót do listy pracowników
            </a>
        </div>
    </div>
  )
}

export default EmployeeDetails