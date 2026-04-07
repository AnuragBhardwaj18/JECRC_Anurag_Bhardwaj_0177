import React from "react";
import { useAuth } from "../context/AuthContext";
import { useEmployees } from "../context/EmployeeContext";

function EmployeeList() {
  // Get logged-in user info
  const { currentUser } = useAuth();

  // Get employee list and CRUD handlers
  const { employees, deleteEmployee, startEditEmployee } = useEmployees();

  // Admin can view all employees, normal employee can view only own record
  const visibleEmployees =
    currentUser?.role === "admin"
      ? employees
      : employees.filter((emp) => emp.email === currentUser?.email);

  return (
    <div className="card">
      <h3>Employee Records</h3>

      <div className="table-wrapper">
        <table>
          <thead>
            <tr>
              <th>Name</th>
              <th>Email</th>
              <th>Department</th>
              {/* Only admin sees Actions column */}
              {currentUser?.role === "admin" && <th>Actions</th>}
            </tr>
          </thead>
          <tbody>
            {visibleEmployees.length > 0 ? (
              visibleEmployees.map((emp) => (
                <tr key={emp.id}>
                  <td>{emp.name}</td>
                  <td>{emp.email}</td>
                  <td>{emp.department}</td>

                  {/* Only admin can edit and delete */}
                  {currentUser?.role === "admin" && (
                    <td>
                      <button
                        className="edit-btn"
                        onClick={() => startEditEmployee(emp)}
                      >
                        Edit
                      </button>
                      <button
                        className="delete-btn"
                        onClick={() => deleteEmployee(emp.id)}
                      >
                        Delete
                      </button>
                    </td>
                  )}
                </tr>
              ))
            ) : (
              <tr>
                <td colSpan={currentUser?.role === "admin" ? 4 : 3}>
                  No employees found
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
    </div>
  );
}

export default EmployeeList;