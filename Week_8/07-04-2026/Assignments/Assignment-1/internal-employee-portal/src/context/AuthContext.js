import React, { createContext, useContext, useMemo, useState } from "react";

// Creating AuthContext for authentication-related global state
const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  // currentUser stores logged-in user details
  const [currentUser, setCurrentUser] = useState(null);

  // login function checks static credentials and sets user data
  const login = (email, password) => {
    // Admin login
    if (email === "admin@company.com" && password === "admin123") {
      setCurrentUser({
        id: 1,
        name: "Admin User",
        email: "admin@company.com",
        role: "admin",
      });
      return { success: true };
    }

    // Employee login
    if (email === "employee@company.com" && password === "employee123") {
      setCurrentUser({
        id: 2,
        name: "Employee User",
        email: "employee@company.com",
        role: "employee",
      });
      return { success: true };
    }

    // Invalid login case
    return { success: false, message: "Invalid credentials" };
  };

  // logout function clears the logged-in user
  const logout = () => {
    setCurrentUser(null);
  };

  // useMemo helps optimize performance by preventing unnecessary re-creations
  const value = useMemo(() => {
    return {
      currentUser,
      isAuthenticated: !!currentUser,
      login,
      logout,
    };
  }, [currentUser]);

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
};

// Custom hook for easy access to AuthContext
export const useAuth = () => useContext(AuthContext);