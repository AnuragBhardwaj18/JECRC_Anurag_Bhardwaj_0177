import React, { useEffect, useState } from "react";
import { useEmployees } from "../context/EmployeeContext";

function EmployeeForm() {
  // Access CRUD functions and edit state from employee context
  const {
    addEmployee,
    editingEmployee,
    updateEmployee,
    cancelEdit,
  } = useEmployees();

  // Local state for form fields
  const [formData, setFormData] = useState({
    name: "",
    email: "",
    department: "",
  });

  // When editingEmployee changes, fill form with employee data
  useEffect(() => {
    if (editingEmployee) {
      setFormData({
        name: editingEmployee.name,
        email: editingEmployee.email,
        department: editingEmployee.department,
      });
    } else {
      setFormData({
        name: "",
        email: "",
        department: "",
      });
    }
  }, [editingEmployee]);

  // Handle form field updates
  const handleChange = (e) => {
    setFormData((prev) => ({
      ...prev,
      [e.target.name]: e.target.value,
    }));
  };

  // Handle add/update employee
  const handleSubmit = (e) => {
    e.preventDefault();

    // Simple validation
    if (!formData.name || !formData.email || !formData.department) {
      return;
    }

    if (editingEmployee) {
      // Update existing employee
      updateEmployee({
        id: editingEmployee.id,
        ...formData,
      });
    } else {
      // Add new employee
      addEmployee(formData);
    }

    // Clear form after submission
    setFormData({
      name: "",
      email: "",
      department: "",
    });
  };

  return (
    <div className="card">
      <h3>{editingEmployee ? "Edit Employee" : "Add Employee"}</h3>

      <form onSubmit={handleSubmit} className="employee-form">
        <input
          type="text"
          name="name"
          placeholder="Employee name"
          value={formData.name}
          onChange={handleChange}
        />

        <input
          type="email"
          name="email"
          placeholder="Employee email"
          value={formData.email}
          onChange={handleChange}
        />

        <select
          name="department"
          value={formData.department}
          onChange={handleChange}
        >
          <option value="">Select Department</option>
          <option value="IT">IT</option>
          <option value="HR">HR</option>
          <option value="Finance">Finance</option>
        </select>

        <div className="form-actions">
          <button type="submit" className="primary-btn">
            {editingEmployee ? "Update Employee" : "Add Employee"}
          </button>

          {/* Cancel button is shown only in edit mode */}
          {editingEmployee && (
            <button type="button" onClick={cancelEdit} className="secondary-btn">
              Cancel
            </button>
          )}
        </div>
      </form>
    </div>
  );
}

export default EmployeeForm;