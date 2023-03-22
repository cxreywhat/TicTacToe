import React from 'react'

import styles from './Register.module.scss'

const index = () => {
  return (
    <div className={styles.container}>
        <h1 className={styles.title}>Register</h1>
        <div className={styles.username}>
            <p>Username</p>
            <input/>
        </div>
        <div className={styles.password}>
            <p>Password</p>
            <input type='password'/>
        </div>
        <div className={styles.repeat_passowrd}>
            <p>Repeat password</p>
            <input type='password'/>
        </div>
        <p className={styles.register}>Register</p>
    </div>
  )
}

export default index;
