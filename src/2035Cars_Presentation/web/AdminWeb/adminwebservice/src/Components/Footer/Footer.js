import React from 'react';
import {
  MDBFooter,
  MDBContainer,
  MDBCol,
  MDBRow
} from 'mdb-react-ui-kit';

export default function Footer() {
  return (
    <MDBFooter bgColor='dark' className='text-center text-lg-left'>

      {
        localStorage.getItem('is-loged') === 'true' ?
        <MDBContainer className='p-4'>
        <MDBRow style={{ display: "flex", justifyContent: "center" }}>
          <MDBCol lg='3' md='6' className='mb-4 mb-md-0'>
            <h5 className='text-uppercase text-light' style={{textAlign: 'left'}}>
              MENU
            </h5>

            <ul className='list-unstyled mb-0' style={{textAlign: 'left'}}>
              <li>
                <a href='/' className='text-light'>
                  Zamówienia
                </a>
              </li>
              {
                localStorage.getItem('role') === '0' ?
                <li>
                  <a href='/pracownicy' className='text-light'>
                    Lista pracowników
                  </a>
                </li>
                :
                <></>
                }
              <li>
                <a href='/samochody' className='text-light'>
                  Lista aut
                </a>
              </li>
              <li>
                <a href='/dodajsamochod' className='text-light'>
                  Dodaj
                </a>
              </li>
            </ul>
          </MDBCol>
          
        </MDBRow>
      </MDBContainer>
      :
      <>
      </>
      }

      <div className='text-center p-3 text-light' style={{ backgroundColor: 'rgba(0, 0, 0, 0.2)' }}>
        &copy; {new Date().getFullYear()} Wszelkie prawa zastrzeżone:{' 203E Cars'}
        <p className='text-light'>
          203ECars - Panel Zarządzania 
        </p>
      </div>
    </MDBFooter>
  );
}