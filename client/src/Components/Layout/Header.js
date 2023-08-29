import React from "react";
import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import NavDropdown from "react-bootstrap/NavDropdown";

import { toast } from "react-hot-toast";
import { Link, NavLink, useNavigate } from "react-router-dom";
import { GiShoppingBag } from "react-icons";

import { Badge } from "antd";

const Header = () => {
  const auth = localStorage.getItem("user");

  const navigate = useNavigate();

  const Logout = () => {
    localStorage.clear("user");

    toast.success("User logged out successfully");
    navigate("/signin");
    toast.success("User logged out successfully");
  };
  return (
    <>
      <Navbar collapseOnSelect expand="lg" className="bg-body-tertiary mb-5">
        <Container>
          <NavLink className="navbar-brand" to="/">
            <strong>FACEBOOK APP</strong>{" "}
          </NavLink>
          <Navbar.Toggle aria-controls="responsive-navbar-nav" />
          <Navbar.Collapse id="responsive-navbar-nav">
            <Nav className="nav-mar  ml-auto">
              <></>

              <>
                {auth ? (
                  <>
                    <NavLink
                      className={({ isActive }) =>
                        isActive ? "active" : "inactive"
                      }
                      style={{ padding: "10px", color: "black" }}
                      to="/addnewPost"
                    >
                      Add New
                    </NavLink>{" "}
                    <NavLink
                      className={({ isActive }) =>
                        isActive ? "active" : "inactive"
                      }
                      style={{ padding: "10px", color: "black" }}
                      to="/"
                    >
                      Home
                    </NavLink>
                    <NavDropdown
                      title={JSON.parse(auth)?.user?.username}
                      id="collasible-nav-dropdown"
                    >
                      <NavDropdown.Item to="/" onClick={Logout}>
                        LOG OUT
                      </NavDropdown.Item>
                    </NavDropdown>
                  </>
                ) : (
                  <>
                    <NavLink
                      style={{ padding: "10px", color: "black" }}
                      to="/signin"
                    >
                      SignIn
                    </NavLink>
                    <NavLink
                      style={{ padding: "10px", color: "black" }}
                      to="/register"
                    >
                      Signup
                    </NavLink>
                  </>
                )}
              </>
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    </>
  );
};

export default Header;
