import React from "react";
import { Link } from "react-router-dom";

const Footer = () => {
  return (
    <div className="footer mt-5">
      <h4 className="text-center ms-13">All Copy Reserved &copy; Habib</h4>
      <p className="text-center mt-3">
        <Link to="/about">About Us</Link>
        <Link to="/contact">Contact Us</Link>
        <Link to="/policy">Privacy Policies</Link>
      </p>
    </div>
  );
};

export default Footer;
