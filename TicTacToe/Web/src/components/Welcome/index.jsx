import React from 'react'

import styles from './Welcome.module.scss'

const index = () => {
  return (
    <div className={styles.welcome_menu}>
        <h1 className={styles.title}>Welcome</h1>
        <img className={styles.logo} src="./img/logo.svg" alt="logo"></img>
        <p className={styles.login}>Login</p>
        <p className={styles.register}>Register</p>
    </div>
  )
}

export default index;
