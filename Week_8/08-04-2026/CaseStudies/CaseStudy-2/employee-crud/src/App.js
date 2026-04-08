import React from "react";
import EmployeeList from "./features/employees/employeeList";
import EmployeeAdd from "./features/employees/employeeAdd";
import EmployeeEdit from "./features/employees/employeeEdit";

function App() {
  const [editingEmployee, setEditingEmployee] = React.useState(null);

  return (
    <div>
      <h1>Employee Management</h1>
      <EmployeeAdd />
      <EmployeeList onEdit={(employee) => setEditingEmployee(employee)} />
      {editingEmployee && (
        <EmployeeEdit
          employee={editingEmployee}
          onClose={() => setEditingEmployee(null)}
        />
      )}
    </div>
  );
}

export default App;