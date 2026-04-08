import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { deleteEmployee } from "../features/employees/employeeSlice";

function EmployeeList({ onEdit }) {
  const dispatch = useDispatch();
  const employees = useSelector((state) => state.employees.employees);

  return (
    <div className="employee-list">
      <h3>Employee Records</h3>

      {employees.length === 0 ? (
        <p>No employees found</p>
      ) : (
        <table>
          <thead>
            <tr>
              <th>Name</th>
              <th>Department</th>
              <th>Role</th>
              <th>Email</th>
              <th>Actions</th>
            </tr>
          </thead>

          <tbody>
            {employees.map((emp) => (
              <tr key={emp.id}>
                <td>{emp.name}</td>
                <td>{emp.department}</td>
                <td>{emp.role}</td>
                <td>{emp.email}</td>
                <td>
                  <button onClick={() => onEdit(emp)}>Edit</button>
                  <button
                    className="delete-btn"
                    onClick={() => dispatch(deleteEmployee(emp.id))}
                  >
                    Delete
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}

export default EmployeeList;