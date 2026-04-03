import React from 'react';
import { useAuth } from '../context/AuthContext';

function EmployeeDashboard() {
  const { currentUser } = useAuth();

  return (
    <div className="page">
      <h1 className="page-title">Employee Dashboard</h1>

      <div className="card profile-card">
        <h2>My Profile</h2>

        <div className="profile-row">
          <span>Name:</span>
          <strong>{currentUser?.name}</strong>
        </div>

        <div className="profile-row">
          <span>Email:</span>
          <strong>{currentUser?.email}</strong>
        </div>

        <div className="profile-row">
          <span>Department:</span>
          <strong>{currentUser?.department}</strong>
        </div>

        <div className="profile-row">
          <span>Username:</span>
          <strong>{currentUser?.username}</strong>
        </div>

        <div className="profile-row">
          <span>Role:</span>
          <strong>{currentUser?.role}</strong>
        </div>
      </div>
    </div>
  );
}

export default EmployeeDashboard;