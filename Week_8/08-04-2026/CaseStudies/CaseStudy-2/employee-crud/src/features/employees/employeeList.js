import React from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { deleteEmployee } from '../../features/employees/employeeSlice';

const EmployeeList = ({ onEdit }) => {
  const employees = useSelector(state => state.employees.employees);
  const dispatch = useDispatch();

  return (
    <div>
      <h2>Employee List</h2>
      {employees.length === 0 ? (
        <p>No employees added yet.</p>
      ) : (
        employees.map((employee) => (
          <div key={employee.id}>
            <p>{employee.name}</p>
            <p>{employee.position}</p>
            <button onClick={() => onEdit(employee)}>Edit</button>
            <button onClick={() => dispatch(deleteEmployee(employee.id))}>
              Delete
            </button>
          </div>
        ))
      )}
    </div>
  );
};

export default EmployeeList;