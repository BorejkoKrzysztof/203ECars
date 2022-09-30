import axios from 'axios'

const baseUrl = process.env.REACT_APP_SERVER;

const instance = axios.create({
    baseURL: baseUrl,
    headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json; charset=utf-8'
    }
})

export default instance;