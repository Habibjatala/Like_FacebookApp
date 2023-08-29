import "./App.css";
import { Routes, Route } from "react-router-dom";
import Home from "./Pages/Home";
import About from "./Pages/About";

import ContactUS from "./Pages/ContactUS";
import Policy from "./Pages/Policy";
import PageNotfound from "./Pages/PageNotfound";
import Register from "./Pages/Auth/Register";
import SignIn from "./Pages/Auth/SignIn";

import ForgetPassword from "./Pages/Auth/ForgetPassword";
import Comments from "./Components/Comments";
import AddPost from "./Pages/AddPost";

function App() {
  return (
    <Routes>
      <Route path="/comments/:id" element={<Comments />} />
      {/* <Route path="/userdashboard" element={<UserDashboard />} />
      <Route path="/admindashboard" element={<AdminDashboard />} /> */}
      <Route path="/" element={<Home />} />

      <Route path="/register" element={<Register />} />
      <Route path="/signin" element={<SignIn />} />
      <Route path="/addnewPost" element={<AddPost />} />
      <Route path="/forgetpassword" element={<ForgetPassword />} />
      <Route path="/about" element={<About />} />
      <Route path="/contact" element={<ContactUS />} />
      <Route path="/policy" element={<Policy />} />
      <Route path="*" element={<PageNotfound />} />
    </Routes>
  );
}

export default App;
