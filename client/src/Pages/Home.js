import React, { useEffect, useState } from "react";
import Layout from "../Components/Layout/Layout";
import axios from "axios";
import { toast } from "react-hot-toast";
import { useNavigate } from "react-router-dom";
import "../styles/ProductDetailsStyles.css";
import "../styles/Homepage.css";
import Button from "react-bootstrap/Button";
import Card from "react-bootstrap/Card";

const Home = () => {
  const auth = localStorage.getItem("user");
  const id = JSON.parse(auth)?.user?.id;
  const navigate = useNavigate();
  const [posts, setPosts] = useState([]);

  const getAllPosts = async () => {
    try {
      const response = await axios.get("https://localhost:44327/api/Post");
      if (response.data) {
        setPosts(response.data);
      }
    } catch (e) {
      console.log(e);
      toast.error("Something wennt worng");
    }
  };

  const handleLike = async (postId) => {
    try {
      const result = await axios.post(
        `https://localhost:44327/api/User/${id}/posts/${postId}/like`
      );
      if (result.data) {
        toast.success("Liked");
      }
    } catch (e) {
      console.log(e);
      toast.error("Something wennt worng");
    }
  };

  useEffect(() => {
    getAllPosts();

    console.log("The value of id is :", id);
  }, []);

  return (
    <Layout title={"Home page"}>
      {/* banner image */}
      <img
        src="/images/g.jpg"
        className="banner-img"
        alt="bannerimage"
        width={"100%"}
      />
      {/* banner image */}
      {/* <SearchInput /> */}

      <h1 className="text-center"> All Posts </h1>

      <div className="row justify-content-center align-items-center">
        <div className="col-xs-12 col-md-6 col-lg-4">
          {posts.map((post) => (
            <Card style={{ width: "100%" }} className="mb-3">
              {/* Assuming post.image contains the URL for the image */}
              <Card.Img variant="top" src="/images/c.jpeg" alt="ADD IMAGE" />
              <Card.Body>
                <Card.Title>{post.content}</Card.Title>

                <div className="container">
                  <div className="row">
                    <div className="col-6 d-flex justify-content-start">
                      <Button
                        className="w-auto"
                        variant="primary"
                        onClick={() => handleLike(post.id)}
                      >
                        Likes
                        {/* <Likes id={post.id} /> */}
                      </Button>
                    </div>
                    <div className="col-6 d-flex justify-content-end">
                      <Button
                        className="w-auto"
                        variant="primary"
                        onClick={() => navigate(`/comments/${post.id}`)}
                      >
                        Comments
                      </Button>
                    </div>
                  </div>
                </div>
              </Card.Body>
            </Card>
          ))}
        </div>
      </div>
    </Layout>
  );
};

export default Home;
