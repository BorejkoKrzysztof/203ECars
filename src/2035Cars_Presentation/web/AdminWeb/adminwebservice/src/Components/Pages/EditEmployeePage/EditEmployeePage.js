import React, { useEffect, useState } from 'react'
import styles from './EditEmployeePage.module.css'
import { Form,
         FormGroup,
         Label,
         Col,
         Input,
         Button } from 'reactstrap'
import axios from '../../../axios/axiosAuthorize'

function EditEmployeePage() {

    const [employee, setEmployee] = useState()
    const [employeeDataAreLoaded, setEmployeeDataAreLoaded] = useState(false)

    const [firstName, setFirstName] = useState(null)
    const [lastName, setLastName] = useState(null)
    const [phoneNumber, setPhoneNumber] = useState(null)
    const [street, setStreet] = useState(null)
    const [houseNumber, setHouseNumber] = useState(null)
    const [city, setCity] = useState(null)
    const [zipCode, setZipCode] = useState(null)
    const [emailAddress, setEmailAddress] = useState(null)
    const [department, setDepartment] = useState(-1)
    const [businessPosition, setBusinessPosition] = useState(-1)


    const setFirstNameHandler = (event) => {
        setFirstName(event.target.value)
    }

    const setLastNameHandler = (event) => {
        setLastName(event.target.value)
    }

    const setPhoneNumberHandler = (event) => {
        setPhoneNumber(event.target.value)
    }

    const setStreetHandler = (event) => {
        setStreet(event.target.value)
    }

    const setHouseNumberHandler = (event) => {
        setHouseNumber(event.target.value)
    }

    const setCityHandler = (event) => {
        setCity(event.target.value)
    }

    const setZipCodeHandler = (event) => {
        setZipCode(event.target.value)
    }

    const setEmailAddressHandler = (event) => {
        setEmailAddress(event.target.value)
    }

    const setDepartmentHandler = (event) => {
        setDepartment(event.target.value)
    }

    const setBusinessPositionHandler = (event) => {
        setBusinessPosition(event.target.value)
    }

    const donwloadEmployeeInfo = () => {
        const employeeId = sessionStorage.getItem('EmployeeIdForDetails')

        axios.get(`/employee/getemployeedetails/${employeeId}`)
                .then( (response) => {
                    setEmployee(response.data)
                    setEmployeeDataAreLoaded(true)
                })
                .catch( (error) => {
                    console.log(error)
                })
    }

    const performEditEmployeeFormHandler = () => {

        axios.post('employee/editemployee', JSON.stringify({
            Id: employee.id,
            FirstName: firstName,
            LastName: lastName,
            PhoneNumber: phoneNumber,
            Street: street,
            HouseNumber: houseNumber,
            City: city,
            ZipCode: zipCode,
            EmailAddress: emailAddress,
            Department: department,
            BusinessPosition: businessPosition
        })).then( () => {
            sessionStorage.removeItem('EmployeeIdForDetails')
            alert('Dane pracownika zostały zmodyfikowane!')
            window.location.href = '/pracownicy'
        }).catch( (error) => {
            console.log(error)
        })
    }

    useEffect(() => {
        document.title = "Edytuj profil pracownika"
        donwloadEmployeeInfo()
    }, [])

    // // Component Did Unmount
    // useEffect(() => {
    //     return () => {
    //         sessionStorage.removeItem('EmployeeIdForDetails')
    //     }
    // }, [])

  return (
    <div>
        <div className={styles.formWrapper}>
            <h1 className={styles.pageTitle}>Edytuj profil pracownika</h1>
            {
                employeeDataAreLoaded ? 
                <>
                    <Form className={styles.formContent}>
                        <FormGroup row>
                            <Label
                            for="firstName"
                            sm={2}
                            >
                            Imie
                            </Label>
                            <Col sm={10}>
                            <Input
                                id="firstName"
                                name="firstName"
                                placeholder={`${employee.firstName}`}
                                type="text"
                                onChange={setFirstNameHandler}
                            />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label
                            for="lastName"
                            sm={2}
                            >
                            Nazwisko
                            </Label>
                            <Col sm={10}>
                            <Input
                                id="lastName"
                                name="lastName"
                                placeholder={`${employee.lastName}`}
                                type="text"
                                onChange={setLastNameHandler}
                            />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label
                            for="phone"
                            sm={2}
                            >
                            Numer telefonu
                            </Label>
                            <Col sm={10}>
                            <Input
                                id="phone"
                                name="phone"
                                placeholder={`${employee.phoneNumber}`}
                                type="text"
                                pattern="[0-9]{3}[0-9]{3}[0-9]{3}"
                                onChange={setPhoneNumberHandler}
                            />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label
                            for="Street"
                            sm={2}
                            >
                            Ulica
                            </Label>
                            <Col sm={10}>
                            <Input
                                id="Street"
                                name="Street"
                                placeholder={`${employee.street}`}
                                type="text"
                                onChange={setStreetHandler}
                            />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label
                            for="numberOfHome"
                            sm={2}
                            >
                            Numer domu
                            </Label>
                            <Col sm={10}>
                            <Input
                                id="numberOfHome"
                                name="numberOfHome"
                                placeholder={`${employee.houseNumber}`}
                                type="text"
                                onChange={setHouseNumberHandler}
                            />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label
                            for="City"
                            sm={2}
                            >
                            Miasto
                            </Label>
                            <Col sm={10}>
                            <Input
                                id="City"
                                name="City"
                                placeholder={`${employee.city}`}
                                type="text"
                                onChange={setCityHandler}
                            />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label
                            for="postalCode"
                            sm={2}
                            >
                            Kod pocztowy
                            </Label>
                            <Col sm={10}>
                            <Input
                                id="postalCode"
                                name="postalCode"
                                placeholder={`${employee.zipCode}`}
                                type="text"
                                pattern="[0-9]{2}[0-9]{3}"
                                onChange={setZipCodeHandler}
                            />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label
                            for="Email"
                            sm={2}
                            >
                            Adres Email
                            </Label>
                            <Col sm={10}>
                            <Input
                                id="Email"
                                name="Email"
                                placeholder={`${employee.emailAddress}`}
                                type="email"
                                onChange={setEmailAddressHandler}
                            />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label
                            for="Department"
                            sm={2}
                            >
                            Dział
                            </Label>
                            <Col sm={10}>
                            <Input
                                id="Department"
                                name="Department"
                                type="select"
                                onChange={setDepartmentHandler}
                            >
                                <option selected={employee.department === 0} value={0}>
                                    Dział Sprzedaży
                                </option>
                                <option selected={employee.department === 1} value={1}>
                                    Obsługa klienta
                                </option>
                                <option selected={employee.department === 2} value={2}>
                                    Dział Marketingu
                                </option>
                                <option selected={employee.department === 3} value={3}>
                                    Zarząd
                                </option>
                            </Input>
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label
                            for="BuisnessPosition"
                            sm={2}
                            >
                            Stanowisko
                            </Label>
                            <Col sm={10}>
                            <Input
                                id="BuisnessPosition"
                                name="BuisnessPosition"
                                type="select"
                                onChange={setBusinessPositionHandler}
                            >
                                <option selected={employee.businessPosition === 0} value={0}>
                                    Menadżer
                                </option>
                                <option selected={employee.businessPosition === 1} value={1}>
                                    Dyrektor
                                </option>
                                <option selected={employee.businessPosition === 2} value={2}>
                                    Pracownik
                                </option>
                            </Input>
                            </Col>
                        </FormGroup>
                        <FormGroup
                            check
                            row
                        >
                            <Col
                            sm={{
                                offset: 2,
                                size: 10
                            }}
                            >
                            <Button onClick={performEditEmployeeFormHandler}>
                                Edytuj
                            </Button>
                            </Col>
                        </FormGroup>
                        </Form>
                </>
                :
                <></>
            }
        </div>
    </div>
  )
}

export default EditEmployeePage