import React from 'react'

import styles from './Login.module.scss'

const index = () => {
  return (
    <div className={styles.container}>
        <h1 className={styles.title}>Login</h1>
        <div className={styles.username}>
            <p>Username</p>
            <input/>
        </div>
        <div className={styles.password}>
            <p>Password</p>
            <input type='password'/>
        </div>
        <p className={styles.login}>Login</p>
    </div>
  )
}

export default index;
