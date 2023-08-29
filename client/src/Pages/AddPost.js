import React, { useState } from "react";
import Layout from "../Components/Layout/Layout";
import "../styles/AuthStyles.css";
import { toast } from "react-hot-toast";
import axios from "axios";

const AddPost = () => {
  const auth = localStorage.getItem("user");
  const id = JSON.parse(auth)?.user?.id;
  const [content, setContent] = useState();

  const handleSubmit = async () => {
    const postdata = {
      content: content,
      authorId: id,
    };

    debugger;

    const result = await axios
      .post(`https://localhost:44327/api/User/${id}/posts`, postdata)
      .then((data) => {
        debugger;
        toast.success("Post Added");
      })
      .error((error) => {
        toast.error("Something went wrong");
      });
  };
  return (
    <Layout title={"Add New Post"}>
      <div className="form-container">
        <form onSubmit={handleSubmit} className="form">
          <h4 className="title">Add New Post</h4>
          <div className="mb-3">
            <input
              value={content}
              onChange={(e) => setContent(e.target.value)}
              type="text"
              placeholder="Add Content"
              className="form-control"
              id="exampleInputName"
              required
            />
          </div>

          <div className="mb-3"></div>
          <button type="submit" className="ml-2 btn btn-primary">
            Submit
          </button>
        </form>
      </div>
    </Layout>
  );
};

export default AddPost;
