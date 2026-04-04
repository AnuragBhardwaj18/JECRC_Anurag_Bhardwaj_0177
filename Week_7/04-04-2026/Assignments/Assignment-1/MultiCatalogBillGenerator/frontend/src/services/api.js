import axios from "axios";

const API = axios.create({
  baseURL: "http://localhost:5180/api" 
});

export default API;