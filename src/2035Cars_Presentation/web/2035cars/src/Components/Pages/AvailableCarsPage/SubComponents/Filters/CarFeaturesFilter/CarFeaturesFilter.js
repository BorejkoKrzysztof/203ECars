import React, { useState } from 'react'
import styles from './CarFeaturesFilter.module.css'
import Slider from '@mui/material/Slider'
import { FaFilter } from 'react-icons/fa'
import { AiOutlineArrowDown, AiOutlineCheckSquare, AiFillCheckSquare } from 'react-icons/ai'

function CarFeaturesFilter(props) {

  const [filterFormState, setFilterFormState] = useState(false)

  // const [suvCarTypeChecked, setSuvCarTypeChecked] = useState(false)
  // const [sportCarTypeChecked, setSportCarTypeChecked] = useState(false)
  // const [compactCarTypeChecked, setCompactCarTypeChecked] = useState(false)
  // const [sedanCarTypeChecked, setSedanCarTypeChecked] = useState(false)

  // const [airConditioningChecked, setAirConditioningChecked] = useState(false)
  // const [heatedSeatChecked, setHeatedSeatChecked] = useState(false)
  // const [automaticGearBoxChecked, setAutomaticGearBoxChecked] = useState(false)
  // const [navigationChecked, setNavigationChecked] = useState(false)
  
  // const [hybridFuelChecked, setHybridFuelChecked] = useState(false)
  // const [electricFuelChecked, setElectricFuelChecked] = useState(false)

  // const [sliderVal, setSliderVal] = useState([0,100])
  const minDistance = props.maxPriceForSlider * 0.1

  const updateSlider = (e, data, activeThumb) => {
    if (!Array.isArray(data)) {
      return;
    }

    if (activeThumb === 0) {
      props.setSliderVal([Math.min(data[0], props.sliderVal[1] - minDistance), props.sliderVal[1]]);
    } else {
      props.setSliderVal([props.sliderVal[0], Math.max(data[1], props.sliderVal[0] + minDistance)]);
    }
    
  }

  function RenderCheckableElement(stateVar, setStateVar, nameOfOption) {

    return (
      <p onClick={() => setStateVar(!stateVar)}>
                    {nameOfOption}
                    <span>
                      {
                          !stateVar ? <AiOutlineCheckSquare /> : <AiFillCheckSquare />
                      }  
                    </span>  
      </p>
    )
  }

  const getText = (value) => `${value}`

  const setAmountOfDoorsHandler = (event) => {
      props.setPreferableAmountOfDoors(event.target.value)
  }

  const setAmountOfSeatsHandler = (event) => {
      props.setPreferableAmountOfSeats(event.target.value)
  }

  const carFeaturesFormHandler = () => {
      props.setSettedFromCarFeaturesForm(true)
  }

  const resetCarFeaturesHandler = () => {
      props.setSliderVal([0, 1000])
      props.setSuvCarTypeChecked(false)
      props.setSportCarTypeChecked(false)
      props.setCompactCarTypeChecked(false)
      props.setSedanCarTypeChecked(false)
      props.setAirConditioningChecked(false)
      props.setHeatedSeatChecked(false)
      props.setAutomaticGearBoxChecked(false)
      props.setNavigationChecked(false)
      props.setHybridFuelChecked(false)
      props.setElectricFuelChecked(false)
      props.setPreferableAmountOfDoors(0)
      props.setPreferableAmountOfSeats(0)
      props.setResetedFromCarFeaturesForm(true)
      props.setShowCarFeaturesFormResetButton(false)
  }

  return (
    <div className={!filterFormState ? 
                            `${styles.otherSettingsFilterContent}` 
                                      : 
                            `${styles.otherSettingsFilterContent} ${styles.otherSettingsFilterContentActive}`}>
            <div className={styles.otherSettingsFilterBar} onClick={() => { setFilterFormState(!filterFormState) }}>
                <div className={styles.filterBarContent}>
                  <FaFilter />
                  <h3>Filtruj</h3>
                </div>
                <AiOutlineArrowDown 
                    className={!filterFormState ? `${styles.filterArrow}` : `${styles.filterArrow} ${styles.filterArrowActive}`}/>
            </div>
            <div className={styles.filterFormWrapper}>
                
                <div className={styles.filterFormOptionPart}>
                  <h1>Cena: </h1>
                  <div className={styles.sliderArea}>
                    <Slider
                      sx={{
                        width: "95%",
                        "& span:nth-of-type(3)": {
                          marginLeft: "12.5px"
                        },
                        "& span:nth-of-type(4)": {
                          marginLeft: "-12px"
                        },
                        "& .MuiSlider-thumb": {
                        height: 24,
                        width: 24,
                        overflow: "hidden",
                      },
                      "& .MuiSlider-rail": {
                        width: "100%",
                        height: "6px",
                      },
                      "& .MuiSlider-track": {
                        width: "100%",
                        height: "6px",
                      }, }}
                      disableSwap
                      step={props.maxPriceForSlider / 20}
                      min={props.minPriceForSlider}
                      max={props.maxPriceForSlider}
                      value={props.sliderVal}
                      onChange={updateSlider}
                      defaultValue={[0, props.maxPriceForSlider]}
                      getAriaValueText = {getText}
                    />
                  </div>
                  <h4>Od: {Math.round((props.sliderVal[0] + Number.EPSILON) * 100) / 100} Do: {Math.round((props.sliderVal[1] + Number.EPSILON) * 100) / 100}</h4>
                </div>
                <div className={styles.filterFormOptionPart}>
                  <h1>Typ nadwozia:</h1>
                  {RenderCheckableElement(props.suvCarTypeChecked, props.setSuvCarTypeChecked, 'Suv')}
                  {RenderCheckableElement(props.sportCarTypeChecked, props.setSportCarTypeChecked, 'Sportowy')}
                  {RenderCheckableElement(props.compactCarTypeChecked, props.setCompactCarTypeChecked, 'Kompakt')}
                  {RenderCheckableElement(props.sedanCarTypeChecked, props.setSedanCarTypeChecked, 'Sedan')}
                </div>
                <div className={styles.filterFormOptionPart}>
                  <h1>Wyposażenie</h1>
                  {RenderCheckableElement(props.airConditioningChecked, props.setAirConditioningChecked, 'Klimatyzacja')}
                  {RenderCheckableElement(props.heatedSeatChecked, props.setHeatedSeatChecked, 'Podgrzewane fotele')}
                  {RenderCheckableElement(props.automaticGearBoxChecked, props.setAutomaticGearBoxChecked, 'Automatyczna skrzynia biegów')}
                  {RenderCheckableElement(props.navigationChecked, props.setNavigationChecked, 'Wbudowana nawigacja')}
                </div>
                <div className={styles.filterFormOptionPart}>
                  <h1>Typ napędu</h1>
                  {RenderCheckableElement(props.hybridFuelChecked, props.setHybridFuelChecked, 'Hybrydowy')}
                  {RenderCheckableElement(props.electricFuelChecked, props.setElectricFuelChecked, 'W pełni elektryczny')}
                </div>
                <div className={styles.filterFormOptionPart}>
                  <h1>Ilość drzwi</h1>
                  <select value={props.preferableAmountOfDoors} onChange={setAmountOfDoorsHandler}>
                      <option value={0}>Wybierz</option>
                      <option value={2}>2/3</option>
                      <option value={4}>4/5</option>
                  </select>
                  <h1>Ilość miejsc</h1>
                  <select value={props.preferableAmountOfSeats} onChange={setAmountOfSeatsHandler}>
                      <option value={0}>Wybierz</option>
                      <option value={2}>2</option>
                      <option value={4}>4</option>
                      <option value={5}>5</option>
                  </select>
                </div>
                <div className={`${styles.submitButtonWrapper} ${styles.filterButtonSpaceBottom}`}>
                    <button className={`${styles.submitButton} ${styles.acceptButton}`}
                              onClick={carFeaturesFormHandler}
                    >SZUKAJ</button>
                    {
                      props.showCarFeaturesFormResetButton ? 
                      <>
                          <button className={`${styles.submitButton} ${styles.cancelButton}`}
                              onClick={resetCarFeaturesHandler}
                          >RESET</button>
                      </>
                      :
                      <></>
                    }
                </div>
            </div>
          </div>
  )
}

export default CarFeaturesFilter