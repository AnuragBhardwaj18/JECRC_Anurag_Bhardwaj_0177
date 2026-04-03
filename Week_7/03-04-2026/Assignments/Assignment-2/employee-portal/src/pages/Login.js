import React, { useState, useEffect } from 'react';
import { useAuth } from '../context/AuthContext';
import { useEmployees } from '../context/EmployeeContext';
import { useNavigate } from 'react-router-dom';

function Login() {
  const { login, currentUser, loading } = useAuth();
  const { employees } = useEmployees();
  const navigate = useNavigate();

  // Form state to store user input
  const [form, setForm] = useState({
    username: '',
    password: '',
    role: 'employee',
  });

  // Redirect user after successful login
  useEffect(() => {
    if (currentUser?.role === 'admin') {
      navigate('/admin');
    } else if (currentUser?.role === 'employee') {
      navigate('/employee');
    }
  }, [currentUser, navigate]);

  // Handle input changes
  const handleChange = (e) => {
    setForm({
      ...form,
      [e.target.name]: e.target.value,
    });
  };

  // Handle form submit (Login)
  const handleSubmit = (e) => {
    e.preventDefault();

    // Basic validation
    if (!form.username || !form.password) {
      alert('Please fill all fields');
      return;
    }

    // Call login function from AuthContext
    login(form.username, form.password, form.role, employees);
  };

  return (
    <div className="page center-page">
      <div className="card login-card">
        <h1>Employee Portal Login</h1>
        <p className="sub-text">Login as Admin or Employee</p>

        <form onSubmit={handleSubmit}>
          {/* Username */}
          <label>Username</label>
          <input
            type="text"
            name="username"
            placeholder="Enter username (e.g. rahul or admin)"
            value={form.username}
            onChange={handleChange}
          />

          {/* Password */}
          <label>Password</label>
          <input
            type="password"
            name="password"
            placeholder="Enter password"
            value={form.password}
            onChange={handleChange}
          />

          {/* Role Selection */}
          <label>Role</label>
          <select
            name="role"
            value={form.role}
            onChange={handleChange}
          >
            <option value="employee">Employee</option>
            <option value="admin">Admin</option>
          </select>

          {/* Login Button */}
          <button
            type="submit"
            className="primary-btn"
            disabled={loading}
          >
            {loading ? 'Logging in...' : 'Login'}
          </button>
        </form>
      </div>
    </div>
  );
}

export default Login;