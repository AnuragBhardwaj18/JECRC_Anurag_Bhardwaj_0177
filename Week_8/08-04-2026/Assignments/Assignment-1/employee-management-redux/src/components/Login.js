import React, { useState } from "react";
import { useDispatch } from "react-redux";
import { login } from "../features/auth/authSlice";
import { setLoading } from "../features/ui/uiSlice";

function Login() {
  const dispatch = useDispatch();

  const [formData, setFormData] = useState({
    username: "",
    password: "",
  });

  const [error, setError] = useState("");

  const handleChange = (e) => {
    setFormData((prev) => ({
      ...prev,
      [e.target.name]: e.target.value,
    }));
  };

  const handleLogin = (e) => {
    e.preventDefault();
    setError("");

    if (!formData.username || !formData.password) {
      setError("Please fill all fields");
      return;
    }

    if (
      formData.username !== "Anurag" ||
      formData.password !== "123"
    ) {
      setError("Invalid username or password");
      return;
    }

    dispatch(setLoading(true));

    setTimeout(() => {
      dispatch(
        login({
          username: formData.username,
        })
      );
      dispatch(setLoading(false));
    }, 1000);
  };

  return (
    <div className="login-container">
      <form className="login-card" onSubmit={handleLogin}>
        <h2>Employee Login</h2>
        <p className="subtitle">Login to access the dashboard</p>

        {error && <p className="error">{error}</p>}

        <input
          type="text"
          name="username"
          placeholder="Enter username"
          value={formData.username}
          onChange={handleChange}
        />

        <input
          type="password"
          name="password"
          placeholder="Enter password"
          value={formData.password}
          onChange={handleChange}
        />

        <button type="submit">Login</button>
      </form>
    </div>
  );
}

export default Login;