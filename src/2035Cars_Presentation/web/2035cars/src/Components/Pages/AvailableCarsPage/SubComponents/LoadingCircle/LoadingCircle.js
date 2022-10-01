import React from 'react'
import styles from './LoadingCircle.module.css'
import { AiOutlineLoading3Quarters } from 'react-icons/ai'

function LoadingCircle() {
  return (
    <div className={styles.loadingCircleWrapper}>
        <p className={styles.circleParagraph}>
          <AiOutlineLoading3Quarters />
        </p>
    </div>
  )
}

export default LoadingCircle