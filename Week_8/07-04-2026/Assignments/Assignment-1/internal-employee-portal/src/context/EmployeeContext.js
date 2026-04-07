import React, { createContext, useContext, useMemo, useState } from "react";

// Creating EmployeeContext to manage employee records globally
const EmployeeContext = createContext();

// In-memory initial employee list
const initialEmployees = [
  { id: 1, name: "Anurag", email: "anurag@company.com", department: "IT" },
  { id: 2, name: "Riya", email: "riya@company.com", department: "HR" },
  { id: 3, name: "Karan", email: "karan@company.com", department: "Finance" },
  { id: 4, name: "Employee User", email: "employee@company.com", department: "IT" },
];

export const EmployeeProvider = ({ children }) => {
  // employees stores all employee records
  const [employees, setEmployees] = useState(initialEmployees);

  // editingEmployee stores currently selected employee for update
  const [editingEmployee, setEditingEmployee] = useState(null);

  // Add new employee
  const addEmployee = (employee) => {
    const newEmployee = {
      id: Date.now(), // Unique id using current timestamp
      ...employee,
    };
    setEmployees((prev) => [...prev, newEmployee]);
  };

  // Delete employee by id
  const deleteEmployee = (id) => {
    setEmployees((prev) => prev.filter((emp) => emp.id !== id));
  };

  // Select employee for editing
  const startEditEmployee = (employee) => {
    setEditingEmployee(employee);
  };

  // Update employee record
  const updateEmployee = (updatedEmployee) => {
    setEmployees((prev) =>
      prev.map((emp) => (emp.id === updatedEmployee.id ? updatedEmployee : emp))
    );
    setEditingEmployee(null);
  };

  // Cancel edit mode
  const cancelEdit = () => {
    setEditingEmployee(null);
  };

  // Memoized value for optimization
  const value = useMemo(() => {
    return {
      employees,
      editingEmployee,
      addEmployee,
      deleteEmployee,
      startEditEmployee,
      updateEmployee,
      cancelEdit,
    };
  }, [employees, editingEmployee]);

  return (
    <EmployeeContext.Provider value={value}>
      {children}
    </EmployeeContext.Provider>
  );
};

// Custom hook for EmployeeContext
export const useEmployees = () => useContext(EmployeeContext);