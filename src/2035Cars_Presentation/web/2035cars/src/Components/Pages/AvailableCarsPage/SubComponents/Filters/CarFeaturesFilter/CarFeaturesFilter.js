import React, { useState } from 'react'
import styles from './CarFeaturesFilter.module.css'
import Slider from '@mui/material/Slider'
import { FaFilter } from 'react-icons/fa'
import { AiOutlineArrowDown, AiOutlineCheckSquare, AiFillCheckSquare } from 'react-icons/ai'
import { speedDialActionClasses } from '@mui/material'

function CarFeaturesFilter() {

  const [filterFormState, setFilterFormState] = useState(false)

  const [suvCarTypeChecked, setSuvCarTypeChecked] = useState(false)
  const [sportCarTypeChecked, setSportCarTypeChecked] = useState(false)
  const [convertibleCarTypeChecked, setConvertibleCarTypeChecked] = useState(false)
  const [sedanCarTypeChecked, setSedanCarTypeChecked] = useState(false)

  const [airConditioningChecked, setAirConditioningChecked] = useState(false)
  const [heatedSeatChecked, setHeatedSeatChecked] = useState(false)
  const [automaticGearBoxChecked, setAutomaticGearBoxChecked] = useState(false)
  const [navigationChecked, setNavigationChecked] = useState(false)
  
  const [hybridFuelChecked, setHybridFuelChecked] = useState(false)
  const [electricFuelChecked, setElectricFuelChecked] = useState(false)

  const [sliderVal, setSliderVal] = useState([0,100])

  const updateSlider = (e, data) => {
    setSliderVal(data)
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
                      step={10}
                      value={sliderVal}
                      onChange={updateSlider}
                      getAriaValueText = {getText}
                      valueLabelDisplay='on'
                    />
                  </div>
                  <h4>Od: {sliderVal[0]} Do: {sliderVal[1]}</h4>
                </div>
                <div className={styles.filterFormOptionPart}>
                  <h1>Typ nadwozia:</h1>
                  {RenderCheckableElement(suvCarTypeChecked, setSuvCarTypeChecked, 'Suv')}
                  {RenderCheckableElement(sportCarTypeChecked, setSportCarTypeChecked, 'Sportowy')}
                  {RenderCheckableElement(convertibleCarTypeChecked, setConvertibleCarTypeChecked, 'Kabriolet')}
                  {RenderCheckableElement(sedanCarTypeChecked, setSedanCarTypeChecked, 'Sedan')}
                </div>
                <div className={styles.filterFormOptionPart}>
                  <h1>Wyposażenie</h1>
                  {RenderCheckableElement(airConditioningChecked, setAirConditioningChecked, 'Klimatyzacja')}
                  {RenderCheckableElement(heatedSeatChecked, setHeatedSeatChecked, 'Podgrzewane fotele')}
                  {RenderCheckableElement(automaticGearBoxChecked, setAutomaticGearBoxChecked, 'Automatyczna skrzynia biegów')}
                  {RenderCheckableElement(navigationChecked, setNavigationChecked, 'Wbudowana nawigacja')}
                </div>
                <div className={styles.filterFormOptionPart}>
                  <h1>Typ napędu</h1>
                  {RenderCheckableElement(hybridFuelChecked, setHybridFuelChecked, 'Hybrydowy')}
                  {RenderCheckableElement(electricFuelChecked, setElectricFuelChecked, 'W pełni elektryczny')}
                </div>
                <div className={styles.filterFormOptionPart}>
                  <h1>Ilość drzwi</h1>
                  <select>
                      <option value={1}>2/3</option>
                      <option value={2}>4/5</option>
                  </select>
                  <h1>Ilość miejsc</h1>
                  <select>
                      <option value={1}>2</option>
                      <option value={2}>4</option>
                      <option value={5}>5</option>
                  </select>
                </div>
                <div className={`${styles.submitButtonWrapper} ${styles.filterButtonSpaceBottom}`}>
                    <button className={styles.submitButton}>SZUKAJ</button>
                </div>
            </div>
          </div>
  )
}

export default CarFeaturesFilter