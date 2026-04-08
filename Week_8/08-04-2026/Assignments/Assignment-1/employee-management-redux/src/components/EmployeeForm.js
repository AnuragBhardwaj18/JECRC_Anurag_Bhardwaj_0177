import React, { useEffect, useState } from "react";
import { useDispatch } from "react-redux";
import {
  addEmployee,
  updateEmployee,
} from "../features/employees/employeeSlice";

function EmployeeForm({ selectedEmployee, clearSelection }) {
  const dispatch = useDispatch();

  const [employee, setEmployee] = useState({
    name: "",
    department: "",
    role: "",
    email: "",
  });

  useEffect(() => {
    if (selectedEmployee) {
      setEmployee(selectedEmployee);
    } else {
      setEmployee({
        name: "",
        department: "",
        role: "",
        email: "",
      });
    }
  }, [selectedEmployee]);

  const handleChange = (e) => {
    setEmployee((prev) => ({
      ...prev,
      [e.target.name]: e.target.value,
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    if (
      !employee.name ||
      !employee.department ||
      !employee.role ||
      !employee.email
    ) {
      alert("Please fill all fields");
      return;
    }

    if (selectedEmployee) {
      dispatch(updateEmployee(employee));
      clearSelection();
    } else {
      dispatch(addEmployee(employee));
    }

    setEmployee({
      name: "",
      department: "",
      role: "",
      email: "",
    });
  };

  return (
    <form className="employee-form" onSubmit={handleSubmit}>
      <h3>{selectedEmployee ? "Edit Employee" : "Add Employee"}</h3>

      <input
        type="text"
        name="name"
        placeholder="Employee Name"
        value={employee.name}
        onChange={handleChange}
      />

      <input
        type="text"
        name="department"
        placeholder="Department"
        value={employee.department}
        onChange={handleChange}
      />

      <input
        type="text"
        name="role"
        placeholder="Role"
        value={employee.role}
        onChange={handleChange}
      />

      <input
        type="email"
        name="email"
        placeholder="Email"
        value={employee.email}
        onChange={handleChange}
      />

      <button type="submit">
        {selectedEmployee ? "Update Employee" : "Add Employee"}
      </button>

      {selectedEmployee && (
        <button type="button" className="cancel-btn" onClick={clearSelection}>
          Cancel
        </button>
      )}
    </form>
  );
}

export default EmployeeForm;