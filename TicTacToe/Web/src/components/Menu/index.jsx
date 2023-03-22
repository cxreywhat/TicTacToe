import React from 'react'

import styles from './Menu.module.scss'

const index = () => {
  return (
    <div>
        <div className={styles.container}>
            <h1 className={styles.title}>Menu</h1>
            <p className={styles.play}>Play</p>
            <p className={styles.invites}>Invites</p>
            <p className={styles.stats}>Stats</p>
        </div>
        <div className={styles.footer}>
            <div className={styles.top}>
                <img src='./img/top.svg' alt='top'/>
                <p>Top 10</p>
            </div>
            <div className={styles.profle}>
                <img src='./img/profile.svg' alt='profile'/>
                <p>Profile</p>
            </div>
            <div className={styles.settings}>
                <img src='./img/settings.svg' alt='settings'/>
                <p>Settings</p>
            </div>
        </div>
    </div>
  )
}

export default index