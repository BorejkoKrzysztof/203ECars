import React, { useState } from 'react'
import styles from './EmployeeDetails.module.css'
import { Card,
         CardHeader,
         ListGroup,
         ListGroupItem } from 'reactstrap'

import { BsFillTelephoneFill } from 'react-icons/bs'
import { AiFillHome } from 'react-icons/ai'
import { MdEmail, MdWork, MdNetworkCell } from 'react-icons/md'
import axios from '../../../axios/axiosAuthorize'

function EmployeeDetails() {

    const [employeeData, setEmployeeData] = useState({})
    const [employeeDataAreLoaded, setEmployeeDataAreLoaded] = useState(false)

    const PrintDepartment = (dep) => {
        switch (dep) {
            case 0:
                return 'Dział Sprzedaży'
            case 1:
                return 'Dział Obsługi klienta'
            case 2:
                return 'Dział marketingu'
            case 3:
                return 'Zarząd'
            default:
                break;
        }
    }

    const removeEmployeeHandler = () => {
        if(window.confirm('Ta akcja spowoduje usunięcie pracownika') == true) {
            axios.delete(`employee/removeemployee/${employeeData.id}`)
                .then(() => {
                    window.location.href = '/pracownicy'
                })
                .catch( (error) => {
                    console.log(error)
                })
        }
    }

    const PrintBusinessPosition = (bp) => {
        switch (bp) {
            case 0:
                return 'Menadżer'
            case 1:
                return 'Dyrektor'
            case 2:
                return 'Pracownik'
            default:
                break;
        }
    }

    const backToListOfEmployeesHandler = () => {
        sessionStorage.removeItem('EmployeeIdForDetails')
        window.location.href = '/pracownicy'
    }

    const donwloadEmployeeDetails = () => {
        const employeeID = sessionStorage.getItem('EmployeeIdForDetails')
        axios.get(`/employee/getemployeedetails/${employeeID}`)
                .then( (response) => {
                    setEmployeeData(response.data)
                    setEmployeeDataAreLoaded(true)
                })
                .catch( (error) => {
                    console.log(error)
                })
    }

    useState(() => {
        document.title = 'Pracownik'
        donwloadEmployeeDetails()
    }, [])

    // // Component Did Unmount
    // useState(() => {
    //     return () => {
    //         sessionStorage.removeItem('EmployeeIdForDetails')
    //     }
    // }, [])

  return (
    <div className={styles.wrapper}>
        <div className={styles.cardContent}>
            {
                employeeDataAreLoaded ?
                <>
                    <Card
                        style={{
                            width: '18rem'
                        }}
                        >
                        <CardHeader className={styles.cardHeader}>
                            {`${employeeData.firstName} ${employeeData.lastName}`}
                        </CardHeader>
                        <ListGroup flush>
                            <ListGroupItem>
                                <BsFillTelephoneFill /> {employeeData.phoneNumber}
                            </ListGroupItem>
                            <ListGroupItem>
                                <AiFillHome /> <span>{`ul. ${employeeData.street} ${employeeData.houseNumber}, ${employeeData.zipCode} ${employeeData.city}`}</span>
                            </ListGroupItem>
                            <ListGroupItem>
                                <MdEmail /> {employeeData.emailAddress}
                            </ListGroupItem>
                            <ListGroupItem>
                                <MdWork /> {PrintDepartment(employeeData.department)}
                            </ListGroupItem>
                            <ListGroupItem>
                                <MdNetworkCell /> {PrintBusinessPosition(employeeData.businessPosition)}
                            </ListGroupItem>
                            <ListGroupItem className={styles.buttonsRow}>
                                {
                                    localStorage.getItem('role') === '0' ?
                                <>
                                    <a className={`btn btn-primary ${styles.buttonFullColor}`}
                                        onClick={() => {
                                            // sessionStorage.setItem('selectedEmployeId', `${employeeData.id}`)
                                            window.location.href = '/edytujpracownika'
                                        }}>
                                        Edytuj
                                    </a>
                                    <a onClick={removeEmployeeHandler} className='btn btn-danger'>
                                        Usuń
                                    </a>
                                </>
                                :
                                <></>
                                }
                            </ListGroupItem>
                        </ListGroup>
                    </Card>
                </>
                :
                <>
                </>
            }
        </div>
        <div className={styles.backButtonArea}>
            <a className={`btn btn-outline-primary ${styles.buttonColor}`} 
                    style={{ marginBottom: "30px" }}
                    onClick={backToListOfEmployeesHandler}>
                Powrót do listy pracowników
            </a>
        </div>
    </div>
  )
}

export default EmployeeDetails