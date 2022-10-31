import { useLocation, Navigate, Outlet } from "react-router-dom";
import { AuthContext } from '../authentication/AuthContext'
import { useContext  } from "react";

const RequiredAuth = () => {
    const location = useLocation()
    const logged = useContext(AuthContext)
    return (
          logged
            ?
            <div style={{ width: '100%', minHeight: '100vh' }}>
              <Outlet />
            </div>
            :
            <div style={{ width: '100%', height: '100vh' }}>
              <Navigate to="/logowanie" state={{ from: location }} replace /> 
            </div>
    )
}

export default RequiredAuth