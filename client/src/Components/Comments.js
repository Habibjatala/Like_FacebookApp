import React, { useEffect, useState } from "react";
import Layout from "./Layout/Layout";
import Button from "react-bootstrap/Button";
import Card from "react-bootstrap/Card";
import { Navigate, useNavigate, useParams } from "react-router-dom";
import { toast } from "react-hot-toast";
import axios from "axios";

const Comments = () => {
  const auth = localStorage.getItem("user");
  const id = JSON.parse(auth)?.user?.id;
  const param = useParams();
  const navigate = useNavigate();
  const [post, setPost] = useState([]);
  const [commts, setCommts] = useState([]);
  const [content, setContent] = useState([]);
  //const [postId,setPostId]=useState([]);

  const getPostByID = async () => {
    console.log("PArams id  is :", param);
    console.log("Only params  :", param.id);
    try {
      const result = await axios.get(
        `https://localhost:44327/api/Post/${param.id}`
      );
      if (result.data) {
        setPost(result.data);
      }
    } catch (e) {
      console.log(e);
      toast.error("Something wennt worng");
    }
  };
  const getAllCommentsFfPost = async () => {
    try {
      const result = await axios.get(
        `https://localhost:44327/api/Comment?postId=${param.id}`
      );
      if (result.data) {
        setCommts(result.data);
      }
    } catch (e) {
      console.log(e);
      toast.error("Something wennt worng");
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    const postId = param.id;
    const add = {
      content: content,
      postId: postId,
    };
    axios
      .post(
        `https://localhost:44327/api/User/${id}/posts/${postId}/comments`,
        add
      )
      .then((x) => {
        toast.success("Comment is Added");
        getAllCommentsFfPost();
      })
      .catch((error) => {
        toast.error("Something went wrong");
      });
  };

  const handleComment = async (commenterId, commtid) => {
    try {
      const result = await axios.delete("https://localhost:44327/api/Comment", {
        params: {
          commenterId: commenterId,
          commentId: commtid,
        },
      });
      getAllCommentsFfPost();
    } catch (e) {
      console.log(e);
      toast.error("Something went wrong");
    }
  };

  useEffect(() => {
    getPostByID();
  }, []);

  useEffect(() => {
    getAllCommentsFfPost();
  }, []);

  return (
    <Layout title={"Comments"}>
      <div>
        <h1 className="text-center">Comments Box</h1>
        <div className="row justify-content-center align-items-center">
          <div className="col-xs-12 col-md-6 col-lg-4">
            <Card style={{ width: "100%" }} className="mb-3">
              {/* Assuming post.image contains the URL for the image */}
              <Card.Img variant="top" src="/images/c.jpeg " />
              <Card.Body>
                <Card.Title>
                  {" "}
                  <h2> {post.content}</h2>
                </Card.Title>

                <div className="container">
                  <div className="row">
                    <div className="col-6 d-flex justify-content-start">
                      <Button className="w-auto" variant="primary">
                        Likes :{post.likes}
                      </Button>
                    </div>
                    <div className="col-6 d-flex justify-content-end">
                      <Button className="w-auto" variant="primary">
                        Comments
                      </Button>
                    </div>
                  </div>
                </div>
              </Card.Body>
            </Card>
            <form onSubmit={handleSubmit} className="form">
              <input
                value={content}
                onChange={(e) => setContent(e.target.value)}
                type="text"
                placeholder="write Comment"
                className="form-control"
                id="exampleInputName"
              />
              <button type="submit" className="mt-4 mb-3 btn btn-primary">
                ADD
              </button>
            </form>

            <div>
              <h3>Comments:</h3>
              {commts?.map((comment) => (
                <div>
                  <p>{comment.content}</p>

                  <button
                    onClick={() =>
                      handleComment(comment.commenterId, comment.id)
                    }
                  >
                    Deleted
                  </button>
                </div>
              ))}
            </div>
          </div>
        </div>
      </div>
    </Layout>
  );
};

export default Comments;
