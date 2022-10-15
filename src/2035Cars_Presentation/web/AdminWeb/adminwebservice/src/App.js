import './App.css';
import NavbarService from './Components/Navbar/NavbarService';
import Footer from './Components/Footer/Footer';
import LoginPage from './Components/Pages/LoginPage/LoginPage'
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom';
import Register from './Components/Pages/RegisterPage/RegisterPage';
import EmployeeListPage from './Components/Pages/EmployeeListPage/EmployeeListPage';
import EmployeeDetails from './Components/Pages/EmployeeDetails/EmployeeDetails';
import CarListPage from './Components/Pages/CarListPage/CarListPage';
import CarDetailsPage from './Components/Pages/CarDetailsPage/CarDetailsPage';
import AddCarPage from './Components/Pages/AddCarPage/AddCarPage';

function App() {
  return (
    <Router>
      <NavbarService />
        <Routes>
          {/* <Route path='/' element={<LoginPage />}/> */}
          {/* <Route path='/rejestracja' element={<Register />} /> */}
          {/* <Route path='/' element={<EmployeeListPage />} /> */}
          {/* <Route path='/' element={<EmployeeDetails />} /> */}
          {/* <Route path='/' element={<CarListPage />} /> */}
          {/* <Route path='/' element={<CarDetailsPage />}/> */}
          <Route path='/' element={<AddCarPage />}/>
        </Routes>
      <Footer />
    </Router>
  );
}

export default App;
