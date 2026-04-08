import { configureStore } from "@reduxjs/toolkit";
import authReducer from "../features/auth/authSlice";
import employeeReducer from "../features/employees/employeeSlice";
import uiReducer from "../features/ui/uiSlice";
import logger from "redux-logger";
import { loadState, saveState } from "../utils/localStorage";

const persistedState = loadState();

export const store = configureStore({
  reducer: {
    auth: authReducer,
    employees: employeeReducer,
    ui: uiReducer,
  },
  preloadedState: persistedState,
  middleware: (getDefaultMiddleware) => getDefaultMiddleware().concat(logger),
});

store.subscribe(() => {
  saveState({
    auth: store.getState().auth,
    employees: store.getState().employees,
    ui: store.getState().ui,
  });
});