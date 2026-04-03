import React from 'react';
import { Navigate } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';

function ProtectedRoute({ children }) {
  const { currentUser } = useAuth();

  // If user is NOT logged in => redirect to login
  if (!currentUser) {
    return <Navigate to="/" />;
  }

  // If logged in => allow access
  return children;
}

export default ProtectedRoute;