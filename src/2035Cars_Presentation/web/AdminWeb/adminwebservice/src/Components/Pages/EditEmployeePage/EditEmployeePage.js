import React, { useEffect } from 'react'
import styles from './EditEmployeePage.module.css'
import { Form,
         FormGroup,
         Label,
         Col,
         Input,
         FormText,
         Button } from 'reactstrap'

function EditEmployeePage() {

    useEffect(() => {
        document.title = "Edytuj profil pracownika"
    }, [])

  return (
    <div>
        <div className={styles.formWrapper}>
            <h1 className={styles.pageTitle}>Edytuj profil pracownika</h1>
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
                    placeholder="Podaj imie."
                    type="text"
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
                    placeholder="Podaj model."
                    type="text"
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
                    placeholder="Podaj telefon."
                    type="text"
                    pattern="[0-9]{3}[0-9]{3}[0-9]{3}"
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
                    placeholder="Podaj ulice zamieszkania."
                    type="text"
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
                    placeholder="Podaj nr domu."
                    type="text"
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
                    placeholder="Podaj miasto zamieszkania."
                    type="text"
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
                    placeholder="Podaj kod pocztowy."
                    type="text"
                    pattern="[0-9]{2}[0-9]{3}"
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
                    placeholder="Podaj adres email."
                    type="email"
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
                >
                    <option>
                        Dział Sprzedaży
                    </option>
                    <option>
                        Obsługa klienta
                    </option>
                    <option>
                        Dział Marketingu
                    </option>
                    <option>
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
                >
                    <option>
                        Menadżer
                    </option>
                    <option>
                        Dyrektor
                    </option>
                    <option>
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
                <Button>
                    Submit
                </Button>
                </Col>
            </FormGroup>
            </Form>
        </div>
    </div>
  )
}

export default EditEmployeePage