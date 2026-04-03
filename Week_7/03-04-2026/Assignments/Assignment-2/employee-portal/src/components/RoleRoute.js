import React from 'react';
import { Navigate } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';

function RoleRoute({ children, allowedRole }) {
  const { currentUser } = useAuth();

  // If user role is not allowed => redirect
  if (currentUser.role !== allowedRole) {
    return <Navigate to="/unauthorized" />;
  }

  return children;
}

export default RoleRoute;