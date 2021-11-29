import axios from "axios";

const axiosConfig = {
  baseURL: "http://localhost:5000",
}

export const httpClient = axios.create(axiosConfig)