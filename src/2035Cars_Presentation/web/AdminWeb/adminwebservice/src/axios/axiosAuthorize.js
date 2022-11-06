import axios from 'axios'
import jwtDecode from 'jwt-decode'
import dayjs from 'dayjs'

const baseURL = process.env.REACT_APP_SERVER;

const instance = axios.create({
                    baseURL: `${baseURL}`,
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/json; charset=utf-8'
                    }
                })


instance.interceptors.request.use(async (req) => {
    const jwt = localStorage.getItem('token');

    const user = jwtDecode(jwt);
    const isExpired = dayjs.unix(user.exp).diff(dayjs()) < 1;

    if (!isExpired)
    {
        req.headers.Authorization = `Bearer ${jwt}`;
        return req;
    }
    else 
    {
        const refreshToken = localStorage.getItem('refreshToken')
        const response = await axios.post(`${baseURL}/employee/refreshtoken`, {
            RefreshToken : refreshToken
        })

        localStorage.setItem('token', response.data.token)
        req.headers.Authorization = `Bearer ${response.data.token}`
        return req;
    }
})

export default instance;