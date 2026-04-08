import React from "react";
import { useSelector } from "react-redux";
import Login from "./components/Login";
import Dashboard from "./pages/Dashboard";
import Loader from "./components/Loader";

function App() {
  const { isAuthenticated } = useSelector((state) => state.auth);
  const { loading, theme } = useSelector((state) => state.ui);

  return (
    <div className={`app ${theme}`}>
      {loading && <Loader />}
      {isAuthenticated ? <Dashboard /> : <Login />}
    </div>
  );
}

export default App;