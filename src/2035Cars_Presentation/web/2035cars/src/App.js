import './App.css';
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom';
import Footer from './Components/Footer/Footer';
import Navbar from './Components/Navbar/Navbar';
import MainPage from './Components/Pages/MainPage/MainPage';
import AvailableCarsPage from './Components/Pages/AvailableCarsPage/AvailableCarsPage';
import LoginPage from './Components/Pages/LoginPage/LoginPage'
import RegisterPage from './Components/Pages/RegisterPage/RegisterPage'
import ContactPage from './Components/Pages/ContactPage/ContactPage';
import GivePersonalDataPage from './Components/Pages/GivePersonalDataPage/GivePersonalDataPage.js'
import ConfirmationPage from './Components/Pages/ConfirmationPage/ConfirmationPage.js'

function App() {
  return (
      <Router>
        <Navbar />
          <Routes>
              <Route path='/' element={<MainPage />}/>
              {/* <Route path='/' element={<AvailableCarsPage />} /> */}
              {/* <Route path='/' element={<LoginPage />}/> */}
              {/* <Route path='/' element={<RegisterPage />}/> */}
              {/* <Route path='/' element={<ContactPage />}/> */}

              {/* <Route path='/' element={<GivePersonalDataPage />} /> */}
              {/* <Route path='/' element={<ConfirmationPage />} /> */}
          </Routes>
        <Footer />
      </Router>
  );
}

export default App;
