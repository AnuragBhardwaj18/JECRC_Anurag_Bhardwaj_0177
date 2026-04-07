import React from "react";
import { useEmployees } from "../context/EmployeeContext";

function Analytics() {
  // Access employee list from global employee context
  const { employees } = useEmployees();

  // Calculating analytics values
  const totalEmployees = employees.length;
  const itCount = employees.filter((emp) => emp.department === "IT").length;
  const hrCount = employees.filter((emp) => emp.department === "HR").length;
  const financeCount = employees.filter((emp) => emp.department === "Finance").length;

  return (
    <div className="card">
      <h3>Analytics</h3>
      <div className="analytics-grid">
        <div className="stat-box">
          <h4>{totalEmployees}</h4>
          <p>Total Employees</p>
        </div>
        <div className="stat-box">
          <h4>{itCount}</h4>
          <p>IT Department</p>
        </div>
        <div className="stat-box">
          <h4>{hrCount}</h4>
          <p>HR Department</p>
        </div>
        <div className="stat-box">
          <h4>{financeCount}</h4>
          <p>Finance Department</p>
        </div>
      </div>
    </div>
  );
}

export default Analytics;