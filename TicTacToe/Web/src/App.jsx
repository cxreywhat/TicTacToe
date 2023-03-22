import {Routes, Route} from 'react-router-dom';

import Welcome from "./components/Welcome"
import Register from "./components/Register"
import Login from "./components/Login"
import Menu from "./components/Menu"

import './App.scss';

const App = () => {
  return (
    <div className="wrapper">
        <div className='container'>
            <Routes>
                <Route path="/welcome" element={<Welcome/>}/>
                <Route path="/register" element={<Register/>}/>
                <Route path="/login" element={<Login/>}/>
                <Route path="/menu" element={<Menu/>}/>
            </Routes>
        </div>
    </div>
  );
}

export default App;
