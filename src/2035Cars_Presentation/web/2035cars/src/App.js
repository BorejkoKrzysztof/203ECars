import './App.css';
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom';
import Footer from './Components/Footer/Footer';
import Navbar from './Components/Navbar/Navbar';
import MainPage from './Components/Pages/MainPage/MainPage';
import AvailableCarsPage from './Components/Pages/AvailableCarsPage/AvailableCarsPage';

function App() {
  return (
      <Router>
        <Navbar />
          <Routes>
              <Route path='/' element={<MainPage />}/>
              {/* <Route path='/' element={<AvailableCarsPage />} /> */}
          </Routes>
        <Footer />
      </Router>
  );
}

export default App;
