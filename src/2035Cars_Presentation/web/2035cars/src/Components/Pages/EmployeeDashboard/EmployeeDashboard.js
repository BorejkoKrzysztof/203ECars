import React, { useEffect } from 'react'
import styles from './EmployeeDashboard.module.css'

function EmployeeDashboard() {

    useEffect(() => {
        document.title = 'Dashboard'
    }, [])

    
  return (
    <div className={styles.dashboardWrapper}>
        <div>

        </div>
    </div>
  )
}

export default EmployeeDashboard