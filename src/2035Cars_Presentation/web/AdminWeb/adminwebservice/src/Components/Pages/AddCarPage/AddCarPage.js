import React, { useEffect, useState } from 'react'
import styles from './AddCarPage.module.css'
import { Form,
         FormGroup,
         Label,
         Col,
         Input,
         FormText,
         Button } from 'reactstrap'
import axios from '../../../axios/axiosFormAuthorize'

function AddCarPage() {

    const onlyLetters = new RegExp("^[A-Za-z]")

    const [brand, setBrand] = useState('')
    const [brandIsValid, setBrandIsValid] = useState(false)

    const [model, setModel] = useState('')
    const [modelIsValid, setmodelIsValid] = useState(false)

    const [carBodyType, setCarBodyType] = useState(0)
    const [fuelType, setFuelType] = useState(0)

    const [image, setImage] = useState(null)
    const [imageIsValid, setImageIsValid] = useState(false)

    const [hasAirConditioning, setHasAirConditioning] = useState(false)
    const [hasHeatingSeats, setHasHeatingSeats] = useState(false)
    const [automaticGearBox, setAutomaticGearBox] = useState(false)
    const [buildInNavigation, setBuildInNavigation] = useState(false)

    const [amountOfDoor, setAmountOfDoor] = useState(0)
    const [amountOfDoorIsValid, setAmountOfDoorIsValid] = useState(false)

    const [amountOfSeats, setAmountOfSeats] = useState(0)
    const [amountOfSeatsIsValid, setAmountOfSeatsIsValid] = useState(false)

    const [priceForHour, setPriceForHour] = useState(0)
    const [priceForHourIsValid, setPriceForHourIsValid] = useState(false)

    const [showErrors, setShowErrors] = useState(false)

    const brandHandler = (event) => {
        setBrand(event.target.value)
    }

    const modelHandler = (event) => {
        setModel(event.target.value)
    }

    const setCarBodyTypeHandler = (event) => {
        setCarBodyType(event.target.value)
    }

    const setFuelTypeHandler = (event) => {
        setFuelType(event.target.value)
    }

    const setImageHandler = (event) => {
        setImage(event.target.files[0])
    }

    const setAirConditioningHandler = () => {
        setHasAirConditioning(prev => { return !prev })
    }

    const setHeatingSeatsHandler = () => {
        setHasHeatingSeats(prev => { return !prev })
    }

    const setAutomaticGearBoxHandler = () => {
        setAutomaticGearBox(prev => { return !prev })
    }

    const setBuildInNavigationHandler = () => {
        setBuildInNavigation(prev => { return !prev })
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

    const addCarFormHandler = (event) => {
        event.preventDefault()

        const rentalId = localStorage.getItem('rentalId')
        const formData = new FormData()

        if(brandIsValid && modelIsValid && amountOfDoorIsValid && 
            amountOfSeatsIsValid && priceForHourIsValid) {
            
            formData.append('RentalId', rentalId)
            formData.append('Brand', brand)
            formData.append('Model', model)
            formData.append('CarType', carBodyType)
            formData.append('DriveType', fuelType)
            formData.append('Image', image)
            formData.append('HasAirConditioning', hasAirConditioning)
            formData.append('HasHeatingSeats', hasHeatingSeats)
            formData.append('HasAutomaticGearBox', automaticGearBox)
            formData.append('HasBuildInNavigation', buildInNavigation)
            formData.append('AmountOfDoor', amountOfDoor)
            formData.append('AmountOfSeats', amountOfSeats)
            formData.append('PriceForHour', priceForHour)

            axios.post(`car/addcartorental`, formData)
                    .then(() => {
                        alert('Samochód został dodany do wypożyczalni!')
                        window.location.href = '/samochody'
                    }).catch( (error) => {
                        console.log(error)
                    })
        } else {
            setShowErrors(true)
        }
    }

    useEffect(() => {
        document.title = "Dodaj samochód"
    }, [])

    useEffect(() => {
        const result = brand.length >= 3 && onlyLetters.test(brand) ? true : false
        setBrandIsValid(result)
    }, [brand])

    useEffect(() => {
        const result = model.length >= 3 ? true : false
        setmodelIsValid(result)
    }, [model])

    useEffect(() => {
        const result = amountOfDoor > 0 ? true : false
        setAmountOfDoorIsValid(result)
    }, [amountOfDoor])

    useEffect(() => {
        const result = amountOfSeats > 0 ? true : false
        setAmountOfSeatsIsValid(result)
    }, [amountOfSeats])

    useEffect(() => {
        const result = priceForHour > 0 ? true : false
        setPriceForHourIsValid(result)
    }, [priceForHour])

    useEffect(() => {
        const result = image !== null ? true : false
        setImageIsValid(result)
    }, [image])

  return (
    <div>
        <div className={styles.formWrapper}>
            <h1 className={styles.pageTitle}>Dodaj nowy samochód</h1>
        <Form className={styles.formContent} onSubmit={addCarFormHandler} encType='multipart/form-data'>
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
                    onChange={brandHandler}
                />
                </Col>
            </FormGroup>
            {
                showErrors && !brandIsValid ? 
                <>
                    <div>
                        <p style={{ color: 'red'}}>
                            Długość marki auta powinna być równa lub dłuższa niż 3 znaki i zawierać same litery.
                        </p>
                    </div>
                </>
                :
                <></>
            }
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
                    onChange={modelHandler}
                />
                </Col>
            </FormGroup>
            {
                showErrors && !modelIsValid ?
                <>
                    <div>
                        <p style={{ color: 'red'}}>
                            Długość modelu auta powinna być równa lub dłuższa niż 3 znaki.
                        </p>
                    </div>
                </>
                :
                <></>
            }
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
                    onChange={setCarBodyTypeHandler}
                >
                    <option value={0}>
                    Suv
                    </option>
                    <option value={1}>
                    Sportowy
                    </option>
                    <option value={2}>
                    Kabriolet
                    </option>
                    <option value={3}>
                    Sedan
                    </option>
                    <option value={4}>
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
                    <option value={0}>
                        Hybrydowy
                    </option>
                    <option value={1}>
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
                    // accept='Image/*'
                    onChange={setImageHandler}
                />
                <FormText>
                    Dodaj zdjęcie samochodu, które będzie wyświetlone na stronie.
                </FormText>
                </Col>
            </FormGroup>
            {
                showErrors && !imageIsValid ?
                <>
                    <div>
                        <p style={{ color: 'red'}}>
                            Musisz wybrać zdjęcie samochodu.
                        </p>
                    </div>
                </>
                :
                <></>
            }
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
                    onChange={setAirConditioningHandler}
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
                    onChange={setHeatingSeatsHandler}
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
                    onChange={setAutomaticGearBoxHandler}
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
                    onChange={setBuildInNavigationHandler}
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
                <Input style={{ width: "25vw"}}
                    id="AmountOfDoor"
                    name="AmountOfDoor"
                    type="number"
                    min="1"
                    onChange={setAmountOfDoorHandler}
                />
                </Col>
            </FormGroup>
            {
                showErrors && !amountOfDoorIsValid ?
                <>
                    <div>
                        <p style={{ color: 'red'}}>
                            Ilość drzwi powinna być większa niż 0.
                        </p>
                    </div>
                </>
                :
                <></>
            }
            <FormGroup row>
                <Label
                for="AmountOfSeats"
                sm={2}
                >
                    Ilość siedzeń
                </Label>
                <Col sm={10}>
                <Input style={{ width: "25vw"}}
                    id="AmountOfSeats"
                    name="AmountOfSeats"
                    type="number"
                    min="1"
                    onChange={setAmountOfSeatsHandler}
                />
                </Col>
            </FormGroup>
            {
                showErrors && !amountOfSeatsIsValid ?
                <>
                    <div>
                        <p style={{ color: 'red'}}>
                            Ilość siedzeń powinna być większa niż 0.
                        </p>
                    </div>
                </>
                :
                <></>
            }
            <FormGroup row>
                <Label
                for="PriceForHour"
                sm={2}
                >
                    Cena za godzinę
                </Label>
                <Col sm={10}>
                <Input style={{ width: "25vw"}}
                    id="PriceForHour"
                    name="PriceForHour"
                    type="number"
                    step="0.01"
                    min="0.00"
                    onChange={setPriceForHourHandler}
                />
                </Col>
                {/* <h1>Złotych</h1> */}
            </FormGroup>
            {
                showErrors && !priceForHourIsValid ?
                <>
                    <div>
                        <p style={{ color: 'red'}}>
                            Cena powinna być większa niż 0.
                        </p>
                    </div>
                </>
                :
                <></>
            }
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
                <Button type='submit'>
                    Dodaj
                </Button>
                </Col>
            </FormGroup>
            </Form>
        </div>
    </div>
  )
}

export default AddCarPage