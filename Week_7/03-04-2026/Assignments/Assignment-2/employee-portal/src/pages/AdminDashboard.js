import React, { useState } from 'react';
import { useEmployees } from '../context/EmployeeContext';

function AdminDashboard() {
  const { employees, addEmployee, updateEmployee, deleteEmployee } = useEmployees();

  // Form state
  const [form, setForm] = useState({
    id: null,
    name: '',
    email: '',
    department: '',
    username: '',
    password: '',
  });

  // Check if editing mode
  const [isEdit, setIsEdit] = useState(false);

  // Handle input change
  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  // Submit form (Add or Update)
  const handleSubmit = (e) => {
    e.preventDefault();

    // Simple validation
    if (!form.name || !form.email) {
      alert('Fill all fields');
      return;
    }

    if (isEdit) {
      updateEmployee(form); // UPDATE
      alert('Updated successfully');
    } else {
      addEmployee(form); // CREATE
      alert('Added successfully');
    }

    // Reset form
    setForm({
      id: null,
      name: '',
      email: '',
      department: '',
      username: '',
      password: '',
    });

    setIsEdit(false);
  };

  // When clicking edit
  const handleEdit = (emp) => {
    setForm(emp); // load data into form
    setIsEdit(true);
  };

  // Delete employee
  const handleDelete = (id) => {
    deleteEmployee(id);
  };

  return (
    <div>
      <h1>Admin Dashboard</h1>

      {/* FORM */}
      <form onSubmit={handleSubmit}>
        <input name="name" value={form.name} onChange={handleChange} placeholder="Name" />
        <input name="email" value={form.email} onChange={handleChange} placeholder="Email" />
        <button type="submit">
          {isEdit ? 'Update' : 'Add'}
        </button>
      </form>

      {/* EMPLOYEE LIST */}
      {employees.map((emp) => (
        <div key={emp.id}>
          {emp.name} - {emp.email}

          <button onClick={() => handleEdit(emp)}>Edit</button>
          <button onClick={() => handleDelete(emp.id)}>Delete</button>
        </div>
      ))}
    </div>
  );
}

export default AdminDashboard;