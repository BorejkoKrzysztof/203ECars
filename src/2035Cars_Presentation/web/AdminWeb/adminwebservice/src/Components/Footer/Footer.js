import React from 'react';
import {
  MDBFooter,
  MDBContainer,
  MDBCol,
  MDBRow
} from 'mdb-react-ui-kit';
import 'mdb-react-ui-kit/dist/css/mdb.min.css'

export default function App() {
  return (
    <MDBFooter bgColor='dark' className='text-center text-lg-left'>
      <MDBContainer className='p-4'>
        <MDBRow>
          <MDBCol lg='3' md='6' className='mb-4 mb-md-0'>
            <h5 className='text-uppercase text-light'>Links</h5>

            <ul className='list-unstyled mb-0'>
              <li>
                <a href='#!' className='text-light'>
                  Link 1
                </a>
              </li>
              <li>
                <a href='#!' className='text-light'>
                  Link 2
                </a>
              </li>
              <li>
                <a href='#!' className='text-light'>
                  Link 3
                </a>
              </li>
              <li>
                <a href='#!' className='text-light'>
                  Link 4
                </a>
              </li>
            </ul>
          </MDBCol>

          <MDBCol lg='3' md='6' className='mb-4 mb-md-0'>
            <h5 className='text-uppercase text-light'>Links</h5>

            <ul className='list-unstyled mb-0'>
              <li>
                <a href='#!' className='text-light'>
                  Link 1
                </a>
              </li>
              <li>
                <a href='#!' className='text-light'>
                  Link 2
                </a>
              </li>
              <li>
                <a href='#!' className='text-light'>
                  Link 3
                </a>
              </li>
              <li>
                <a href='#!' className='text-light'>
                  Link 4
                </a>
              </li>
            </ul>
          </MDBCol>
          
        </MDBRow>
      </MDBContainer>

      <div className='text-center p-3' style={{ backgroundColor: 'rgba(0, 0, 0, 0.2)' }}>
        &copy; {new Date().getFullYear()} Copyright:{' '}
        <a className='text-dark' href='https://mdbootstrap.com/'>
          MDBootstrap.com
        </a>
      </div>
    </MDBFooter>
  );
}