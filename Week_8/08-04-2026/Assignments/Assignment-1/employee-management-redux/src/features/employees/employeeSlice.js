import { createSlice, nanoid } from "@reduxjs/toolkit";

const initialState = {
  employees: [
    {
      id: "1",
      name: "Rahul Sharma",
      department: "HR",
      role: "Manager",
      email: "rahul@company.com",
    },
    {
      id: "2",
      name: "Priya Verma",
      department: "IT",
      role: "Developer",
      email: "priya@company.com",
    },
  ],
};

const employeeSlice = createSlice({
  name: "employees",
  initialState,
  reducers: {
    addEmployee: {
      reducer: (state, action) => {
        state.employees.push(action.payload);
      },
      prepare: (employee) => ({
        payload: {
          id: nanoid(),
          ...employee,
        },
      }),
    },
    updateEmployee: (state, action) => {
      const index = state.employees.findIndex(
        (emp) => emp.id === action.payload.id
      );

      if (index !== -1) {
        state.employees[index] = action.payload;
      }
    },
    deleteEmployee: (state, action) => {
      state.employees = state.employees.filter(
        (emp) => emp.id !== action.payload
      );
    },
  },
});

export const { addEmployee, updateEmployee, deleteEmployee } =
  employeeSlice.actions;
export default employeeSlice.reducer;