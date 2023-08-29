import React, { useEffect, useState } from "react";
import Layout from "../../Components/Layout/Layout";
import toast from "react-hot-toast";
import axios from "axios";
import "../../styles/AuthStyles.css";
import { useLocation, useNavigate } from "react-router-dom";

const SignIn = () => {
  const location = useLocation();
  useEffect(() => {
    const auth = localStorage.getItem("user");
    if (auth) {
      navigate("/");
    }
  });
  const [email, SetEmail] = useState("");
  const [password, SetPassword] = useState("");
  const navigate = useNavigate();
  const HandleSubmit = async (e) => {
    e.preventDefault();
    const user = {
      email: email,
      password: password,
    };

    try {
      const response = await axios.post(
        "https://localhost:44327/api/User/login",
        user
      );
      console.log(response.data);

      if (response.data) {
        localStorage.setItem("user", JSON.stringify(response.data));
        navigate(location.state || "/");
        toast.success(response.data.message);
        console.log(response.data.message);
      } else {
        toast.error(response.data.message);
        console.log(response.data.message);
      }
    } catch (error) {
      console.error(error);
      toast.error("Invalid Credentials");
    }
  };
  return (
    <Layout title={"Sign In"}>
      <div className="form-container">
        <form onSubmit={HandleSubmit} className="form">
          <h4 className="title">SIGNIN FORM</h4>
          <div className="mb-3">
            Email
            <input
              value={email}
              onChange={(e) => SetEmail(e.target.value)}
              type="email"
              placeholder="Enter your email"
              className="form-control"
              id="exampleInputEmail1"
              required
            />
          </div>
          <div className="mb-3">
            Password
            <input
              value={password}
              onChange={(e) => SetPassword(e.target.value)}
              type="password"
              placeholder="Enter your password"
              className="form-control"
              id="exampleInputPassword1"
              required
            />
          </div>
          <div className="mb-3">
            <button type="submit" className="ml-2 btn btn-primary">
              Submit
            </button>
          </div>
          <div className="mb-3">
            <button
              type="button"
              className="ml-2 btn btn-primary"
              onClick={() => {
                navigate("/forgetpassword");
              }}
            >
              Forget password
            </button>
          </div>
        </form>
      </div>
    </Layout>
  );
};

export default SignIn;
