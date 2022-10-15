import './App.css';
import NavbarService from './Components/Navbar/NavbarService';
import Footer from './Components/Footer/Footer';
import LoginPage from './Components/Pages/LoginPage/LoginPage'
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom';
import Register from './Components/Pages/RegisterPage/RegisterPage';
import EmployeeListPage from './Components/Pages/EmployeeListPage/EmployeeListPage';
import EmployeeDetails from './Components/Pages/EmployeeDetails/EmployeeDetails';

function App() {
  return (
    <Router>
      <NavbarService />
        <Routes>
          {/* <Route path='/' element={<LoginPage />}/> */}
          {/* <Route path='/rejestracja' element={<Register />} /> */}
          {/* <Route path='/' element={<EmployeeListPage />} /> */}
          <Route path='/' element={<EmployeeDetails />} />
        </Routes>
      <Footer />
    </Router>
  );
}

export default App;
