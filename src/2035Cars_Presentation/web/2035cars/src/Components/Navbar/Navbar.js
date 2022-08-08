import React, { useState } from 'react'
import styles from './Navbar.module.css'
import { FaCar } from 'react-icons/fa'
import { HiOutlineMenu } from 'react-icons/hi'
import { GrClose } from 'react-icons/gr'
import { MenuItems } from './menuitems.js'
import { Link } from 'react-router-dom'


function Navbar() {

  const [menuSwitch, setMenuSwitch] = useState(false)


  const switchMenuHandler = () => {
    if  (window.outerWidth <= 960)
    {
      setMenuSwitch(!menuSwitch)
    }
  }
  
  return (
    <div className={styles.navbar}>
        <div className={styles.companyTitle}>
            <p className={styles.carLogo}>
                <FaCar />
            </p>
            <p>
                <span>&nbsp;/&nbsp;</span>
                <span style={{ fontFamily: '"Quantico"'}} className={styles.greyTitle}>203</span>
                <span style={{ fontFamily: '"Quantico"'}} className={styles.blueTitle}>E</span>
                <span style={{ fontFamily: '"Quantico"'}} className={styles.blueTitle}> Cars</span>
            </p>
        </div>
        <div className={!menuSwitch ? 
                    `${styles.navbarMenu}`
                      :
                    `${styles.navbarMenu} ${styles.navbarMenuActive}`}>
          
            <div>
              <ul className={styles.hiddenMenuNavList}>
                {
                  MenuItems.map((item, index) => {
                    return (
                      <li className={styles.menuItem}
                          key={index}>
                          <Link to={item.Url} onClick={switchMenuHandler}>
                              {item.Title}
                          </Link>
                      </li>
                    )
                  })
                }
              </ul>
            </div>
        </div>
        <button className={styles.hiddenMenuButton}
                  onClick={switchMenuHandler}>
          {
            !menuSwitch ? 
                <HiOutlineMenu />
                        :
                <GrClose />
          }
        </button>
    </div>
  )
}

export default Navbar