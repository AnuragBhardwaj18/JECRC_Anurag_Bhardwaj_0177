import React from "react";
import { useAuth } from "../context/AuthContext";
import Header from "./Header";
import Analytics from "./Analytics";
import Settings from "./Settings";
import EmployeeForm from "./EmployeeForm";
import EmployeeList from "./EmployeeList";

function Dashboard() {
  // Get current user to apply role-based rendering
  const { currentUser } = useAuth();

  return (
    <div className="dashboard-container">
      {/* Top navigation section */}
      <Header />

      {/* Dashboard cards */}
      <div className="dashboard-grid">
        <Analytics />
        <Settings />
      </div>

      {/* Only admin can add/edit employees */}
      {currentUser?.role === "admin" && <EmployeeForm />}

      {/* Employee list visible to all, but filtered by role */}
      <EmployeeList />
    </div>
  );
}

export default Dashboard;