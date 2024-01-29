import { useState } from "react";
import { NavLink as RRNavLink, useNavigate } from "react-router-dom";
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
const navigate = useNavigate()

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
            {loggedInUser.roles.includes("Admin") ? (
                <Nav navbar>
                    <NavItem>
                        <NavLink tag={RRNavLink} to="/">Students</NavLink>
                    </NavItem>
                    <NavItem>
                        <NavLink tag={RRNavLink} to="/lessons">Lessons</NavLink>
                    </NavItem>
                    <NavItem>
                        <NavLink tag={RRNavLink} to="/repertoire">Repertoire</NavLink>
                    </NavItem>
                </Nav>
            ) : (
                <Nav navbar>
                    <NavItem>
                        <NavLink tag={RRNavLink} to="/">Student</NavLink>
                    </NavItem>
                    <NavItem>
                        <NavLink tag={RRNavLink} to="/repertoire">Repertoire</NavLink>
                    </NavItem>
                </Nav>
            )}
            {/* </Collapse> */}
            <Button
            color="secondary"
            onClick={(e) => {
                e.preventDefault();
                setOpen(false);
                logout().then(() => {
                setLoggedInUser(null);
                setOpen(false);
                navigate("/login")
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