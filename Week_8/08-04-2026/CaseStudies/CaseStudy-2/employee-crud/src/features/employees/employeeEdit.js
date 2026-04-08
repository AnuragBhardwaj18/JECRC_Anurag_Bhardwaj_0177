import React, { useEffect } from "react";
import { useDispatch } from "react-redux";
import { updateEmployee } from "../../features/employees/employeeSlice";

function EmployeeEdit({ employee, onClose }) {
  const [name, setName] = React.useState(employee ? employee.name : "");
  const [position, setPosition] = React.useState(employee ? employee.position : "");
  const dispatch = useDispatch();

  useEffect(() => {
    if (employee) {
      setName(employee.name);
      setPosition(employee.position);
    }
  }, [employee]);

  const handleSubmit = (e) => {
    e.preventDefault();

    if (!employee) return;

    dispatch(
      updateEmployee({
        id: employee.id,
        name,
        position
      })
    );

    onClose();
  };

  const clearEdit = () => {
    setName('');
    setPosition('');
    onClose();
  };

  return (
    <div>
      <h2>Edit Employee</h2>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          placeholder="Name"
          value={name}
          onChange={(e) => setName(e.target.value)}
        />
        <input
          type="text"
          placeholder="Position"
          value={position}
          onChange={(e) => setPosition(e.target.value)}
        />
        <button type="submit">Update Employee</button>
        <button type="button" onClick={clearEdit}>Cancel</button>
      </form>
    </div>
  );
}

export default EmployeeEdit;