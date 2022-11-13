import React, { useEffect, useState } from 'react'
import styles from './EditCarPage.module.css'
import { Form,
         FormGroup,
         Label,
         Col,
         Input,
         FormText,
         Button } from 'reactstrap'
import axios from '../../../axios/axiosAuthorize'
import axiosForm from '../../../axios/axiosFormAuthorize'

function EditCarPage() {

    const [carInfo, setCarInfo] = useState({})

    const [brand, setBrand] = useState(null)
    const [model, setModel] = useState(null)
    const [carType, setCarType] = useState(-1)
    const [fuelType, setFuelType] = useState(-1)
    const [image, setImage] = useState(null)
    const [hasAirCooling, setHasAirCooling] = useState(false)
    const [hasHeatingSeats, setHasHeatingSeats] = useState(false)
    const [hasAutomaticGearBox, setHasAutomaticGerBox] = useState(false)
    const [hasBuildInNavigation, setHasBuildInNavigation] = useState(false)
    const [amountOfDoor, setAmountOfDoor] = useState(-1)
    const [amountOfSeats, setAmountOfSeats] = useState(-1)
    const [priceForHour, setPriceForHour] = useState(-1)

    const setBrandHandler = (event) => {
        setBrand(event.target.value)
    }

    const setModelHandler = (event) => {
        setModel(event.target.value)
    }

    const setCarTypeHandler = (event) => {
        setCarType(event.target.value)
    }

    const setFuelTypeHandler = (event) => {
        setFuelType(event.target.value)
    }

    const setImageHandler = (event) => {
        setImage(event.target.files[0])
    }

    const setHasAirCoolingHandler = () => {
        setHasAirCooling(prev => {
            return !prev
        })
    }

    const setHasHeatingSeatsHandler = () => {
        setHasHeatingSeats(prev => {
            return !prev
        })
    }

    const setHasAutomaticGerBoxHandler = () => {
        setHasAutomaticGerBox(prev => {
            return !prev
        })
    }

    const setHasBuildInNavigationHandler = () => {
        setHasBuildInNavigation(prev => {
            return !prev
        })
    }

    const setAmountOfDoorHandler = (event) => {
        setAmountOfDoor(event.target.value)
    }

    const setAmountOfSeatsHandler = (event) => {
        setAmountOfSeats(event.target.value)
    }

    const setPriceForHourHandler = (event) => {
        setPriceForHour(event.target.value)
    }

    const donwloadCarInfo = () => {
        const carId = sessionStorage.getItem('CarToEditId')
        axios.get(`car/getcarinfo/${carId}`)
                .then( (response) => {
                    setCarInfo(response.data)
                    setHasAirCooling(response.data.hasAirCooling)
                    setHasHeatingSeats(response.data.hasHeatingSeats)
                    setHasAutomaticGerBox(response.data.hasAutomaticGearBox)
                    setHasBuildInNavigation(response.data.hasBuildInNavigation)
                })
                .catch( (error) => {
                    console.log(error)
                })
    }

    const editCarFormHandler = () => {
        const carId = sessionStorage.getItem('CarToEditId')
        const formData = new FormData()

        formData.append('CarId', carId)
        formData.append('Brand', brand)
        formData.append('Model', model)
        formData.append('CarType', carType)
        formData.append('DriveType', fuelType)
        formData.append('Image', image)
        formData.append('HasAirConditioning', hasAirCooling)
        formData.append('HasHeatingSeats', hasHeatingSeats)
        formData.append('HasAutomaticGearBox', hasAutomaticGearBox)
        formData.append('HasBuildInNavigation', hasBuildInNavigation)
        formData.append('AmountOfDoor', amountOfDoor)
        formData.append('AmountOfSeats', amountOfSeats)
        formData.append('PriceForHour', priceForHour)

        axiosForm.put(`car/editcar`, formData)
                .then( () => {
                    alert('Samochód został zmodyfikowany!')
                    sessionStorage.removeItem('CarToEditId')
                    window.location.href = '/samochody'
                }).catch( (error) => {
                    console.log(error)
                })
    }

    useEffect(() => {
        document.title = "Edytuj samochód"
        donwloadCarInfo()
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
                    placeholder={`${carInfo.brand}`}
                    type="text"
                    onChange={setBrandHandler}
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
                    placeholder={`${carInfo.model}`}
                    type="text"
                    onChange={setModelHandler}
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
                    onChange={setCarTypeHandler}
                >
                    <option selected={carInfo.carType === 0} value={0}>
                        Suv
                    </option>
                    <option selected={carInfo.carType === 1} value={1}>
                        Sportowy
                    </option>
                    <option selected={carInfo.carType === 2} value={2}>
                        Kabriolet
                    </option>
                    <option selected={carInfo.carType === 3} value={3}>
                        Sedan
                    </option>
                    <option selected={carInfo.carType === 4} value={4}>
                        Kompakt
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
                    onChange={setFuelTypeHandler}
                >
                    <option selected={carInfo.driveType === 0} value={0}>
                        Hybrydowy
                    </option>
                    <option selected={carInfo.driveType === 1} value={1}>
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
                    onChange={setImageHandler}
                />
                <FormText>
                    Zmień zdjęcie samochodu, które będzie wyświetlone na stronie.
                </FormText>
                </Col>
            </FormGroup>
            <FormGroup row>
                <Label
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
                    defaultChecked={carInfo.hasAirCooling}
                    onChange={setHasAirCoolingHandler}
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
                    defaultChecked={carInfo.hasHeatingSeats}
                    onChange={setHasHeatingSeatsHandler}
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
                    defaultChecked={carInfo.hasAutomaticGearBox}
                    onChange={setHasAutomaticGerBoxHandler}
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
                    defaultChecked={carInfo.hasBuildInNavigation}
                    onChange={setHasBuildInNavigationHandler}
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
                    type="number"
                    placeholder={`${carInfo.amountOfDoor}`}
                    min="1"
                    onChange={setAmountOfDoorHandler}
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
                    type="number"
                    min="1"
                    placeholder={`${carInfo.amountOfSeats}`}
                    onChange={setAmountOfSeatsHandler}
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
                    type="number"
                    step="0.01"
                    min="0.00"
                    placeholder={`${carInfo.priceForRental}`}
                    onChange={setPriceForHourHandler}
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
                <Button onClick={editCarFormHandler}>
                    Edytuj
                </Button>
                </Col>
            </FormGroup>
            </Form>
        </div>
    </div>
  )
}

export default EditCarPage