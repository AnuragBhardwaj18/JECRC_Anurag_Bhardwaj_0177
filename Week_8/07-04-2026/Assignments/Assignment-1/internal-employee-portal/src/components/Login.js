import React, { useState } from "react";
import { useAuth } from "../context/AuthContext";

function Login() {
  const { login } = useAuth();

  const [formData, setFormData] = useState({
    email: "",
    password: "",
  });

  const [error, setError] = useState("");

  // Handle input change
  const handleChange = (e) => {
    setFormData((prev) => ({
      ...prev,
      [e.target.name]: e.target.value,
    }));
  };

  // Handle login
  const handleSubmit = (e) => {
    e.preventDefault();

    const result = login(formData.email, formData.password);

    if (!result.success) {
      setError(result.message);
    } else {
      setError("");
    }
  };

  return (
    <div className="login-container">
      <div className="card login-card">
        <h1>Internal Employee Portal</h1>
        <p className="subtitle">Login to continue</p>

        <form onSubmit={handleSubmit}>
          <input
            type="email"
            name="email"
            placeholder="Enter email"
            value={formData.email}
            onChange={handleChange}
          />

          <input
            type="password"
            name="password"
            placeholder="Enter password"
            value={formData.password}
            onChange={handleChange}
          />

          
          {error && <p className="error">{error}</p>}

          <button type="submit" className="primary-btn">
            Login
          </button>
        </form>
      </div>
    </div>
  );
}

export default Login;