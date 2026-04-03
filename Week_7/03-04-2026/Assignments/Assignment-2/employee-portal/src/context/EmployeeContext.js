import React, { createContext, useContext, useState } from 'react';

const EmployeeContext = createContext();

export const EmployeeProvider = ({ children }) => {

  // In-memory employee list (acts like database)
  const [employees, setEmployees] = useState([
    {
      id: 1,
      name: 'Rahul',
      email: 'rahul@test.com',
      department: 'IT',
      username: 'rahul',
      password: '1234',
      role: 'employee',
    },
  ]);

  // CREATE - Add new employee
  const addEmployee = (emp) => {
    setEmployees((prev) => [
      ...prev,
      { ...emp, id: Date.now() } // unique id
    ]);
  };

  // UPDATE - Edit employee details
  const updateEmployee = (updatedEmp) => {
    setEmployees((prev) =>
      prev.map((emp) =>
        emp.id === updatedEmp.id ? updatedEmp : emp
      )
    );
  };

  // DELETE - Remove employee
  const deleteEmployee = (id) => {
    setEmployees((prev) =>
      prev.filter((emp) => emp.id !== id)
    );
  };

  return (
    <EmployeeContext.Provider
      value={{ employees, addEmployee, updateEmployee, deleteEmployee }}
    >
      {children}
    </EmployeeContext.Provider>
  );
};

export const useEmployees = () => useContext(EmployeeContext);