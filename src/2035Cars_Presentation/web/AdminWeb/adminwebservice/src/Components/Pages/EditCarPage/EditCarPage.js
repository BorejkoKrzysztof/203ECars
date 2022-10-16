import React, { useEffect } from 'react'
import styles from './EditCarPage.module.css'
import { Form,
         FormGroup,
         Label,
         Col,
         Input,
         FormText,
         Button } from 'reactstrap'

function EditCarPage() {

    useEffect(() => {
        document.title = "Edytuj samochód"
    }, [])

  return (
    <div>
        <div className={styles.formWrapper}>
            <h1 className={styles.pageTitle}>Edytuj samochód</h1>
        <Form className={styles.formContent}>
            <FormGroup row>
                <Label
                for="Brand"
                sm={2}
                >
                Marka
                </Label>
                <Col sm={10}>
                <Input
                    id="Brand"
                    name="Marka"
                    placeholder="Podaj markę."
                    type="text"
                />
                </Col>
            </FormGroup>
            <FormGroup row>
                <Label
                for="Model"
                sm={2}
                >
                Model
                </Label>
                <Col sm={10}>
                <Input
                    id="Model"
                    name="Model"
                    placeholder="Podaj model."
                    type="text"
                />
                </Col>
            </FormGroup>
            <FormGroup row>
                <Label
                for="CarType"
                sm={2}
                >
                Typ nadwozia
                </Label>
                <Col sm={10}>
                <Input
                    id="CarType"
                    name="CarType"
                    type="select"
                >
                    <option>
                    Suv
                    </option>
                    <option>
                    Sportowy
                    </option>
                    <option>
                    Kabriolet
                    </option>
                    <option>
                    Sedan
                    </option>
                </Input>
                </Col>
            </FormGroup>
            <FormGroup row>
                <Label
                for="DriveType"
                sm={2}
                >
                Typ napędu
                </Label>
                <Col sm={10}>
                <Input
                    id="DriveType"
                    name="DriveType"
                    type="select"
                >
                    <option>
                        Hybrydowy
                    </option>
                    <option>
                        Elektryczny
                    </option>
                </Input>
                </Col>
            </FormGroup>
            <FormGroup row>
                <Label
                for="Image"
                sm={2}
                >
                Zdjęcie
                </Label>
                <Col sm={10}>
                <Input
                    id="Image"
                    name="Image"
                    type="file"
                />
                <FormText>
                    Dodaj zdjęcie samochodu, które będzie wyświetlone na stronie.
                </FormText>
                </Col>
            </FormGroup>
            <FormGroup row>
                <Label
                // for="checkbox2"
                sm={2}
                >
                Wyposażenie
                </Label>
                <Col
                sm={{
                    size: 10
                }}
                >
                <FormGroup check>
                    <Input
                    id="HasAirCoolingCheckbox"
                    type="checkbox"
                    />
                    {' '}
                    <Label check>
                        Klimatyzacja
                    </Label>
                </FormGroup>
                <FormGroup check>
                    <Input
                    id="HasHeatingSeatsCheckbox"
                    type="checkbox"
                    />
                    {' '}
                    <Label check>
                        Podgrzewanie siedzenia
                    </Label>
                </FormGroup>
                <FormGroup check>
                    <Input
                    id="HasAutomaticGearBoxCheckbox"
                    type="checkbox"
                    />
                    {' '}
                    <Label check>
                        Automatyczna skrzynia biegów
                    </Label>
                </FormGroup>
                <FormGroup check>
                    <Input
                    id="HasBuildInNavigation"
                    type="checkbox"
                    />
                    {' '}
                    <Label check>
                        Wbudowana nawigacja
                    </Label>
                </FormGroup>
                </Col>
            </FormGroup>
            <FormGroup row>
                <Label
                for="AmountOfDoor"
                sm={2}
                >
                    Ilość drzwi
                </Label>
                <Col sm={10}>
                <Input style={{ width: "15vw"}}
                    id="AmountOfDoor"
                    name="AmountOfDoor"
                    // placeholder="Podaj model."
                    type="number"
                    min="1"
                />
                </Col>
            </FormGroup>
            <FormGroup row>
                <Label
                for="AmountOfSeats"
                sm={2}
                >
                    Ilość siedzeń
                </Label>
                <Col sm={10}>
                <Input style={{ width: "15vw"}}
                    id="AmountOfSeats"
                    name="AmountOfSeats"
                    // placeholder="Podaj model."
                    type="number"
                    min="1"
                />
                </Col>
            </FormGroup>
            <FormGroup row>
                <Label
                for="PriceForHour"
                sm={2}
                >
                    Cena za godzinę
                </Label>
                <Col sm={10}>
                <Input style={{ width: "15vw"}}
                    id="PriceForHour"
                    name="PriceForHour"
                    // placeholder="Podaj model."
                    type="number"
                    step="0.01"
                    min="0.00"
                />
                </Col>
                {/* <h1>Złotych</h1> */}
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

export default EditCarPage