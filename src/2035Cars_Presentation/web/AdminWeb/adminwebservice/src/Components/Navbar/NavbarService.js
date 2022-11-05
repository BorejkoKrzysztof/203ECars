import React, { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { FaCar } from 'react-icons/fa'

import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink,
  UncontrolledDropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem,
  NavbarText,
} from 'reactstrap';

function NavbarService(args) {
  const [isOpen, setIsOpen] = useState(false);

  const toggle = () => setIsOpen(!isOpen);

  const logoutHandler = () => {
    localStorage.removeItem('token')
    localStorage.removeItem('refreshToken')
    localStorage.removeItem('role')
    localStorage.setItem('is-loged', `${false}`)

    window.location.reload(true)
  }

  return (
    <div>
      <Navbar 
          color='dark' dark={true} expand='sm'>
        <NavbarBrand>
          <span style={{ color: 'white', marginRight: '15px', fontSize: '24px' }}>
            <FaCar />
          </span>
          203E Cars</NavbarBrand>
        <NavbarToggler onClick={toggle} />
        <Collapse isOpen={isOpen} navbar>
          {
            localStorage.getItem('is-loged') === 'true' ? 
            <>
              <Nav className="me-auto" navbar>
              <NavItem>
                <NavLink href="/">Zamówienia</NavLink>
              </NavItem>
              <UncontrolledDropdown nav inNavbar>
                <DropdownToggle nav caret>
                  Pracownicy
                </DropdownToggle>
                {
                  localStorage.getItem('role') === '0' ?
                  <DropdownMenu right>
                    <DropdownItem href='/pracownicy' style={{color: 'black'}}>
                      Lista pracowników
                    </DropdownItem>
                    {/* <DropdownItem>Dodaj</DropdownItem> */}
                  </DropdownMenu>
                :
                <></>
                }
              </UncontrolledDropdown>
              <UncontrolledDropdown nav inNavbar>
                <DropdownToggle nav caret>
                  Samochody
                </DropdownToggle>
                <DropdownMenu right>
                  <DropdownItem  href='/samochody' style={{color: 'black'}}>
                    Lista aut
                  </DropdownItem>
                  <DropdownItem  href='/dodajsamochod' style={{color: 'black'}}>
                    Dodaj
                  </DropdownItem>
                </DropdownMenu>
              </UncontrolledDropdown>
            </Nav>
            <NavbarText style={{color: 'red', cursor: 'pointer'}} onClick={logoutHandler}>
              WYLOGUJ SIĘ!
            </NavbarText>
            </>
          :
          <></>
          }
        </Collapse>
      </Navbar>
    </div>
  );
}

export default NavbarService;