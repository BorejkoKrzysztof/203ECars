import './App.css';
import NavbarService from './Components/Navbar/NavbarService';
import Footer from './Components/Footer/Footer';
import LoginPage from './Components/Pages/LoginPage/LoginPage'
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom';
import Register from './Components/Pages/RegisterPage/RegisterPage';
import EmployeeListPage from './Components/Pages/EmployeeListPage/EmployeeListPage';

function App() {
  return (
    <Router>
      <NavbarService />
        <Routes>
          {/* <Route path='/' element={<LoginPage />}/> */}
          {/* <Route path='/rejestracja' element={<Register />} /> */}
          <Route path='/' element={<EmployeeListPage />} />
        </Routes>
      <Footer />
    </Router>
  );
}

export default App;
