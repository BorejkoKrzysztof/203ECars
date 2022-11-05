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
    const jwt = JSON.parse(localStorage.getItem('token'));

    const user = jwtDecode(jwt);
    const isExpired = dayjs.unix(user.exp).diff(dayjs()) < 1;

    if (!isExpired)
    {
        req.headers.common.Authorization = `Bearer ${jwt}`;
        return req;
    }
    else 
    {
        const refreshToken = JSON.parse(sessionStorage.getItem('refreshToken'))
        const response = await axios.post(`${baseURL}/employee/refreshtoken`, {
            RefreshToken : refreshToken
        })

        sessionStorage.setItem('token', JSON.stringify(response.data.token))
        req.headers.common.Authorization = `Bearer ${response.data.token}`
        return req;
    }
})

export default instance;