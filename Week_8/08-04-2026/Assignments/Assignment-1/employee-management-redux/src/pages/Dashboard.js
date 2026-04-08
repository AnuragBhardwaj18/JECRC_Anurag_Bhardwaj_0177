import React, { useState } from "react";
import Header from "../components/Header";
import EmployeeForm from "../components/EmployeeForm";
import EmployeeList from "../components/EmployeeList";

function Dashboard() {
  const [selectedEmployee, setSelectedEmployee] = useState(null);

  return (
    <div className="dashboard">
      <Header />
      <div className="dashboard-content">
        <EmployeeForm
          selectedEmployee={selectedEmployee}
          clearSelection={() => setSelectedEmployee(null)}
        />
        <EmployeeList onEdit={setSelectedEmployee} />
      </div>
    </div>
  );
}

export default Dashboard;