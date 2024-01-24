import { useState } from "react";
import { NavLink as RRNavLink } from "react-router-dom";
import {
Button,
Collapse,
Nav,
NavLink,
NavItem,
Navbar,
NavbarBrand,
NavbarToggler,
} from "reactstrap";
import { logout } from "../managers/authManager";
import "./NavBar.css"

export default function NavBar({ loggedInUser, setLoggedInUser }) {
const [open, setOpen] = useState(false);

const toggleNavbar = () => setOpen(!open);

return (
    <div className="navbar-container">
    <Navbar 
        // fixed="true" 
        // expand="lg"
    >
        <NavbarBrand className="mr-auto" tag={RRNavLink} to="/">
            <div className="logo-img">
                <img src="/images/DelftHornLogo.png" />
            </div>
        Delft Horn Studio
        </NavbarBrand>
        {loggedInUser ? (
        <>
            {/* <NavbarToggler onClick={toggleNavbar} /> */}
            {/* <Collapse isOpen={open} navbar> */}
            <Nav navbar>
                <NavItem>
                    <NavLink tag={RRNavLink} to="/lessons">Lessons</NavLink>
                </NavItem>
                <NavItem>
                    <NavLink tag={RRNavLink} to="/">Students</NavLink>
                </NavItem>
                <NavItem>
                    <NavLink tag={RRNavLink}>Repertoire</NavLink>
                </NavItem>
            </Nav>
            {/* </Collapse> */}
            <Button
            color="secondary"
            onClick={(e) => {
                e.preventDefault();
                setOpen(false);
                logout().then(() => {
                setLoggedInUser(null);
                setOpen(false);
                });
            }}
            >
            Logout
            </Button>
        </>
        ) : (
        <Nav navbar>
            <NavItem>
            <NavLink tag={RRNavLink} to="/login">
                <Button color="secondary">Login</Button>
            </NavLink>
            </NavItem>
        </Nav>
        )}
    </Navbar>
    </div>
);
}