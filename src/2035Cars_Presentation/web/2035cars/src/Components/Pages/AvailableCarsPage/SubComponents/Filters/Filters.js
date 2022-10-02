import React, { useState } from 'react'
import styles from './Filters.module.css'
import { FaFilter, FaWindowClose } from 'react-icons/fa'
import { AiOutlineArrowDown, AiOutlineCheckSquare, AiFillCheckSquare } from 'react-icons/ai'
import { IoLocationSharp, IoTimeSharp } from 'react-icons/io5'
import { BsFillCalendarDateFill } from 'react-icons/bs'
import Slider from '@mui/material/Slider'


function Filters() {

  const [filterFormState, setFilterFormState] = useState(false)
  const [locationFormState, setLocationFormState] = useState(false)

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

    // console.log(sliderVal[0])
    // console.log(sliderVal[1
  }

  const getText = (value) => `${value}`

  return (
    <>
        <div className={styles.filtersWrapper}>
          <div className={styles.firstFilterWrapper}>
          <div className={ !locationFormState ? 
                                    styles.locationsFilterContent
                                              :
                                    `${styles.locationsFilterContent} ${styles.locationsFilterContentActive}`}>
            <div className={styles.rentCarDetail}>
              <h5>Szczegóły Wynajmu:</h5>
            </div>
            <div className={styles.locationInfo}>
              <h2>
                POCZĄTEK :
              </h2>
              <h6>
                  <IoLocationSharp className={styles.locationInfoIcons}/>
                Miasto Miasto Lokacja
              </h6>
              <p>
                  <BsFillCalendarDateFill className={styles.locationInfoIcons}/>
                12.08.2022 &nbsp;
                  <IoTimeSharp className={styles.locationInfoIcons}/>
                10:00
              </p>
            </div>
            <hr className={styles.locationInfoSeparateLine}/>
            <div className={styles.locationInfo}>
              <h2>
                KONIEC :
              </h2>
              <h6>
                  <IoLocationSharp className={styles.locationInfoIcons}/>
                Miasto Miasto Lokacja
              </h6>
              <p>
                  <BsFillCalendarDateFill className={styles.locationInfoIcons}/>
                12.08.2022 &nbsp;
                  <IoTimeSharp className={styles.locationInfoIcons}/>
                10:00
              </p>
            </div>
            <div className={styles.locationFormOpenButtonWrapper}>
              <button className={styles.themeButton} 
                  onClick={() => { setLocationFormState(true) }}>EDYTUJ</button>
            </div>
          </div>
          

          <div className={!locationFormState ? 
                              `${styles.locationFormWrapper}`
                                              :
                              `${styles.locationFormWrapper} ${styles.locationFormWrapperActive}`}>
              <div className={styles.closeLoactionFormButtonArea}>
                <h5>Edytuj datę:</h5>
                <button className={styles.closeLocationFormButton}
                          onClick={() => { setLocationFormState(false) }}>
                  <FaWindowClose />
                </button>
              </div>
              <form className={styles.editDateTimeRent}>
                  <div className={styles.locationInfoForm}>
                    <label>POCZĄTEK :</label>
                    <select></select>
                  </div>
                  <div className={styles.locationInfoForm}>
                    <label>KONIEC :</label>
                    <select></select>
                  </div>
                  <div className={styles.locationInfoForm}>
                    <label>DATA ROZPOCZĘCIA :</label>
                      <div>
                        <input type='date'></input>
                        <select></select>
                      </div>
                  </div>
                  <div className={styles.locationInfoForm}>
                    <label>DATA ZAKOŃCZENIA :</label>
                      <div>
                        <input type='date'></input>
                        <select></select>
                      </div>
                  </div>
                  <div className={styles.submitButtonWrapper}>
                    <button className={styles.submitButton}>EDYTUJ</button>
                  </div>
              </form>
          </div>
          </div>


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
                  <p onClick={() => setSuvCarTypeChecked(!suvCarTypeChecked)}>
                    Suv
                    <span>
                      {
                          !suvCarTypeChecked ? <AiOutlineCheckSquare /> : <AiFillCheckSquare />
                      }  
                    </span>  
                  </p>
                  <p onClick={() => setSportCarTypeChecked(!sportCarTypeChecked)}>
                    Sportowy
                    <span>
                      {
                          !sportCarTypeChecked ? <AiOutlineCheckSquare /> : <AiFillCheckSquare />
                      }  
                    </span>  
                  </p>
                  <p onClick={() => setConvertibleCarTypeChecked(!convertibleCarTypeChecked)}>
                    Kabriolet
                    <span>
                      {
                          !convertibleCarTypeChecked ? <AiOutlineCheckSquare /> : <AiFillCheckSquare />
                      }  
                    </span>  
                  </p>
                  <p onClick={() => setSedanCarTypeChecked(!sedanCarTypeChecked)}>
                    Sedan
                    <span>
                      {
                          !sedanCarTypeChecked ? <AiOutlineCheckSquare /> : <AiFillCheckSquare />
                      }  
                    </span>  
                  </p>
                </div>
                <div className={styles.filterFormOptionPart}>
                  <h1>Wyposażenie</h1>
                  <p onClick={() => setAirConditioningChecked(!airConditioningChecked)}>
                    Klimatyzacja
                    <span>
                      {
                          !airConditioningChecked ? <AiOutlineCheckSquare /> : <AiFillCheckSquare />
                      }  
                    </span>  
                  </p>
                  <p onClick={() => setHeatedSeatChecked(!heatedSeatChecked)}>
                    Podgrzewane fotele
                    <span>
                      {
                          !heatedSeatChecked ? <AiOutlineCheckSquare /> : <AiFillCheckSquare />
                      }  
                    </span>  
                  </p>
                  <p onClick={() => setAutomaticGearBoxChecked(!automaticGearBoxChecked)}>
                    Automatyczna skrzynia biegów
                    <span>
                      {
                          !automaticGearBoxChecked ? <AiOutlineCheckSquare /> : <AiFillCheckSquare />
                      }  
                    </span>  
                  </p>
                  <p onClick={() => setNavigationChecked(!navigationChecked)}>
                    Wbudowana nawigacja
                    <span>
                      {
                          !navigationChecked ? <AiOutlineCheckSquare /> : <AiFillCheckSquare />
                      }  
                    </span>  
                  </p>
                </div>
                <div className={styles.filterFormOptionPart}>
                  <h1>Typ napędu</h1>
                  <p onClick={() => setHybridFuelChecked(!hybridFuelChecked)}>
                    Hybrydowy
                    <span>
                      {
                          !hybridFuelChecked ? <AiOutlineCheckSquare /> : <AiFillCheckSquare />
                      }  
                    </span>  
                  </p>
                  <p onClick={() => setElectricFuelChecked(!electricFuelChecked)}>
                    W pełni elektryczny
                    <span>
                      {
                          !electricFuelChecked ? <AiOutlineCheckSquare /> : <AiFillCheckSquare />
                      }  
                    </span>  
                  </p>
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
        </div>
    </>
  )
}

export default Filters