import React from 'react'
import styles from './Footer.module.css'
import { FaCar } from 'react-icons/fa'
import { MenuItems } from '../Navbar/menuitems.js'
import { Link } from 'react-router-dom'
import { AiFillFacebook, AiFillTwitterSquare, AiFillInstagram } from 'react-icons/ai'

function Footer() {
  return (
    <div className={styles.footer}>
        <div className={styles.footerMain}>
          <div className={styles.footerBanner}>
            <h1 className={styles.footerLogo}  style={{ fontFamily: '"Quantico"'}}>
              <span>
                <FaCar />
              </span>
              &nbsp;/ 203E Cars
            </h1>
            <p className={styles.footerDescriptionParagraph}>
                Find the cheapest car rental deals in the Entire EU. Search, 
                compare and book to hire a car at economical rates. Save environment by
                choosing electric car.
            </p>
          </div>
          <div>
            <ul className={styles.footerNav}>
                {
                  MenuItems.map((item, index) => {
                    return(
                      <li key={index}>
                        <Link to={item.Url}>{item.Title}</Link>
                      </li>
                    )
                  })
                }
            </ul>
          </div>
          <div className={styles.socialsSection}>
                <a href='https://www.facebook.com/'>
                  <AiFillFacebook />
                </a>
                <a href='https://twitter.com/'>
                  <AiFillTwitterSquare />
                </a>
                <a href='https://www.instagram.com/'>
                  <AiFillInstagram />
                </a>
          </div>
        </div>
        <div className={styles.postDescription}>
              <h4>2023 203ECars All Rights Reserved</h4>
        </div>
    </div>
  )
}

export default Footer