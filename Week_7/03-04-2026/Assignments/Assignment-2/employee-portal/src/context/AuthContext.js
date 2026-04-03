import React, { createContext, useContext, useState } from 'react';

// Create a context for authentication
const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  // Stores currently logged-in user
  const [currentUser, setCurrentUser] = useState(null);

  // Used to show loading during login
  const [loading, setLoading] = useState(false);

  // LOGIN FUNCTION
  const login = (username, password, role, employees) => {
    setLoading(true); // start loader

    setTimeout(() => {
      // If user selects admin login
      if (role === 'admin') {
        // Hardcoded admin credentials
        if (username === 'admin' && password === 'admin123') {
          setCurrentUser({
            id: 999,
            name: 'HR Admin',
            role: 'admin',
          });
        } else {
          alert('Invalid Admin credentials');
        }
      } 
      // If employee login
      else {
        // Find employee from in-memory data
        const user = employees.find(
          (emp) =>
            emp.username === username &&
            emp.password === password
        );

        if (user) {
          setCurrentUser(user); // login success
        } else {
          alert('Invalid Employee credentials');
        }
      }

      setLoading(false); // stop loader
    }, 1000); // fake delay to simulate API
  };

  // LOGOUT FUNCTION
  const logout = () => {
    setCurrentUser(null); // clear user
  };

  return (
    <AuthContext.Provider value={{ currentUser, login, logout, loading }}>
      {children}
    </AuthContext.Provider>
  );
};

// Custom hook for easy usage
export const useAuth = () => useContext(AuthContext);