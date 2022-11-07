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
import EditCarPage from './Components/Pages/EditCarPage/EditCarPage';
import EditEmployeePage from './Components/Pages/EditEmployeePage/EditEmployeePage';
import AcceptEmployeeRegistrationPage from './Components/Pages/AcceptEmployeeRegistrationPage/AcceptEmployeeRegistrationPage';
import OrderListsPage from './Components/Pages/OrderListPage/OrderListsPage';
import useLocalStorage from './hooks/useLocalStorage';
import { AuthContext } from './authentication/AuthContext';
import RequiredAuth from './authentication/RequireAuth';

function App() {

  const [logged, setLogged] = useLocalStorage('is-loged', false);

  return (
    <AuthContext.Provider value={logged}>
      <Router>
        <NavbarService />
          <Routes>
            <Route path='/logowanie' element={<LoginPage />}/>
            <Route path='/rejestracja' element={<Register />} />
            <Route element={<RequiredAuth />}>
                <Route path='/pracownicy' element={<EmployeeListPage />} />
                <Route path='/szczegolypracownika' element={<EmployeeDetails />} />
                <Route path='/samochody' element={<CarListPage />} />
                {/* <Route path='/' element={<CarDetailsPage />}/> */}
                <Route path='/dodajsamochod' element={<AddCarPage />}/>
                {/* <Route path='/' element={<EditCarPage />}/> */}
                {/* <Route path='/' element={<EditEmployeePage />}/> */}
                {/* <Route path='/' element={<AcceptEmployeeRegistrationPage />}/> */}
                <Route path='/' element={<OrderListsPage />}/>
            </Route>



            {/* <Route path='/' element={<EmployeeDetails />} /> */}
                {/* <Route path='/' element={<CarListPage />} /> */}
                {/* <Route path='/' element={<CarDetailsPage />}/> */}
                {/* <Route path='/' element={<AddCarPage />}/> */}
                {/* <Route path='/' element={<EditCarPage />}/> */}
                {/* <Route path='/' element={<EditEmployeePage />}/> */}
                {/* <Route path='/' element={<AcceptEmployeeRegistrationPage />}/> */}
                {/* <Route path='/' element={<OrderListsPage />}/> */}


                
          </Routes>
        <Footer />
      </Router>
    </AuthContext.Provider>
  );
}

export default App;
