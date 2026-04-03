import React from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';

function Navbar() {
  const { currentUser, logout } = useAuth();
  const navigate = useNavigate();

  const handleLogout = () => {
    logout();
    navigate('/');
  };

  return (
    <div className="navbar">
      <h2>Employee Portal</h2>

      <div>
        {!currentUser ? (
          <Link to="/" className="nav-btn">Login</Link>
        ) : (
          <>
            <span className="user-info">
              Welcome, {currentUser.name} ({currentUser.role})
            </span>
            <button className="logout-btn" onClick={handleLogout}>
              Logout
            </button>
          </>
        )}
      </div>
    </div>
  );
}

export default Navbar;